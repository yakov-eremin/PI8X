#pragma once

#include "SFML/Graphics.hpp"
#include <string>
#include <iostream>
#include <sstream>

using namespace sf;
using namespace std;

/*!
	\brief  ласс ресурса
	\details управл€ет ресурсом игры
*/

class Resource : public Drawable
{
public:
	Resource(string Name, float count, string FontName, string NameTexture);
	void SetXY(float _x, float _y);
	float GetWidth();
	string GetName();

	/*!
		\brief метод использовани€ ресурсов
	*/

	bool IsCanSpendResource(float count);//ѕровер€еть можно ли использовать определЄнное количество ресурса.

	/*!
		\brief метод изменени€ ресурсов
	*/

	void AddResource(float count);//ѕрибавл€ет или уменьшает количества ресурса.
private:
	string NameResource; //Ќазвание ресурса.
	float CountOfRecources; // оличество ресурса у игрока.


	//ƒл€ отображении ресурса в HUD.
	float x;
	float y;
	float width;
	Font FontResource;
	Text NumberResource; 
	Texture TextureResource;//“екстура ресурса.
	VertexArray VerticesResource; //вершины дл€ текстурки.
	/*!
		\brief метод отричовки
	*/

	virtual void draw(RenderTarget &target, RenderStates states) const; //ќтрисовывает текстуру ресурса.
};