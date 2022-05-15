#pragma once
#include "Buildings.h"
#include "Button.h"
#include <list>
#include "Map.h"

//Класс, который отображает в HUD вкладку строительство.
class Construction : public Drawable
{
public:
	Construction(string NameFont, string NameTexture, list<Building*> *Build, list<Resource*> *Res, Map *map, RenderWindow *window);
	bool update();
private:
	list<Building*> *Buildings;//Указатель на список построек, созданных игроком.
	list<Resource*> *Resources;//указатель на список ресурсов.
	Map *WorldMap;
	bool ConstructionIsProgress;

	int CountOfConstruction;//Количество зданий, которых возможно построить.

	//Элементы нужные для отображения вкладки.
	float x;
	float y;
	float width;
	float height;
	Font FontTab;
	Text NameTab;
	Texture ConstructionTexture;
	VertexArray VerticesConstruction;
	virtual void draw(RenderTarget &target, RenderStates states) const;

	//Кнокпи, которые будут отображать пять текущих для постройки здания.
	RenderWindow *WorkWindow;
	list<Button*> ListButton;
	int Delta;//Разница между отображаемыми и существующими в списке построек.
	FloatRect ConstructionBoundary;//Прямоугольник, в котором можно строить новые здания.
	int selected;//Содержит индекс кнопки которая была нажата.
	bool IsCanBuilding;//Флаг сообщает может ли быть построенно здание.
	//Размеры будущей постройки.
	int widthbuild;
	int heightbuild;

};