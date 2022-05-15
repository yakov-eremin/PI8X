#pragma once
#include "Button.h"

using namespace sf;

/*!
	\brief Класс формв
	\details Абстрактный класс формы.
*/

//Абстрактный класс формы.
class Form : public Drawable
{
public:
	Form(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window);
	virtual int update() = 0; //Описывает работу формы.
	void setStatus(int _status);//Устанавливает статус формы.
protected:
	RenderWindow *WorkWindow;
	
	float x;
	float y;
	
	float width; //Ширина формы.
	float height; //Высота формы.
	
	int status; //Состояние формы.
	
	Button **ArrayButton; //Массив кнопок.
	
	int AmountOfButtons; //Количество кнопок в форме. 
	
	Texture TextureForm; //Текстура формы.
	
	VertexArray VerticesForm; //Вершины формы.

	/*!
		\brief метод проверки состояния формы
	*/
	
	virtual int checkStatus(); //Проверяет состояние формы.
	
	/*!
		\brief метод отрисовки
	*/

	virtual void draw(RenderTarget &target, RenderStates states) const; //Отрисовка формы на экране.
};

/*!
	\brief Класс выхода из формы
	
*/


//Форма для выхода из окна.
class ExitForm : public Form
{
public:
	ExitForm(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window);
	~ExitForm();
	/*!
		\brief метод обработки формы
	*/

	virtual int update(); //обработка формы.
};

/*!
	\brief Класс стартого меню для игры
	\details/Форма стартого меню для игры.
*/

//Форма стартого меню для игры.
class StartMenuForm : public Form
{
public:
	StartMenuForm(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window);
	~StartMenuForm();
	virtual int update(); //обработка стартого меню.
private:
	ExitForm *exitForm;
	
	/*!
		\brief метод отричовки
	*/

	virtual void draw(RenderTarget &target, RenderStates states) const; //Отрисовка формы на экране.
};