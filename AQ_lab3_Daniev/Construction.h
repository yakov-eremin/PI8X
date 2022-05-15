#pragma once
#include "Buildings.h"
#include "Button.h"
#include <list>
#include "Map.h"

//�����, ������� ���������� � HUD ������� �������������.
class Construction : public Drawable
{
public:
	Construction(string NameFont, string NameTexture, list<Building*> *Build, list<Resource*> *Res, Map *map, RenderWindow *window);
	bool update();
private:
	list<Building*> *Buildings;//��������� �� ������ ��������, ��������� �������.
	list<Resource*> *Resources;//��������� �� ������ ��������.
	Map *WorldMap;
	bool ConstructionIsProgress;

	int CountOfConstruction;//���������� ������, ������� �������� ���������.

	//�������� ������ ��� ����������� �������.
	float x;
	float y;
	float width;
	float height;
	Font FontTab;
	Text NameTab;
	Texture ConstructionTexture;
	VertexArray VerticesConstruction;
	virtual void draw(RenderTarget &target, RenderStates states) const;

	//������, ������� ����� ���������� ���� ������� ��� ��������� ������.
	RenderWindow *WorkWindow;
	list<Button*> ListButton;
	int Delta;//������� ����� ������������� � ������������� � ������ ��������.
	FloatRect ConstructionBoundary;//�������������, � ������� ����� ������� ����� ������.
	int selected;//�������� ������ ������ ������� ���� ������.
	bool IsCanBuilding;//���� �������� ����� �� ���� ���������� ������.
	//������� ������� ���������.
	int widthbuild;
	int heightbuild;

};