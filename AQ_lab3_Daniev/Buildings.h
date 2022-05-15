#pragma once
#include "SFML/Graphics.hpp"
#include "Resource.h"

using namespace sf;
using namespace std;

/*!
	\brief Класс здания
	\details Класс содержит методы координат здания, площади, названием, усовершенствование, колиечечтва работников, уничтожения, добавдения работников, продукции

*/

class Building : public Drawable 
{
public:
	/*!
		\brief метод постройки здания по координатам
	*/

	Building(float _x, float _y, Resource *Res, Resource *Cons);
	/*!
		\brief метод координаты X и Y
	*/

	float getX();
	float getY();

	/*!
		\brief метод площади
	*/
	FloatRect Square();
	/*!
		\brief метод названия
	*/
	wstring GetName();
	/*!
		\brief метод метод усовершенствования
	*/
	void update();
	/*!
		\brief метод максимального количества работников
	*/
	bool IsMaxWorkers();
	/*!
		\brief метод отсутствия работников
	*/
	bool IsNoWorkers();
	/*!
		\brief метод изношенности
	*/
	virtual bool Destroy();
	/*!
		\brief метод добавления работников
	*/
	void AddWorkers(int count);
	/*!
		\brief метод получения работников
	*/
	int GetWorkers();
	/*!
		\brief метод увеличения максисума работников
	*/
	int GetMaxWorkers();
	/*!
		\brief методы ресурсов
	*/
	virtual int GetSpecial() = 0;
	virtual void Production() = 0;
protected:
	int State; //Содержит состояние постройки, 0 - здание строиться, 1 - здание построено и работает.

	//Характеристики.
	wstring Name;
	int Health;//Прочность постройки.
	int MaxHealth;//Максимальная прочность постройки.
	int workers;//Количество работников в текущий момент.
	int MaxWorkers;//Максимальное количество работников.
	Resource *WorkResource; //Указатель на ресурс, который производит здание.
	Resource *ConsumedResource;//Указатель на ресурс, который здание потребляет при работе.

	/*!
		\brief метод работы
	*/
	virtual void Working() = 0; //Чисто виртуальная функция, описывающая работу типа постройки.
	/*!
		\brief метод постройки или починки
	*/
	void build();//Режим постройки или починки здания.

	//Для отрисовки.
	float x;
	float y;
	float width;
	float height;
	Texture DestroyTexture;
	Texture BuildTexture;
	Texture TextureIsBuild;
	VertexArray VerticesBuild;
	/*!
		\brief метод отрисовки
	*/
	virtual void draw(RenderTarget &target, RenderStates states) const;
};

/*!
	\brief Класс главного здания
	\details Класс содержит методы продукции, разрушаемости, расположения, уровня, работы

*/
class BaseBuilding : public Building
{
public:	
	/*!
		\brief метод продукции
	*/
	virtual void Production();
	/*!
		\brief метод разрушения
	*/
	virtual bool Destroy();
	
	virtual int GetSpecial();
	/*!
		\brief метод расположения
	*/
	BaseBuilding(float _x, float _y, Resource *Res, Resource *Cons);
	BaseBuilding(int _x, int _y, Resource *Res, Resource *Cons);
	/*!
		\brief метод уровня
	*/
	int GetColonyLevel();
private:
	virtual void Working();
	int ColonyLevel;//Уровень колонии.
};

/*!
	\brief Класс малого здания
	\details Класс содержит методы продукции, разрушаемости, расположения, работы

*/

class SmallHouse : public Building
{
public:
	/*!
		\brief метод продукции
	*/
	virtual void Production();
	/*!
		\brief метод разрушения
	*/
	virtual bool Destroy();
	virtual int GetSpecial();
	/*!
		\brief метод расположения
	*/
	SmallHouse(int _x, int _y, Resource *Res, Resource *Cons);
private:
	/*!
		\brief метод уровня
	*/
	virtual void Working();
	int CountOfWorkers;
};

/*!
	\brief Класс главного здания
	\details Класс содержит методы продукции, расположения, работы

*/

class IronOreMiner : public Building
{
public:
	/*!
		\brief метод продукции
	*/
	virtual void Production();
	virtual int GetSpecial();
	/*!
		\brief метод расположения
	*/
	IronOreMiner(int _x, int _y, Resource *Res, Resource *Cons);
private:
	/*!
		\brief метод уровня
	*/
	virtual void Working();
	int OreAmount;//Количество руды в данном источнике.
};