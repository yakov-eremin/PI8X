const Query = require('./query');
it('select flower name by price', async () => {
    var expectedResult = [{name: 'Эхинокактус Грузона'}];
    const result = await Query.selectFromTable("flowers", "name", "price=7700");
    if (JSON.stringify(expectedResult) !== JSON.stringify(result)) {
        throw new Error(
            `Expected ${JSON.stringify(expectedResult)}, but got ${JSON.stringify(result)}`
        )
    }
});

it('select flower by name', async () => {
    var expectedResult = [
        {
            "PK_Flowers":12,
            "name":"Эхинокактус Грузона",
            "price":7700,
            "description":"Растение, распространённое в Мексике; популярное комнатное растение.",
            "PK_Genus":3,
            "PK_Decoratives":3,
            "PK_Shoots":1,
            "PK_Window":1
        }
    ];
    const result = await Query.selectFromTable("flowers", "*", `name="Эхинокактус Грузона"`);
    if (JSON.stringify(expectedResult) !== JSON.stringify(result)) {
        throw new Error(
            `Expected ${JSON.stringify(expectedResult)}, but got ${JSON.stringify(result)}`
        )
    }
});

it('select all names from conditions', async () => {
    var expectedResult = [
        {"name":"Теневыносливые"},
        {"name":"Светолюбивые"},
        {"name":"Влаголюбивые"},
        {"name":"Засухоустойчивые"}
    ];
    const result = await Query.selectFromTable("conditions", "name");
    if (JSON.stringify(expectedResult) !== JSON.stringify(result)) {
        throw new Error(
            `Expected ${JSON.stringify(expectedResult)}, but got ${JSON.stringify(result)}`
        )
    }
});

it('select all names from window', async () => {
    var expectedResult = [{"name":"Западное"},{"name":"Восточное"}];
    const result = await Query.selectFromTable("window", "name");
    if (JSON.stringify(expectedResult) !== JSON.stringify(result)) {
        throw new Error(
            `Expected ${JSON.stringify(expectedResult)}, but got ${JSON.stringify(result)}`
        )
    }
});

it('select all names from family', async () => {
    var expectedResult = [{"name":"Ароидные"},{"name":"Новое семейство"},{"name":"Кактусовые"}];
    const result = await Query.selectFromTable("family", "name");
    if (JSON.stringify(expectedResult) !== JSON.stringify(result)) {
        throw new Error(
            `Expected ${JSON.stringify(expectedResult)}, but got ${JSON.stringify(result)}`
        )
    }
});

it('select all names from decoratives', async () => {
    var expectedResult = [{"name":"Лиственные"},{"name":"Цветущие"},{"name":"Суккуленты"},{"name":"Кактусы"}];
    const result = await Query.selectFromTable("decoratives", "name");
    if (JSON.stringify(expectedResult) !== JSON.stringify(result)) {
        throw new Error(
            `Expected ${JSON.stringify(expectedResult)}, but got ${JSON.stringify(result)}`
        )
    }
});

it('select all names from genus', async () => {
    var expectedResult = [{"name":"Замиокулькас"},{"name":"Новый род"},{"name":"Эхинокактус"}];
    const result = await Query.selectFromTable("genus", "name");
    if (JSON.stringify(expectedResult) !== JSON.stringify(result)) {
        throw new Error(
            `Expected ${JSON.stringify(expectedResult)}, but got ${JSON.stringify(result)}`
        )
    }
});

it('select all urls from images', async () => {
    var expectedResult =  [{"url":"img1-1647248337697.jpg"},{"url":"img2-1647248337698.jpg"},{"url":"img3-1647248337701.jpg"}];
    const result = await Query.selectFromTable("images", "url");
    if (JSON.stringify(expectedResult) !== JSON.stringify(result)) {
        throw new Error(
            `Expected ${JSON.stringify(expectedResult)}, but got ${JSON.stringify(result)}`
        )
    }
});

it('select all names, phones from order', async () => {
    var expectedResult = [];
    const result = await Query.selectFromTable("\`order\`", "name, number");
    if (JSON.stringify(expectedResult) !== JSON.stringify(result)) {
        throw new Error(
            `Expected ${JSON.stringify(expectedResult)}, but got ${JSON.stringify(result)}`
        )
    }
});

it('select all names from shoots', async () => {
    var expectedResult = [{"name":"Прямостоячие"},{"name":"Вьющиеся"},{"name":"Кустовидные"},{"name":"Розетки"}];
    const result = await Query.selectFromTable("shoots", "name");
    if (JSON.stringify(expectedResult) !== JSON.stringify(result)) {
        throw new Error(
            `Expected ${JSON.stringify(expectedResult)}, but got ${JSON.stringify(result)}`
        )
    }
});