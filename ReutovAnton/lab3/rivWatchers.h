/*!
\brief Класс наблюдателя.

\details Позволяет рассчитывать расход воды на участке реки за определенный промежуток времени по формуле \f$Cont=square*speed*time\f$.
*/

class rivWatcher {
public:
	float square;
	float speed;
	float time;
	float cont;
	/*!
	Инициализация объекта класса значениями a, b и с.
	\param a Площадь участка реки.
	\param b Скорость реки на участке.
	\param c Время расчета.
	*/
	void initWatcher (float a, float b, float c)
	{
		square = a;
		speed = b;
		time = c;
	}
	/*!
	Расчет расхода воды.
	\return Расход воды на участке реки за определенный промежуток времени.
	*/
	void Consumption()
	{
		cont = square * speed * time;
	}
};
/*!
\brief Класс прокси-наблюдателя.

\details Более безопасный расчет расхода воды на участке реки. При необходимости делегирует расчеты в методы класса rivWatcher.
*/
class proxyWatcher {
public:
	rivWatcher *ras;
	/*!
	Вызывает метод Consumption экземпляра класса rivWatcher (ras) для расчета расхода воды на участке реки.
	*/
	void Consumption()
	{
		ras->Consumption();
	}
	/*!
	Создает экземпляр класса rivWatcher и инициализирует его.
	\param a Площадь участка реки.
	\param b Скорость реки на участке.
	\param c Время расчета.
	*/
	proxyWatcher(float a, float b, float c)
	{
		ras = new rivWatcher();
		ras->initWatcher(a, b, c);
	}
};
/*!
\brief Класс системы кратковременного прогнозирования наводнений на участке реки.

\details Абстракция, через которую клиент обращается к двум реализациям – наблюдателю rivWatcher и прокси-наблюдателю proxyWatcher. 
*/
class rivWatch {
public:
	rivWatcher *watchi;
	proxyWatcher *pwatchi;
	/*!
	Создает объекты класса наблюдателя (rivWatcher) и прокси-наблюдателя (proxyWatсher), а также инициализирует их.
	\param a Площадь участка реки.
	\param b Скорость реки на участке.
	\param c Время расчета.
	*/
	rivWatch(float a, float b, float c)
	{
		watchi = new rivWatcher();
		watchi->initWatcher(a, b, c);
		pwatchi = new proxyWatcher(a, b, c);
	}
	/*!
	Обращается к методу Consumption класса rivWatcher для анализа расхода воды за определенный промежуток времени.
	*/
	void Consumption()
	{
		watchi->Consumption();
	}
	/*!
	Обращается к методу pConsumption класса proxyWatcher для анализа расхода воды за определенный промежуток времени для прокси-наблюдателя.
	*/
	void pConsumption()
	{
		pwatchi->Consumption();
	}
};
