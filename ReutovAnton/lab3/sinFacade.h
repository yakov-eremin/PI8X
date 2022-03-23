using namespace std;

/*!
\brief Класс фасада, с которым работает клиент. 

\details Позволяет обращаться через единый интерфейс к методам двух классов:
- rivWatch - класс системы кратковременного прогнозирования наводнений на участке реки.
- countersFactory - класс для создания фабрики счетчиков измерения. 
*/

class Facade {
public:
	countersFactory *rivCounts;
	rivWatch *rivParams;
	Facade()
	{
		rivCounts = new countersFactory();
	}
	/*!
	Инициализирует объект класса rivWatch.
	\param a Площадь участка реки.
	\param b Скорость реки на участке.
	\param c Время расчета.
	*/
	void facadeW(float a, float b, int c) 
	{
		rivParams = new rivWatch(a, b, c);
	}
	/*!
	Обращается к методу creati класса countersFactory для создания нового счетчика.
	\param nameCount[] Наименование счетчика.
	\param type[] Тип счетчика (снег, лед, погода).
	\param number Номер счетчика.
	\param atm Среднее атмосферное давление на участке.
	\param temp Средняя температура воздуха на участке.
	*/
	void creati(char nameCount[], char type[], int number, int atm, float temp)
	{
		rivCounts->creati(nameCount, type, number, atm, temp);
	}
	/*!
	Обращается к методу Consumption класса rivWatch для анализа расхода воды за определенный промежуток времени.
	*/
	void Consumption()
	{
		rivParams->Consumption();
	}
	/*!
	Обращается к методу pConsumption класса rivWatch для анализа расхода воды за определенный промежуток времени для прокси-наблюдателя.
	*/
	void pConsumption()
	{
		rivParams->pConsumption();
	}
};

/*!
\brief Класс главной реки.

Данный класс задает объект главной реки, с которым впоследствии работают все остальные классы программы. 
Так как используется паттерн Singleton, то объект является единственным.

![Мост через реку Обь](1.bmp)
*/

class mainRiver {
private:
	static mainRiver* instance;
	mainRiver(int data) {}
	mainRiver() {}
public:
	static mainRiver* Instance(int data);
	static mainRiver* Instance();
	Facade *eski;
};
mainRiver* mainRiver::instance = nullptr;
/*!
Создает объект класса mainRiver, инициализируя его определенным номером data при необходимости. Если объект уже существует, то выдается уведомление о невозможности создания.
\param nameCount[] Номер объекта класса.
*/
mainRiver* mainRiver::Instance(int data) {
	if (instance == 0) {
		instance = new mainRiver(data);
	}
	else
		printf("Главная река уже задана!\n");
	return instance;
}
mainRiver* mainRiver::Instance() {
	if (instance == 0) {
		instance = new mainRiver();
	}
	else
		printf("Главная река уже задана!\n");
	return instance;
}


