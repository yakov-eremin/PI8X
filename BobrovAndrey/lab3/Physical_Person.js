import {Person} from "./Person.js";
/**
 * Класс физического лица
 * @class
 * @augments Person
 * @param {string} name - Имя персоны
 * @param {string} email - почта персоны
 * @param {string} phone - телефон персоны
 * @param {string} cpf - идентификатор налогоплательщика - физического лица
 */
export class Physical_Person extends Person{
	
	constructor(name, email, phone, cpf){
		super(name, email, phone);
		this.cpf = cpf;
	}

	/**
	 * Создает физическое лицо
	 * @function
	 */
	createPerson(){
		alert("Individual created");
	}

	/**
	 * Получает cpf идентификатор физического лица
	 * @function
	 */
	getId(){
		return this.cpf;
	}
}