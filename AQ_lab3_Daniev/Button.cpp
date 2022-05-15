#include "Button.h"

Button::Button(wstring _text, string FontName, int _SizeText, string NameTexture, float _x, float _y, RenderWindow *window)
{
	//Установка ссылки на координаты окна.
	WorkWindow = window;

	//Задаются координаты кнопки.
	x = _x;
	y = _y;

	SizeText = _SizeText;

	FlagIsButtonPressed = false;

	//Установка шрифта.
	FontButton.loadFromFile("Resources/Fonts/" + FontName);

	//Установка текста кнопки.
	TextButton.setFont(FontButton);
	TextButton.setString(_text);
	TextButton.setFillColor(Color::White);
	TextButton.setPosition(x + SizeText, y + SizeText);
	TextButton.setCharacterSize(SizeText);
	TextButton.setOutlineColor(Color::Black);
	TextButton.setOutlineThickness(3);

	//Установка ширины и длины кнопки.
	width = float((_text.length() + 2) * SizeText);
	height = float(3 * SizeText);

	//Установка текстуры.
	TextureButton.loadFromFile("Resources/Images/" + NameTexture);

	//Задаются вершины кнопки.
	VerticesButton.setPrimitiveType(Quads);
	VerticesButton.resize(4);
	VerticesButton[0].texCoords = Vector2f(0, 0);
	VerticesButton[1].texCoords = Vector2f(0, TextureButton.getSize().y);
	VerticesButton[2].texCoords = Vector2f(TextureButton.getSize().x, TextureButton.getSize().y);
	VerticesButton[3].texCoords = Vector2f(TextureButton.getSize().x, 0);
	VerticesButton[0].position = Vector2f(x, y);
	VerticesButton[1].position = Vector2f(x, y + height);
	VerticesButton[2].position = Vector2f(x + width, y + height);
	VerticesButton[3].position = Vector2f(x + width, y); 
	BoundingBox = VerticesButton.getBounds();
}

//Получает размер кнопки.
Vector2f Button::getSizeButton()
{
	return Vector2f(width, height);
}

//Метод для отрисовки кнопки.
void Button::draw(RenderTarget &target, RenderStates states) const 
{
	//Объединить преобразования.
	states.transform *= getTransform();

	//Задаёт текстуру.
	states.texture = &TextureButton;

	//Рисует форму кнопки.
	target.draw(VerticesButton, states);

	//Рисует текст в прямоугольнике.
	target.draw(TextButton, states);
}

//Проверяет наведена мышь на кнопку.
bool Button::isButtonFocus()
{
	//Переделывает координаты мышки в мировые.
	Vector2f WorldMouseCoord = WorkWindow->mapPixelToCoords(Mouse::getPosition(*WorkWindow));
	if (BoundingBox.contains(WorldMouseCoord))
	{
		//Небольшое увелечение кнопки при наведении;
		setScale(1.1, 1.1);
		return true;
	}
	setScale(1, 1);
	return false;
}

//Проверяет нажата кнопка.
bool Button::isButtonPressed()
{
	if (isButtonFocus())
		if (FlagIsButtonPressed)
		{
			if (!Mouse::isButtonPressed(Mouse::Left))
			{
				FlagIsButtonPressed = false;
				return true;
			}
			else
				return false;
		}
		else
		{
			if (Mouse::isButtonPressed(Mouse::Left))
			{
				FlagIsButtonPressed = true;
			}
			return false;
		}

}

//Переопределение setScale.
void Button::setScale(float factorX, float factorY)
{
	//Расчитываются новые координаты.
	float newX = x - width * (factorX - 1) / 2;
	float newY = y - height * (factorY - 1) / 2;

	//Изменение положения вершин кнопки.
	VerticesButton[0].position = Vector2f(newX, newY);
	VerticesButton[1].position = Vector2f(newX, newY + height * factorY);
	VerticesButton[2].position = Vector2f(newX + width * factorX, newY + height * factorY);
	VerticesButton[3].position = Vector2f(newX + width * factorX, newY);

	//Изменение текста внутри кнопки.
	TextButton.setScale(factorX, factorY);
	TextButton.setPosition(newX + TextButton.getCharacterSize() * factorX, newY + TextButton.getCharacterSize() * factorY);
}

void Button::SetXY(float _x, float _y)
{
	x = _x;
	y = _y;
	TextButton.setPosition(x + SizeText, y + SizeText);
	VerticesButton[0].position = Vector2f(x, y);
	VerticesButton[1].position = Vector2f(x, y + height);
	VerticesButton[2].position = Vector2f(x + width, y + height);
	VerticesButton[3].position = Vector2f(x + width, y);
	BoundingBox = VerticesButton.getBounds();
}