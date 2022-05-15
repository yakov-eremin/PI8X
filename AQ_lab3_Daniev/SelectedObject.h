#pragma once
#include "Resource.h"
#include "Buildings.h"
#include "Button.h"
#include <string>
#include <list>
#include "Map.h"

using namespace std;
using namespace sf;

/*!
	\brief ����� ����� �������
	\details ����� ��� ������ ���������� �� ����
*/

class SelectedObject : public Drawable
{
public:
	SelectedObject(string NameFont, string NameTexture, list<Building*> *Build, list<Resource*> *Res, Map *map, RenderWindow *window);
	void update();
private:
	//��������� �� ������ �������� ��� �������������� � ����.
	list<Resource*> *Resources;
	//��������� ������ ������.
	list<Building*> *Buildings;
	//��������� �� �����.
	Map *WorldMap;
	//��������� �� ������� ��������� ������.
	Building *CurrentObject;

	float x;
	float y;
	float width;
	float height;
	Font FontTab;
	Text NameTab;
	Text NumberTab1;
	Text NumberTab2;
	Texture TextureSelected;
	VertexArray VerticesSeelcted;
	/*!
		\brief ����� ���������
	*/

	virtual void draw(RenderTarget &target, RenderStates states) const;

	RenderWindow *WorkWindow;
	list<Button*> ListButton;
};