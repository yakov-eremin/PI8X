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
	int State; //�������� ��������� ���������, 0 - ������ ���������, 1 - ������ ��������� � ��������.

	//��������������.
	wstring Name;
	int Health;//��������� ���������.
	int MaxHealth;//������������ ��������� ���������.
	int workers;//���������� ���������� � ������� ������.
	int MaxWorkers;//������������ ���������� ����������.
	Resource *WorkResource; //��������� �� ������, ������� ���������� ������.
	Resource *ConsumedResource;//��������� �� ������, ������� ������ ���������� ��� ������.

	//������ ������.
	virtual void Working() = 0; //����� ����������� �������, ����������� ������ ���� ���������.
	void build();//����� ��������� ��� ������� ������.

	//��� ���������.
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

//����� ��� ������ ����������� �� ������ ������.
//����� �������� ������.
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
	int ColonyLevel;//������� �������.
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
	int OreAmount;//���������� ���� � ������ ���������.
};