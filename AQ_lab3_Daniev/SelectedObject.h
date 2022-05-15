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
	\brief  ласс выбор объекта
	\details класс дл€ помощи ориентации по игре
*/

class SelectedObject : public Drawable
{
public:
	SelectedObject(string NameFont, string NameTexture, list<Building*> *Build, list<Resource*> *Res, Map *map, RenderWindow *window);
	void update();
private:
	//”казатели на список ресурсов дл€ взаимодействи€ с ними.
	list<Resource*> *Resources;
	//”казатель список зданий.
	list<Building*> *Buildings;
	//”казатель на карту.
	Map *WorldMap;
	//”кзаатель на текущее выбранное здание.
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
		\brief метод отричовки
	*/

	virtual void draw(RenderTarget &target, RenderStates states) const;

	RenderWindow *WorkWindow;
	list<Button*> ListButton;
};