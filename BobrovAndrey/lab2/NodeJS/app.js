const express = require('express')
const path = require('path');
const app = express()
const port = 3000
const Query = require('./query');
const multer  = require('multer')

// Указываем директорию для хранения загружаемых изображений
const storage = multer.diskStorage({
    destination: function (req, file, cb) {
        cb(null, 'images/')
    },
    filename: function (req, file, cb) {
        cb(null, file.fieldname + '-' + Date.now() + '.jpg')
    }
})
const upload = multer({ storage: storage })

// Настраиваем шаблонизатор ejs
app.set("views", path.join(__dirname, "views"))
app.set("view engine", "ejs")

// to support JSON-encoded bodies
app.use(express.json());       
// to support URL-encoded bodies
app.use(express.urlencoded()); 

// Указываем путь к статическим css и js файлам
app.use('/static', express.static(__dirname + '/static'));

// Указываем путь к изображениям
app.use('/images', express.static(__dirname + '/images'));

// рендер всех растений
app.get('/', async (req, res) => {
    let flowers = await Query.selectAllFromTable("flowers");
    for (const flower of flowers) {
        let imageUrl = await selectFromTable("images", "url", `PK_Flowers=${flower.PK_Flowers}`)
        if(imageUrl.length) {
            imageUrl = imageUrl[0].url;
            flower.img = imageUrl;
        }
        else {
            flower.img = "noImage.png"
        }
    }
    let decoratives = await Query.selectAllFromTable("decoratives");
    res.render("index", {
        flowers,
        decoratives
    });
})

// рендер растений конкретного типа
app.get('/decoratives/:decorativesId', async (req, res) => {
    let flowers = await Query.selectFromTable("flowers", "*", `PK_Decoratives=${req.params.decorativesId}`)
    for (const flower of flowers) {
        let imageUrl = await selectFromTable("images", "url", `PK_Flowers=${flower.PK_Flowers}`)
        
        if(imageUrl.length) {
            imageUrl = imageUrl[0].url;
            flower.img = imageUrl;
        }
        else {
            flower.img = "noImage.png"
        }
    }
    let decoratives = await Query.selectAllFromTable("decoratives");
    res.render("index", {
        flowers,
        decoratives
    });
})

// рендер конкретного растения по id
app.get('/product/:id', async (req, res) => {
    // Получаем растение по id
    let flower = await selectFromTable("flowers", "*", `PK_Flowers=${req.params.id}`)
    if(flower.length) {
        flower = flower[0]
    }
    else {
        res.redirect('/')
    }

    // Получаем изображения для этого растения
    let images = await selectFromTable("images", "url", `PK_Flowers=${flower.PK_Flowers}`)
    flower.imgList = [];
    if(images.length) {
        images.forEach((image) => {
            flower.imgList.push(image.url);
        });
    }
    else {
        flower.imgList.push("noImage.png")
    }
    

    // Получаем остальные данные
    let genus = await selectFromTable("genus", "*", `PK_Genus=${flower.PK_Genus}`)
    let PK_Genus = null;
    if(genus.length) {
        PK_Genus = genus[0].PK_Genus
        genus = genus[0].name
    }
    else {
        genus = ""
    }

    let family = await selectFromTable("family", "name", `PK_Family=${PK_Genus}`)
    if(family.length) {
        family = family[0].name
    }
    else {
        family = ""
    }

    let shoots = await selectFromTable("shoots", "name", `PK_Shoots=${flower.PK_Shoots}`)
    if(shoots.length) {
        shoots = shoots[0].name
    }
    else {
        shoots = ""
    }

    let window = await selectFromTable("window", "name", `PK_Window=${flower.PK_Window}`)
    if(window.length) {
        window = window[0].name
    }
    else {
        window = ""
    }

    let decorativesProduct = await selectFromTable("decoratives", "name", `PK_Decoratives=${flower.PK_Decoratives}`)
    if(decorativesProduct.length) {
        decorativesProduct = decorativesProduct[0].name
    }
    else {
        decorativesProduct = ""
    }

    let conditionsId = await selectFromTable("flower_condition", "PK_Conditions", `PK_Flowers=${flower.PK_Flowers}`)
    let conditions = [];
    conditionsId.forEach(async (conditionId) => {
        let temp = await selectFromTable("conditions", "name", `PK_Conditions=${conditionId.PK_Conditions}`)
        if(temp.length) {
            conditions.push(temp[0].name);
        }
    })
    
    let decoratives = await Query.selectAllFromTable("decoratives");
    res.render("product", {
        decoratives,
        flower,
        family,
        genus,
        shoots,
        window,
        conditions,
        decorativesProduct
    });
})

// рендер страницы создания нового растения
app.get('/edit', async (req, res) => {
    let family = await Query.selectAllFromTable("family");
    let genus = await Query.selectAllFromTable("genus");
    let conditions = await Query.selectAllFromTable("conditions");
    let shoots = await Query.selectAllFromTable("shoots");
    let decoratives = await Query.selectAllFromTable("decoratives");
    let window = await Query.selectAllFromTable("window");
    res.render("edit", {
        family,
        genus,
        conditions,
        shoots,
        decoratives,
        window,
        flower: null
    });
})

// рендер страницы редактирования старого растения
app.get('/edit/:id', async (req, res) => {
    // Получаем растение по id
    let flower = await selectFromTable("flowers", "*", `PK_Flowers=${req.params.id}`)
    if(flower.length) {
        flower = flower[0]
    }
    else {
        res.redirect('/')
    }

    // Получаем изображения для этого растения
    let images = await selectFromTable("images", "url", `PK_Flowers=${flower.PK_Flowers}`)
    flower.imgList = [];
    if(images.length) {
        images.forEach((image) => {
            flower.imgList.push(image.url);
        });
    }
    else {
        flower.imgList.push("noImage.png")
    }
    

    let genusProduct = await selectFromTable("genus", "*", `PK_Genus=${flower.PK_Genus}`)
    let PK_Genus = null;
    if(genusProduct.length) {
        PK_Genus = genusProduct[0].PK_Genus
        genusProduct = genusProduct[0].name
    }
    else {
        genusProduct = ""
    }

    let familyProduct = await selectFromTable("family", "name", `PK_Family=${PK_Genus}`)
    if(familyProduct.length) {
        familyProduct = familyProduct[0].name
    }
    else {
        familyProduct = ""
    }

    let shootsProduct = await selectFromTable("shoots", "name", `PK_Shoots=${flower.PK_Shoots}`)
    if(shootsProduct.length) {
        shootsProduct = shootsProduct[0].name
    }
    else {
        shootsProduct = ""
    }

    let windowProduct = await selectFromTable("window", "name", `PK_Window=${flower.PK_Window}`)
    if(windowProduct.length) {
        windowProduct = windowProduct[0].name
    }
    else {
        windowProduct = ""
    }

    let decorativesProduct = await selectFromTable("decoratives", "name", `PK_Decoratives=${flower.PK_Decoratives}`)
    if(decorativesProduct.length) {
        decorativesProduct = decorativesProduct[0].name
    }
    else {
        decorativesProduct = ""
    }

    let conditionsId = await selectFromTable("flower_condition", "PK_Conditions", `PK_Flowers=${flower.PK_Flowers}`)
    let conditionsProduct = [];
    conditionsId.forEach(async (conditionId) => {
        let temp = await selectFromTable("conditions", "name", `PK_Conditions=${conditionId.PK_Conditions}`)
        if(temp.length) {
            conditionsProduct.push(temp[0].name);
        }
    })
    
    let family = await Query.selectAllFromTable("family");
    let genus = await Query.selectAllFromTable("genus");
    let conditions = await Query.selectAllFromTable("conditions");
    let shoots = await Query.selectAllFromTable("shoots");
    let decoratives = await Query.selectAllFromTable("decoratives");
    let window = await Query.selectAllFromTable("window");
    res.render("edit", {
        decoratives,
        family,
        genus,
        conditions,
        shoots,
        decoratives,
        window,
        flower,
        familyProduct,
        genusProduct,
        shootsProduct,
        windowProduct,
        conditionsProduct,
        decorativesProduct
    });
})

// рендер Админ-панели
app.get('/admin', async (req, res) => {
    let flowers = await Query.selectAllFromTable("flowers");
    for (const flower of flowers) {
        let imageUrl = await selectFromTable("images", "url", `PK_Flowers=${flower.PK_Flowers}`)
        if(imageUrl.length) {
            imageUrl = imageUrl[0].url;
            flower.img = imageUrl;
        }
        else {
            flower.img = "noImage.png"
        }
    }
    let decoratives = await Query.selectAllFromTable("decoratives");
    res.render("admin", {
        flowers,
        decoratives
    });
})

// Создаем новое растение
app.post('/create', upload.any('photos', 12), async (req, res) => {
    await Query.createProduct(req.body, req.files)
    res.redirect('/admin')
})

// Редактируем старое растение
app.post('/change/:id', upload.any('photos', 12), async (req, res) => {
    await Query.editProduct(req.body, req.files, req.params.id)
    res.redirect('/admin')
})

// Удаляем растение по id
app.get('/remove/:id', async (req, res) => {
    await Query.removeProduct(req.params.id)
    res.redirect('/admin')
})

// Создаем заказ
app.post('/order', async (req, res) => {
    backURL=req.header('Referer') || '/';
    await Query.addOrder(req.body)
    res.redirect(backURL)
})

// Слушаем порт для локального сервера
app.listen(port, () => {
    console.log("server started on ", port);
})