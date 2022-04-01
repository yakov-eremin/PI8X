/**
 * Класс человека
 * @class
 * @param {string} name - Имя персоны
 * @param {string} email - почта персоны
 * @param {string} phone - телефон персоны
 */
export class Person{

	constructor(name, email, phone){
		this.name = name;
		this.email = email;
		this.phone = phone;
		this.createPerson();
	}

	/**
	 * Возвращает имя персоны
	 * @public
	 * @function
	 */
	getName(){
		return this.name;
	}

	/**
	 * Возвращает email персоны
	 * @public
	 * @function
	 */
	getEmail(){
		return this.email;
	}

	/**
	 * Возвращает телефон персоны
	 * @public
	 * @function
	 */
	getPhone(){
		return this.phone;
	}	

	/**
	 * Создает персону
	 * @public
	 * @function
	 */
	createPerson(){
		alert("Person created");
	}
}