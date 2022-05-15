#include "Form.h"

using namespace sf;


//------------------------------------------------Form-----------------------------------------------------------------

//У классов потомков задаются массивы кнопок.
Form::Form(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window)
{
	//Установка ссылки на координаты окна.
	WorkWindow = window;

	//Установка координат меню.
	x = _x;
	y = _y;
	width = _width;
	height = _height;

	//Установка текстуры.
	TextureForm.loadFromFile("Resources/Images/" + NameTexture);

	//Задаются вершины формы.
	VerticesForm.setPrimitiveType(Quads);
	VerticesForm.resize(4);
	VerticesForm[0].texCoords = Vector2f(0, 0);
	VerticesForm[1].texCoords = Vector2f(0, TextureForm.getSize().y);
	VerticesForm[2].texCoords = Vector2f(TextureForm.getSize().x, TextureForm.getSize().y);
	VerticesForm[3].texCoords = Vector2f(TextureForm.getSize().x, 0);
	VerticesForm[0].position = Vector2f(x, y);
	VerticesForm[1].position = Vector2f(x, y + height);
	VerticesForm[2].position = Vector2f(x + width, y + height);
	VerticesForm[3].position = Vector2f(x + width, y);

	//Создание массива кнопок.
	AmountOfButtons = 0;

	//Задаётся изначальный статус формы.
	status = 0;
}

//Виртуальная функция для проверки состояния формы.
//0 - форма в режиме ожидания, 1, 2, ..., AmountOfButtons - в форме нажата определённая кнопка.
int Form::checkStatus()
{
	for (int i = 0; i < AmountOfButtons; i++)
		if (ArrayButton[i]->isButtonPressed())
			return i + 1;
	return 0;
}

void Form::setStatus(int _status)
{
	status = _status;
}

//Отрисовка формы на экране.
void Form::draw(RenderTarget &target, RenderStates states) const
{
	//Задаёт текстуру.
	states.texture = &TextureForm;

	//Отрисовывает форму формы.
	target.draw(VerticesForm, states);

	//отрисовывает кнопки формы.
	for (int i = 0; i < AmountOfButtons; i++)
		target.draw(*ArrayButton[i], states);
}


//---------------------------------StartMenuForm----------------------------------------------------------------------

//NameTexture указывать с форматом файла.
StartMenuForm::StartMenuForm(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window)
	: Form(NameTexture, _x, _y, _width, _height, window)
{
	//Создание массива кнопок.
	AmountOfButtons = 2;
	float dx = x + 25;
	float dy = y + 50;
	ArrayButton = new Button *[AmountOfButtons];
	ArrayButton[0] = new Button(L"Начать игру    ", "SeldomScene.otf", 12, "Button1.png", dx, dy, window);
	dy += ArrayButton[0]->getSizeButton().y + 25;
	ArrayButton[1] = new Button(L"Выход          ", "SeldomScene.otf", 12, "Button1.png", dx, dy, window);

	//Создание формы выхода.
	exitForm = new ExitForm(NameTexture, x, y, width, height, WorkWindow);
}

StartMenuForm::~StartMenuForm()
{
	//Удаление массива кнопок и формы выхода.
	for (int i = 0; i < AmountOfButtons; i++)
		delete ArrayButton[i];
	delete[] ArrayButton;
	delete exitForm;
}

//Работа формы StartMenuForm.
int StartMenuForm::update()
{
	
	switch (status)
	{
	default:
		status = checkStatus();
		break;
	case 2:
		if (exitForm->update() == 2)
			status = 0;
		break;
	}
	return status;
}

//Отрисовка формы на экране.
void StartMenuForm::draw(RenderTarget &target, RenderStates states) const
{
	//Отрисовка меню выхода из игры.
	if (status == 2)
		target.draw(*exitForm);
	else
		Form::draw(target, states);
}


//----------------------------------------ExitForm-----------------------------------------------------------------------

ExitForm::ExitForm(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window)
	: Form(NameTexture, _x, _y, _width, _height, window)
{
	//Создание массива кнопок.
	AmountOfButtons = 2;
	float dx = x + 25;
	float dy = y + 50;
	ArrayButton = new Button *[AmountOfButtons];
	ArrayButton[0] = new Button(L"Да ", "SeldomScene.otf", 12, "Button1.png", dx, dy, window);
	dy += ArrayButton[0]->getSizeButton().y + 25;
	ArrayButton[1] = new Button(L"Нет", "SeldomScene.otf", 12, "Button1.png", dx, dy, window);
}

//Работа формы YesNoForm.
int ExitForm::update()
{
	switch (status)
	{
	case 1:
		WorkWindow->close();
		break;
	default:
		status = checkStatus();
		break;
	}
	return status;
}

ExitForm::~ExitForm()
{
	//Удаление массива кнопок.
	for (int i = 0; i < AmountOfButtons; i++)
		delete ArrayButton[i];
	delete[] ArrayButton;
}