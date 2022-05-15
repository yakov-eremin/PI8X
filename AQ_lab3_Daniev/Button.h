#pragma once
#include "SFML/Graphics.hpp"
#include <string>

using namespace std;
using namespace sf;

//Класс кнопка.
class Button : public Drawable, public Transformable
{
public:
	//NameFont и NameTexture указываются с форматами, SizeText указывается в пикселях.
	Button(wstring _text, string NameFont, int _SizeText, string NameTexture, float _x, float _y, RenderWindow *window);
	bool isButtonPressed(); //Проверяет нажатие на кнопку.
	Vector2f getSizeButton(); //Получает размер кнопки.
	void SetXY(float _x, float _y);
private:
	RenderWindow *WorkWindow; //Указатель на окно в котором работает кнопка.

	float x; 
	float y; 
	
	float width; //Ширина кнопки.
	float height; //Высота кнопки.
	
	int SizeText;

	bool FlagIsButtonPressed;

	Text TextButton; //Текст кнопки, который будет написан в самой кнопки.
	Font FontButton; //Шрифт кнопки.
	
	Texture TextureButton; //Текстура кнопки.
	
	VertexArray VerticesButton; //Вершины кнопки.
	
	FloatRect BoundingBox; //Ограничительная коробка.
	
	virtual void draw(RenderTarget &target, RenderStates states) const; //Отрисовка кнопки на экране.
	
	bool isButtonFocus(); //Проверяет наведена мышь на кнопку.
	
	void setScale(float factorX, float factorY); //Переопределение функции setScale для нормального изменения кнопки.
};