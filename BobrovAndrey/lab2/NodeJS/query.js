const mysql = require("mysql2");
const fs = require("fs");


// Создаем пул
const poolWithoutPromise = mysql.createPool({
    connectionLimit: 5,
    host: "localhost",
    user: "root",
    password: "",
    database: "flowers"
});

// Создаем промис для пула, чтобы можно было удобно совершать асинхронные запросы к бд
const pool = poolWithoutPromise.promise();

// Получение всех строк из таблицы
selectAllFromTable = async (tableName) => {
    let result = await pool.query(`SELECT * FROM ${tableName}`);
    return result[0];
};

// Получение конкретных строк из таблицы с условием
selectFromTable = async (tableName, value, where) => {
    let result;
    if(where)
        result = await pool.query(`SELECT ${value} FROM ${tableName} WHERE ${where}`);
    else
        result = await pool.query(`SELECT ${value} FROM ${tableName}`);
    return result[0];
};

// Вставить запись в таблицу
insertIntoTable = async (tableName, id, select, input, FK) => {
    let name = select;
    if(input !== '') {
        name = input;
        let valueNames = FK ? `PK_Family, name` : `name`;
        let values = FK ? `${FK}, '${name}'` : `'${name}'`;
        await pool.query(`INSERT INTO ${tableName} (${valueNames}) VALUES (${values})`);
    }
    let PK = await selectFromTable(tableName, id, `name='${name}'`);
    return PK[0][`${id}`];
}

// Создание продукта
createProduct = async (data, files) => {
    let familyPK = await insertIntoTable("family", "PK_Family", data.familySelect, data.family);
    let genusPK = await insertIntoTable("genus", "PK_Genus", data.genusSelect, data.genus, familyPK);
    let decorativePK = await insertIntoTable("decoratives", "PK_Decoratives", data.decorativeSelect, data.decorative);
    let shootsPK = await insertIntoTable("shoots", "PK_Shoots", data.shootsSelect, data.shoots);
    let windowPK = await insertIntoTable("window", "PK_Window", data.windowSelect, data.window);
    
    await pool.query(`
    INSERT 
        INTO flowers (name, price, description, PK_Genus, PK_Decoratives, PK_Shoots, PK_Window) 
        VALUES ('${data.title}', ${data.price}, '${data.text}', ${genusPK}, ${decorativePK}, ${shootsPK}, ${windowPK})`);
    let flowerPK = await selectFromTable("flowers", "PK_Flowers", `name='${data.title}'`);
    flowerPK = flowerPK[0][`PK_Flowers`];

    let i = 1;
    while(data[`conditions${i}Select`]) {
        let conditionPK = await insertIntoTable("conditions", "PK_Conditions", data[`conditions${i}Select`], data[`conditions${i}`]);
        await pool.query(`
        INSERT 
            INTO flower_condition (PK_Flowers, PK_Conditions) 
            VALUES (${flowerPK}, ${conditionPK})`);
        i++;
    }

    await files.forEach(async (file) => {
        await pool.query(`
        INSERT 
            INTO images (url, PK_Flowers) 
            VALUES ('${file.filename}', ${flowerPK})`);
        i++;
    })
}

// Редактирование продукта
editProduct = async (data, files, flowerPK) => {
    let familyPK = await insertIntoTable("family", "PK_Family", data.familySelect, data.family);
    let genusPK = await insertIntoTable("genus", "PK_Genus", data.genusSelect, data.genus, familyPK);
    let decorativePK = await insertIntoTable("decoratives", "PK_Decoratives", data.decorativeSelect, data.decorative);
    let shootsPK = await insertIntoTable("shoots", "PK_Shoots", data.shootsSelect, data.shoots);
    let windowPK = await insertIntoTable("window", "PK_Window", data.windowSelect, data.window);
    
    await pool.query(`DELETE FROM flower_condition WHERE PK_Flowers=${flowerPK}`);

    let oldImages = await pool.query(`SELECT * FROM images WHERE PK_Flowers=${flowerPK}`);
    oldImages = oldImages[0];
    oldImages.forEach((oldImage) => {
        fs.unlinkSync(__dirname + '\\images\\' + oldImage.url);
    })

    await pool.query(`DELETE FROM images WHERE PK_Flowers=${flowerPK}`);

    await pool.query(`
    UPDATE flowers 
        SET 
            name='${data.title}', 
            price=${data.price}, 
            description='${data.text}', 
            PK_Genus=${genusPK}, 
            PK_Decoratives=${decorativePK}, 
            PK_Shoots=${shootsPK}, 
            PK_Window=${windowPK} 
        WHERE PK_Flowers=${flowerPK}`);

    let i = 1;
    while(data[`conditions${i}Select`]) {
        let conditionPK = await insertIntoTable("conditions", "PK_Conditions", data[`conditions${i}Select`], data[`conditions${i}`]);
        await pool.query(`
        INSERT 
            INTO flower_condition (PK_Flowers, PK_Conditions) 
            VALUES (${flowerPK}, ${conditionPK})`);
        i++;
    }

    await files.forEach(async (file) => {
        await pool.query(`
        INSERT INTO images (url, PK_Flowers) 
            VALUES ('${file.filename}', ${flowerPK})`);
        i++;
    })
}

// Удаление продукта
removeProduct = async (flowerPK) => {
    let oldImages = await pool.query(`SELECT * FROM images WHERE PK_Flowers=${flowerPK}`);
    oldImages = oldImages[0];
    oldImages.forEach((oldImage) => {
        fs.unlinkSync(__dirname + '\\images\\' + oldImage.url);
    })

    await pool.query(`DELETE FROM images WHERE PK_Flowers=${flowerPK}`);

    await pool.query(`DELETE FROM flower_condition WHERE PK_Flowers=${flowerPK}`);

    await pool.query(`DELETE FROM \`order\` WHERE PK_Flowers=${flowerPK}`);

    await pool.query(`DELETE FROM flowers WHERE PK_Flowers=${flowerPK}`);
}

// Создание заказа
addOrder = async (data) => {
    await pool.query(`
        INSERT INTO \`order\` (name, number, PK_Flowers) VALUES ('${data.name}', '${data.phone}', ${data.PK_Flowers})
    `);
}

module.exports = {selectAllFromTable, createProduct, selectFromTable, removeProduct, editProduct, addOrder};