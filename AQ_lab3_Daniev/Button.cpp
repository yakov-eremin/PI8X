#include "Button.h"

Button::Button(wstring _text, string FontName, int _SizeText, string NameTexture, float _x, float _y, RenderWindow *window)
{
	//��������� ������ �� ���������� ����.
	WorkWindow = window;

	//�������� ���������� ������.
	x = _x;
	y = _y;

	SizeText = _SizeText;

	FlagIsButtonPressed = false;

	//��������� ������.
	FontButton.loadFromFile("Resources/Fonts/" + FontName);

	//��������� ������ ������.
	TextButton.setFont(FontButton);
	TextButton.setString(_text);
	TextButton.setFillColor(Color::White);
	TextButton.setPosition(x + SizeText, y + SizeText);
	TextButton.setCharacterSize(SizeText);
	TextButton.setOutlineColor(Color::Black);
	TextButton.setOutlineThickness(3);

	//��������� ������ � ����� ������.
	width = float((_text.length() + 2) * SizeText);
	height = float(3 * SizeText);

	//��������� ��������.
	TextureButton.loadFromFile("Resources/Images/" + NameTexture);

	//�������� ������� ������.
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

//�������� ������ ������.
Vector2f Button::getSizeButton()
{
	return Vector2f(width, height);
}

//����� ��� ��������� ������.
void Button::draw(RenderTarget &target, RenderStates states) const 
{
	//���������� ��������������.
	states.transform *= getTransform();

	//����� ��������.
	states.texture = &TextureButton;

	//������ ����� ������.
	target.draw(VerticesButton, states);

	//������ ����� � ��������������.
	target.draw(TextButton, states);
}

//��������� �������� ���� �� ������.
bool Button::isButtonFocus()
{
	//������������ ���������� ����� � �������.
	Vector2f WorldMouseCoord = WorkWindow->mapPixelToCoords(Mouse::getPosition(*WorkWindow));
	if (BoundingBox.contains(WorldMouseCoord))
	{
		//��������� ���������� ������ ��� ���������;
		setScale(1.1, 1.1);
		return true;
	}
	setScale(1, 1);
	return false;
}

//��������� ������ ������.
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

//��������������� setScale.
void Button::setScale(float factorX, float factorY)
{
	//������������� ����� ����������.
	float newX = x - width * (factorX - 1) / 2;
	float newY = y - height * (factorY - 1) / 2;

	//��������� ��������� ������ ������.
	VerticesButton[0].position = Vector2f(newX, newY);
	VerticesButton[1].position = Vector2f(newX, newY + height * factorY);
	VerticesButton[2].position = Vector2f(newX + width * factorX, newY + height * factorY);
	VerticesButton[3].position = Vector2f(newX + width * factorX, newY);

	//��������� ������ ������ ������.
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