#pragma once
#include "SFML/Graphics.hpp"
#include <string>
#include <fstream>

using namespace std;
using namespace sf;

class Map : public Drawable
{
public:
	//Имя загружаемой карты и текстуры, указывать форматы файлов.
	Map(string Name, string NameTexture, RenderWindow *window, View *view);
	//Получение размеров карты.
	int GetWidthOfMap();
	int GetHeightOfMap();
	//Обновление карты.
	void update();
	bool GetValueMap(int x, int y, int width, int height);
	bool GetValueMap(int x, int y, int width, int height, int tp);
	void SetValueMap(int x, int y, int width, int height);
	void Clear(int x, int y, int width, int height);
	~Map();
private:
	RenderWindow *WorkWindow; //Окно в котором рисуется карта.

	View *ViewMap; //Вид, который отображает карту.

	int NumberOfSquaresX; //количество квадратов карты по x.
	int NumberOfSquaresY; //Количеcтво квадратов карты по y.
	
	int SizeSquares; //Размер одного квадрата для тектуры.
	int SizeSquaresMap; //Размер одного квадрата для карты.
	
	int **MapArray; //Массив карты, отображает карту в виде чисел.
	bool **FreeCellMap;//Карта отображаеться в виде булевых значений показывая свободные места.
	
	Texture TextureMap; //Текстура карты.
	VertexArray VerticesMap; //Вершины квадратов карты.
	
	virtual void draw(RenderTarget &target, RenderStates states) const; //Отрисовка карты на экране.
	
	FloatRect BoundingBox; //Ограничительная коробка.
};