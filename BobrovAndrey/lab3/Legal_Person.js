import {Person} from "./Person.js";
/**
 * Класс юридического лица
 * @class
 * @augments Person
 * @param {string} name - Имя персоны
 * @param {string} email - почта персоны
 * @param {string} phone - телефон персоны
 * @param {string} cnpj - идентификатор налогоплательщика - юридического лица
 */
export class Legal_Person extends Person{

	constructor(name, email, phone, cnpj){
		super(name, email, phone);
		this.cnpj = cnpj;
	}

	/**
	 * Создает новое юридическое лицо
	 * @function
	 */
	createPerson(){
		alert("Legal entity created");
	}

	/**
	 * Получает CNPJ идентификатор юридического лица
	 * @function
	 */
	getId(){
		return this.cnpj;
	}
} 