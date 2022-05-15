#include "Map.h"

Map::Map(string Name, string NameTexture, RenderWindow *window, View *view)
{
	//��������� �� ���� � ������� ����������� �����.
	WorkWindow = window;

	//��������� �� ����������� ��� � ����.
	ViewMap = view;

	//�������� ��������� ������� �����.
	ifstream MapFile("Resources/Maps/" + Name);

	MapFile >> NumberOfSquaresX;
	MapFile >> NumberOfSquaresY;

	MapArray = new int*[NumberOfSquaresX];
	FreeCellMap = new bool*[NumberOfSquaresX];
	for (int i = 0; i < NumberOfSquaresY; i++)
	{
		MapArray[i] = new int[NumberOfSquaresX];
		FreeCellMap[i] = new bool[NumberOfSquaresX];
	}

	for (int i = 0; i < NumberOfSquaresX; i++)
		for (int j = 0; j < NumberOfSquaresY; j++)
		{
			MapFile >> MapArray[j][i];

			//��������� ������ �������� ����������� � �� ��� ����� �������.
			if (MapArray[j][i] == 0 ||
				MapArray[j][i] == 3)
				FreeCellMap[j][i] = true;
			else
				FreeCellMap[j][i] = false;

		}

	MapFile.close();

	//������� �������� ��� �����.
	TextureMap.loadFromFile("Resources/Images/" + NameTexture);
	SizeSquares = 64;
	SizeSquaresMap = 20;

	//������� ������.
	VerticesMap.setPrimitiveType(Quads);
	VerticesMap.resize(NumberOfSquaresX * NumberOfSquaresY * 4);
	
	for (int i = 0; i < NumberOfSquaresX; i++)
	{
		for (int j = 0; j < NumberOfSquaresY; j++)
		{
			int coordX = MapArray[j][i] % 6 * SizeSquares;
			int coordY = MapArray[j][i] / 6 * SizeSquares;
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 0].texCoords = Vector2f(coordX, coordY);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 1].texCoords = Vector2f(coordX + SizeSquares, coordY);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 2].texCoords = Vector2f(coordX + SizeSquares, coordY + SizeSquares);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 3].texCoords = Vector2f(coordX, coordY + SizeSquares);
			coordX = i * SizeSquaresMap;
			coordY = j * SizeSquaresMap;
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 0].position = Vector2f(coordX, coordY);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 1].position = Vector2f(coordX + SizeSquaresMap, coordY);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 2].position = Vector2f(coordX + SizeSquaresMap, coordY + SizeSquaresMap);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 3].position = Vector2f(coordX, coordY + SizeSquaresMap);
		}
	}

	//������� ��������������� �������.
	BoundingBox = VerticesMap.getBounds();
}

Map::~Map()
{
	for (int i = 0; i < NumberOfSquaresY; i++)
		delete[] MapArray[i];

	delete[] MapArray;
}

//����� ��� ��������� �����.
void Map::draw(RenderTarget &target, RenderStates states) const
{
	//����� ��������.
	states.texture = &TextureMap;

	//������ �����.
	target.draw(VerticesMap, states);
}

//��������� �������� �����.
int Map::GetHeightOfMap()
{
	return NumberOfSquaresY * SizeSquaresMap;
}

int Map::GetWidthOfMap()
{
	return NumberOfSquaresX * SizeSquaresMap;
}

//���������� �����.
void Map::update()
{
	//��������� ������.
	FloatRect SelectedBox;
	SelectedBox.left = WorkWindow->getView().getCenter().x - WorkWindow->getView().getSize().x / 2 + 4;
	SelectedBox.top = WorkWindow->getView().getCenter().y - WorkWindow->getView().getSize().y / 2 + 4;
	SelectedBox.width = WorkWindow->getView().getSize().x - 8;
	SelectedBox.height = WorkWindow->getView().getSize().y - 8;

	//����� ������� � ������ ����.
	FloatRect Box = BoundingBox;
	Box.top = BoundingBox.top - WorkWindow->getView().getSize().y * 0.05;
	Box.height = BoundingBox.height + WorkWindow->getView().getSize().y * 0.4;

	//���������� ���� � ������� �����������.
	Vector2f WorldMouseCoord = WorkWindow->mapPixelToCoords(Mouse::getPosition(*WorkWindow));

	//���� ���������� ���� ��������� ��� �����. 
	if (Box.contains(WorldMouseCoord))
	{
		//���� ���������� ���� �� ������.
		if (!SelectedBox.contains(WorldMouseCoord))
		{
			//������� �� x.
			if (!SelectedBox.contains(WorldMouseCoord.x, SelectedBox.top + SelectedBox.height / 2))
				if (WorldMouseCoord.x < SelectedBox.left)
					ViewMap->move(-3, 0);
				else
					ViewMap->move(3, 0);

			//������� �� y.
			if (!SelectedBox.contains(SelectedBox.left + SelectedBox.width / 2, WorldMouseCoord.y))
				if (WorldMouseCoord.y < SelectedBox.top)
					ViewMap->move(0, -3);
				else
					ViewMap->move(0, 3);
		}
	}
}

bool Map::GetValueMap(int x, int y, int width, int height)
{
	bool result = true;
	for (int i = x / SizeSquaresMap; i < (x / SizeSquaresMap + width / SizeSquaresMap); i++)
		for (int j = y / SizeSquaresMap; j < (y / SizeSquaresMap + height / SizeSquaresMap); j++)
			result &= FreeCellMap[j][i];
	return result;
}

bool Map::GetValueMap(int x, int y, int width, int height, int tp)
{
	bool result = true;
	for (int i = x / SizeSquaresMap; i < (x / SizeSquaresMap + width / SizeSquaresMap); i++)
		for (int j = y / SizeSquaresMap; j < (y / SizeSquaresMap + height / SizeSquaresMap); j++)
		{
			result &= FreeCellMap[j][i];
			if (MapArray[j][i] == tp)
				result &= true;
			else
				result &= false;
		}
	return result;
}

void Map::SetValueMap(int x, int y, int width, int height)
{
	for (int i = x / SizeSquaresMap; i < (x + width) / SizeSquaresMap; i++)
		for (int j = y / SizeSquaresMap; j < (y + height) / SizeSquaresMap; j++)
		{
			MapArray[j][i] = 4;
			int coordX = MapArray[j][i] % 6 * SizeSquares;
			int coordY = MapArray[j][i] / 6 * SizeSquares;
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 0].texCoords = Vector2f(coordX, coordY);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 1].texCoords = Vector2f(coordX + SizeSquares, coordY);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 2].texCoords = Vector2f(coordX + SizeSquares, coordY + SizeSquares);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 3].texCoords = Vector2f(coordX, coordY + SizeSquares);
			FreeCellMap[j][i] = false;
		}
}

void Map::Clear(int x, int y, int width, int height)
{
	for (int i = x / SizeSquaresMap; i < (x + width) / SizeSquaresMap; i++)
		for (int j = y / SizeSquaresMap; j < (y + height) / SizeSquaresMap; j++)
		{
			MapArray[j][i] = 0;
			int coordX = MapArray[j][i] % 6 * SizeSquares;
			int coordY = MapArray[j][i] / 6 * SizeSquares;
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 0].texCoords = Vector2f(coordX, coordY);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 1].texCoords = Vector2f(coordX + SizeSquares, coordY);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 2].texCoords = Vector2f(coordX + SizeSquares, coordY + SizeSquares);
			VerticesMap[(j * NumberOfSquaresX + i) * 4 + 3].texCoords = Vector2f(coordX, coordY + SizeSquares);
			FreeCellMap[j][i] = true;
		}
}