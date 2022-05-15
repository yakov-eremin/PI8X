#pragma once

#include "SFML/Graphics.hpp"
#include <string>
#include <iostream>
#include <sstream>

using namespace sf;
using namespace std;

class Resource : public Drawable
{
public:
	Resource(string Name, float count, string FontName, string NameTexture);
	void SetXY(float _x, float _y);
	float GetWidth();
	string GetName();
	bool IsCanSpendResource(float count);//Проверяеть можно ли использовать определённое количество ресурса.
	void AddResource(float count);//Прибавляет или уменьшает количества ресурса.
private:
	string NameResource; //Название ресурса.
	float CountOfRecources; //Количество ресурса у игрока.


	//Для отображении ресурса в HUD.
	float x;
	float y;
	float width;
	Font FontResource;
	Text NumberResource; 
	Texture TextureResource;//Текстура ресурса.
	VertexArray VerticesResource; //вершины для текстурки.
	virtual void draw(RenderTarget &target, RenderStates states) const; //Отрисовывает текстуру ресурса.
};