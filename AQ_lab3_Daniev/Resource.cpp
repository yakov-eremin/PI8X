#include "Resource.h"

Resource::Resource(string Name, float count, string FontName, string NameTexture)
{
	//Задаётся значение для ресурса.
	NameResource = Name;
	CountOfRecources = count;

	//Установка шрифта.
	FontResource.loadFromFile("Resources/Fonts/" + FontName);

	//Установка текста кнопки.
	NumberResource.setFont(FontResource);
	NumberResource.setFillColor(Color::Black);
	NumberResource.setCharacterSize(25);
	stringstream ss;
	ss << int(CountOfRecources);
	string str;
	ss >> str;
	NumberResource.setString(str);
	width = str.length() * 26;
	x = 0;
	y = 0;
	NumberResource.setPosition(x, y);

	//Установка текстуры.
	TextureResource.loadFromFile("Resources/Images/ImageResources/" + NameTexture);

	//Устновка вершин.
	VerticesResource.setPrimitiveType(Quads);
	VerticesResource.resize(4);
	VerticesResource[0].texCoords = Vector2f(0, 0);
	VerticesResource[1].texCoords = Vector2f(0, TextureResource.getSize().y);
	VerticesResource[2].texCoords = Vector2f(TextureResource.getSize().x, TextureResource.getSize().y);
	VerticesResource[3].texCoords = Vector2f(TextureResource.getSize().x, 0);
	width += 20;
}

float Resource::GetWidth()
{
	return width;
}

string Resource::GetName()
{
	return NameResource;
}

bool Resource::IsCanSpendResource(float count)
{
	if (CountOfRecources >= count)
		return true;
	else
		return false;
}

void Resource::AddResource(float count)
{
	if (count > 0)
		CountOfRecources += count;
	else
		if (IsCanSpendResource(count))
			CountOfRecources += count;
}

void Resource::SetXY(float _x, float _y)
{
	//Задаёт новые значения положения.
	x = _x;
	y = _y;
	stringstream ss;
	ss << int(CountOfRecources);
	string str;
	ss >> str;
	NumberResource.setString(str);
	width = str.length() * 25;
	NumberResource.setString(str);
	VerticesResource[0].position = Vector2f(x, y);
	VerticesResource[1].position = Vector2f(x, y + 25);
	VerticesResource[2].position = Vector2f(x + 25, y + 25);
	VerticesResource[3].position = Vector2f(x + 25, y);
	NumberResource.setPosition(x + 35, y);
	width += 35;
}

void Resource::draw(RenderTarget &target, RenderStates states) const
{
	//Задаёт текстуру.
	states.texture = &TextureResource;

	//Рисует форму кнопки.
	target.draw(VerticesResource, states);

	//Отрисовывает числа на экране.
	target.draw(NumberResource);
}