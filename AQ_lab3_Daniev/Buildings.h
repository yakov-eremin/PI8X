#pragma once
#include "SFML/Graphics.hpp"
#include "Resource.h"

using namespace sf;
using namespace std;

/*!
	\brief ����� ������
	\details ����� �������� ������ ��������� ������, �������, ���������, ������������������, ����������� ����������, �����������, ���������� ����������, ���������

*/

class Building : public Drawable 
{
public:
	/*!
		\brief ����� ��������� ������ �� �����������
	*/

	Building(float _x, float _y, Resource *Res, Resource *Cons);
	/*!
		\brief ����� ���������� X � Y
	*/

	float getX();
	float getY();

	/*!
		\brief ����� �������
	*/
	FloatRect Square();
	/*!
		\brief ����� ��������
	*/
	wstring GetName();
	/*!
		\brief ����� ����� ������������������
	*/
	void update();
	/*!
		\brief ����� ������������� ���������� ����������
	*/
	bool IsMaxWorkers();
	/*!
		\brief ����� ���������� ����������
	*/
	bool IsNoWorkers();
	/*!
		\brief ����� ������������
	*/
	virtual bool Destroy();
	/*!
		\brief ����� ���������� ����������
	*/
	void AddWorkers(int count);
	/*!
		\brief ����� ��������� ����������
	*/
	int GetWorkers();
	/*!
		\brief ����� ���������� ��������� ����������
	*/
	int GetMaxWorkers();
	/*!
		\brief ������ ��������
	*/
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

	/*!
		\brief ����� ������
	*/
	virtual void Working() = 0; //����� ����������� �������, ����������� ������ ���� ���������.
	/*!
		\brief ����� ��������� ��� �������
	*/
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
	/*!
		\brief ����� ���������
	*/
	virtual void draw(RenderTarget &target, RenderStates states) const;
};

/*!
	\brief ����� �������� ������
	\details ����� �������� ������ ���������, �������������, ������������, ������, ������

*/
class BaseBuilding : public Building
{
public:	
	/*!
		\brief ����� ���������
	*/
	virtual void Production();
	/*!
		\brief ����� ����������
	*/
	virtual bool Destroy();
	
	virtual int GetSpecial();
	/*!
		\brief ����� ������������
	*/
	BaseBuilding(float _x, float _y, Resource *Res, Resource *Cons);
	BaseBuilding(int _x, int _y, Resource *Res, Resource *Cons);
	/*!
		\brief ����� ������
	*/
	int GetColonyLevel();
private:
	virtual void Working();
	int ColonyLevel;//������� �������.
};

/*!
	\brief ����� ������ ������
	\details ����� �������� ������ ���������, �������������, ������������, ������

*/

class SmallHouse : public Building
{
public:
	/*!
		\brief ����� ���������
	*/
	virtual void Production();
	/*!
		\brief ����� ����������
	*/
	virtual bool Destroy();
	virtual int GetSpecial();
	/*!
		\brief ����� ������������
	*/
	SmallHouse(int _x, int _y, Resource *Res, Resource *Cons);
private:
	/*!
		\brief ����� ������
	*/
	virtual void Working();
	int CountOfWorkers;
};

/*!
	\brief ����� �������� ������
	\details ����� �������� ������ ���������, ������������, ������

*/

class IronOreMiner : public Building
{
public:
	/*!
		\brief ����� ���������
	*/
	virtual void Production();
	virtual int GetSpecial();
	/*!
		\brief ����� ������������
	*/
	IronOreMiner(int _x, int _y, Resource *Res, Resource *Cons);
private:
	/*!
		\brief ����� ������
	*/
	virtual void Working();
	int OreAmount;//���������� ���� � ������ ���������.
};