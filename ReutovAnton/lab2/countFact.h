#include "string.h"
#include <iostream>
#include <map>
FILE *ved = fopen("log.txt", "w");
FILE *cole = fopen("counters.txt", "w");

using namespace std;
/*!
\brief Класс расчета полей температуры и атмосферного давления.

\details Рассчитывает поля температуры и атмосферного давления на заданный срок.
*/
class metFields {  
private:
	float time;
	float wind;
	float tempView;
public:
	/*!
	Инициализирует время, скорость ветра и температуру по направлению ветра.
	\param t Время, для которого производится расчет.
	\param w Скорость ветра.
	\param tw Температура по направлению ветра (необходима для расчета температурных полей).
	*/
	void setParams(float t, float w, float tw)
	{
		time = t;
		wind = w;
		tempView = tw;
	}
	/*!
	\return Время, для которого производится расчет.
	*/
	float getTime()
	{
		return time;
	}
	/*!
	\return Скорость ветра.
	*/
	float getWind()
	{
		return wind;
	}
	/*!
	\return Температура по направлению ветра (необходима для расчета температурных полей).
	*/
	float getTempView()
	{
		return tempView;
	}
	/*!
	Рассчитывает поле атмосферного давления.
	\param atm Начальное атмосферное давление на участке.
	\param temp Начальная температура на участке.
	\return Поле давления на заданный срок.
	*/
	float atFieldCount(int atm, float temp)
	{
		return atm - 0.05 * ((tempView + wind)/time);
	}
	/*!
	Рассчитывает поле температуры.
		\param atm Начальное атмосферное давление на участке.
		\param temp Начальная температура на участке.
		\return Поле температуры на заданный срок.
	*/
	float tempFieldCount(int atm, float temp)
	{
		return temp + 0.05 * (temp - tempView)/time;
	}
};

/*!
\brief Общий класс счетчиков участков.

\details От metCounter наследуются остальные классы счетчиков (снега, льда и погоды), они же берут отсюда общие данные по температуре и атмосферному давлению.
*/

class metCounter {
public:
	char *name = new char[];
	char *type = new char[];
	int number;
public:
	metFields *fieldWay;
	metCounter()
	{
		fieldWay = new metFields();
	}
	int atm;
	int temp;
	/*!
	Инициализирует имя, тип и номер счетчика.
	\param *nm Наименование счетчика.
	\param *tp Тип счетчика (снег, лед, погода).
	\param num Номер счетчика.
	*/
	void initM(char *nm, char *tp, int num)
	{
		name = nm;
		type = tp;
		number = num;
	}
	/*!
	\return Наименование счетчика.
	*/
	char *getName()
	{
		return name;
	}
	/*!
	\return Тип счетчика.
	*/
	char *getType()
	{
		return type;
	}
	/*!
	Инициализирует атмосферное давление и температуру для счетчика на участке.
	\param a Среднее атмосферное давление на участке.
	\param b Средняя температура воздуха на участке.
	*/
	void init(int a, int b)
	{
		atm = a;
		temp = b;
	}
	/*!
	Ничего не делает в основном классе, проявляется в дочерних.
	*/
	void meteoCount();
};
/*!
\brief Класс счетчиков погоды.

\details Рассчитывает циклоны, скорость ветра, осадки.
*/
class weatherCounter : public metCounter {
public:
	float ets;
	/*!
	Рассчитывает погодные условия на основании атрибутов температуры и атмосферного давления от metCounter.
	*/
	void meteoCount()
	{
		ets = atm * temp;
	}
};
/*!
\brief Класс дополнительных снеговых событий на участке

\details Рассчитывает вероятность наступления паводка.
*/
class highWaters {
private:
	float time;
public:
	/*!
	Инициализирует время расчета.
	\param t Время расчета на участке.
	*/
	void setTime(float t)
	{
		time = t;
	}
	/*!
	Возвращает время расчета.
	\return t Время расчета на участке.
	*/
	float getTime()
	{
		return time;
	}
	/*!
	Рассчитывает вероятность наступления паводка.
	\return t Вероятность паводка.
	*/
	float highWatersEvents(float square, float width, float density, float drain, float atm, float temp)
	{
		float a = (atm + temp + width) * time / 2 * (square + density + drain);
		return a;
	}
};
/*!
\brief Класс счетчиков снега.

\details Рассчитывает стоки снега на участке в реку и в грунтовые воды.
*/
class snowCounter : public metCounter {
private:
	float square;
	float width;
	float density;
	float drainSquare;
public:
	highWaters *higher;
	float res;
	snowCounter()
	{
		higher = new highWaters();
	}
	/*!
	Инициализирует параметры счетчика снега на участке.
	\param square Площадь снежного покрова.
	\param width Толщина снежного покрова.
	\param density Средняя плотность снежного покрова.
	\param drainSquare Площадь стоков снега.
	*/
	void setParams(float sq, float wi, float de, float dr)
	{
		square = sq;
		width = wi;
		density = de;
		drainSquare = dr;
	}
	/*!
	Рассчитывает стоки снега на участке.
	*/
	void meteoCount()
	{
		res = (square + width + density) * (drainSquare + atm - temp);
	}
};
/*!
\brief Класс дополнительных ледовых событий на участке

\details Рассчитывает события во время весеннего ледохода: заторы, зажоры, вероятность наводнения.
*/
class highIcers {
private:
	float square;
	float density;
public:
	/*!
	Инициализирует параметры ледяного покрова на участке.
	\param sq Площадь ледяного покрова.
	\param de Плотность ледяного покрова.
	*/
	void setIceParams(float sq, float de)
	{
		square = sq;
		density = de;
	}
	/*!
	Рассчитывает события во время весеннего ледохода.
	\return Вероятность наводнения на участке.
	*/
	float setJamEvents(float atm, float temp, float width)
	{
		float a = (atm + temp + width) / (square + density);
		return a;
	}
};
/*!
\brief Класс счетчиков льда.

\details Рассчитывает время слома льда на участке весной или полной заморозки участка зимой.
*/
class iceCounter : public metCounter {
private:
	float width;
public:
	highIcers *icer;
	float res;
	iceCounter()
	{
		icer = new highIcers();
	}
	/*!
	Инициализирует толщину ледяного покрова.
	\param width Толщина ледяного покрова.
	*/
	void setWidth(float w)
	{
		width = w;
	}
	/*!
	Возвращает толщину ледяного покрова.
	\return width Толщина ледяного покрова.
	*/
	float getWidth()
	{
		return width;
	}
	/*!
    Рассчитывает время слома льда на участке весной или полной заморозки участка зимой.
	*/
	void meteoCount()
	{
		res = width * (atm / abs(temp)) / 10;
	}
};

/*!
\brief Класс для создания фабрики счетчиков измерения.

\details Создает счетчики снега, льда или погоды на участке, которые в дальнейшем используются для расчетов параметров участков рядом с рекой и долговременных расчетов возможного наводнения. Хранит все созданные счетчики в контейнере avgRiv.
*/

class countersFactory {  
public:
	typedef std::map<int, metCounter*> counters;
	counters avgRiv;
	countersFactory() {};
	/*!
	Создает счетчик снега, льда или погоды с заданными параметрами, после чего инициализирует его и добавляет в общий контейнер avgRiv.
	Также выводит уведомление о создании счетчика в отдельный файл и увеличивает текущее число счетчиков в avgRiv на 1.
	\param nameCount[] Наименование счетчика.
	\param type[] Тип счетчика (снег, лед, погода).
	\param number Номер счетчика.
	\param atm Среднее атмосферное давление на участке.
	\param temp Средняя температура воздуха на участке.
	*/
	void creati(char nameCount[], char type[], int number, int atm, int temp)
	{
		metCounter* count = new metCounter();
		if (strcmp(type, "Снег") == 0)
		{
			count = new snowCounter;
			fprintf(ved, "Создан новый счетчик снега.\n");
			fprintf(cole, "%i %s %s %i %i\n", number, nameCount, type, atm, temp);
		}
		else if (strcmp(type, "Лед") == 0)
		{
			count = new iceCounter;
			fprintf(ved, "Создан новый счетчик льда.\n");
			fprintf(cole, "%i %s %s %i %i\n", number, nameCount, type, atm, temp);
		}
		else if (strcmp(type, "Погода") == 0)
		{
			count = new weatherCounter;
			fprintf(ved, "Создан новый счетчик погоды.\n");
			fprintf(cole, "%i %s %s %i %i\n", number, nameCount, type, atm, temp);
		}
		count->initM(nameCount, type, number);
		count->init(atm, temp);
		avgRiv[number] = count;
	}
};
