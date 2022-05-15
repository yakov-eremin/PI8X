#pragma once
#include "Button.h"

using namespace sf;

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
	
	virtual int checkStatus(); //Проверяет состояние формы.
	
	virtual void draw(RenderTarget &target, RenderStates states) const; //Отрисовка формы на экране.
};

//Форма для выхода из окна.
class ExitForm : public Form
{
public:
	ExitForm(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window);
	~ExitForm();
	virtual int update(); //обработка формы.
};

//Форма стартого меню для игры.
class StartMenuForm : public Form
{
public:
	StartMenuForm(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window);
	~StartMenuForm();
	virtual int update(); //обработка стартого меню.
private:
	ExitForm *exitForm;
	virtual void draw(RenderTarget &target, RenderStates states) const; //Отрисовка формы на экране.
};