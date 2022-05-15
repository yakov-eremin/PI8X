#include "Form.h"

using namespace sf;


//------------------------------------------------Form-----------------------------------------------------------------

//� ������� �������� �������� ������� ������.
Form::Form(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window)
{
	//��������� ������ �� ���������� ����.
	WorkWindow = window;

	//��������� ��������� ����.
	x = _x;
	y = _y;
	width = _width;
	height = _height;

	//��������� ��������.
	TextureForm.loadFromFile("Resources/Images/" + NameTexture);

	//�������� ������� �����.
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

	//�������� ������� ������.
	AmountOfButtons = 0;

	//������� ����������� ������ �����.
	status = 0;
}

//����������� ������� ��� �������� ��������� �����.
//0 - ����� � ������ ��������, 1, 2, ..., AmountOfButtons - � ����� ������ ����������� ������.
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

//��������� ����� �� ������.
void Form::draw(RenderTarget &target, RenderStates states) const
{
	//����� ��������.
	states.texture = &TextureForm;

	//������������ ����� �����.
	target.draw(VerticesForm, states);

	//������������ ������ �����.
	for (int i = 0; i < AmountOfButtons; i++)
		target.draw(*ArrayButton[i], states);
}


//---------------------------------StartMenuForm----------------------------------------------------------------------

//NameTexture ��������� � �������� �����.
StartMenuForm::StartMenuForm(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window)
	: Form(NameTexture, _x, _y, _width, _height, window)
{
	//�������� ������� ������.
	AmountOfButtons = 2;
	float dx = x + 25;
	float dy = y + 50;
	ArrayButton = new Button *[AmountOfButtons];
	ArrayButton[0] = new Button(L"������ ����    ", "SeldomScene.otf", 12, "Button1.png", dx, dy, window);
	dy += ArrayButton[0]->getSizeButton().y + 25;
	ArrayButton[1] = new Button(L"�����          ", "SeldomScene.otf", 12, "Button1.png", dx, dy, window);

	//�������� ����� ������.
	exitForm = new ExitForm(NameTexture, x, y, width, height, WorkWindow);
}

StartMenuForm::~StartMenuForm()
{
	//�������� ������� ������ � ����� ������.
	for (int i = 0; i < AmountOfButtons; i++)
		delete ArrayButton[i];
	delete[] ArrayButton;
	delete exitForm;
}

//������ ����� StartMenuForm.
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

//��������� ����� �� ������.
void StartMenuForm::draw(RenderTarget &target, RenderStates states) const
{
	//��������� ���� ������ �� ����.
	if (status == 2)
		target.draw(*exitForm);
	else
		Form::draw(target, states);
}


//----------------------------------------ExitForm-----------------------------------------------------------------------

ExitForm::ExitForm(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window)
	: Form(NameTexture, _x, _y, _width, _height, window)
{
	//�������� ������� ������.
	AmountOfButtons = 2;
	float dx = x + 25;
	float dy = y + 50;
	ArrayButton = new Button *[AmountOfButtons];
	ArrayButton[0] = new Button(L"�� ", "SeldomScene.otf", 12, "Button1.png", dx, dy, window);
	dy += ArrayButton[0]->getSizeButton().y + 25;
	ArrayButton[1] = new Button(L"���", "SeldomScene.otf", 12, "Button1.png", dx, dy, window);
}

//������ ����� YesNoForm.
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
	//�������� ������� ������.
	for (int i = 0; i < AmountOfButtons; i++)
		delete ArrayButton[i];
	delete[] ArrayButton;
}