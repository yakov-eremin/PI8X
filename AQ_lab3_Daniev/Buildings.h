#pragma once
#include "SFML/Graphics.hpp"
#include "Resource.h"

using namespace sf;
using namespace std;

class Building : public Drawable 
{
public:
	Building(float _x, float _y, Resource *Res, Resource *Cons);
	float getX();
	float getY();
	FloatRect Square();
	wstring GetName();
	void update();
	bool IsMaxWorkers();
	bool IsNoWorkers();
	virtual bool Destroy();
	void AddWorkers(int count);
	int GetWorkers();
	int GetMaxWorkers();
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

	//Методы работы.
	virtual void Working() = 0; //Чисто виртуальная функция, описывающая работу типа постройки.
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
	virtual void draw(RenderTarget &target, RenderStates states) const;
};

//Новый тип зданий наследуется от общего класса.
//Класс главного здания.
class BaseBuilding : public Building
{
public:	
	virtual void Production();
	virtual bool Destroy();
	virtual int GetSpecial();
	BaseBuilding(float _x, float _y, Resource *Res, Resource *Cons);
	BaseBuilding(int _x, int _y, Resource *Res, Resource *Cons);
	int GetColonyLevel();
private:
	virtual void Working();
	int ColonyLevel;//Уровень колонии.
};

class SmallHouse : public Building
{
public:
	virtual void Production();
	virtual bool Destroy();
	virtual int GetSpecial();
	SmallHouse(int _x, int _y, Resource *Res, Resource *Cons);
private:
	virtual void Working();
	int CountOfWorkers;
};

class IronOreMiner : public Building
{
public:
	virtual void Production();
	virtual int GetSpecial();
	IronOreMiner(int _x, int _y, Resource *Res, Resource *Cons);
private:
	virtual void Working();
	int OreAmount;//Количество руды в данном источнике.
};