#pragma once
#include "Map.h"

using namespace sf;
using namespace std;

/*!
	\brief Класс миникарты
	\details класс создаёт миникарты для игры
*/

class Minimap : public Drawable
{
public:
	Minimap(string NameTexture, Map *_map);
	FloatRect getBoundingBox();//Возвращает область действия миникарты.
private:
	View MinimapView; //Миникарта, для отображение всей карты.

	int width; //Ширина карты.
	int height; //Высота карты.

	Image ImageMinimap;
	Texture TextureMinimap; //Текстура миникарты.

	VertexArray VerticesMinimap;//Вершины миникарты.
	Map *map; //Указатель на карту которую отображает миникарта.

	/*!
		\brief метод отричовки
	*/

	virtual void draw(RenderTarget &target, RenderStates states) const; //Отрисовка миникарты на экране.
};