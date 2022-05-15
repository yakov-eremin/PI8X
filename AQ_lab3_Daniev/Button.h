#pragma once
#include "SFML/Graphics.hpp"
#include <string>

using namespace std;
using namespace sf;

/*!
	\brief Класс кнопка
	\details Класс содержит методы размера кнопки, проверки нажатия, отрисовки, наведения, изменения
*/
class Button : public Drawable, public Transformable
{
public:
	//NameFont и NameTexture указываются с форматами, SizeText указывается в пикселях.
	Button(wstring _text, string NameFont, int _SizeText, string NameTexture, float _x, float _y, RenderWindow *window);
	/*!
		\brief метод проверяет нажатие на кнопку
	*/

	bool isButtonPressed(); //Проверяет нажатие на кнопку.
	/*!
		\brief метод получает размер кнопки
	*/
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

	/*!
		\brief метод отрисовка кнопки на экране
	*/
	
	virtual void draw(RenderTarget &target, RenderStates states) const; //Отрисовка кнопки на экране.
	
	bool isButtonFocus(); //Проверяет наведена мышь на кнопку.
	
	void setScale(float factorX, float factorY); //Переопределение функции setScale для нормального изменения кнопки.
};