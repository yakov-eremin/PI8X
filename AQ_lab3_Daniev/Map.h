#pragma once
#include "SFML/Graphics.hpp"
#include <string>
#include <fstream>

using namespace std;
using namespace sf;

class Map : public Drawable
{
public:
	//��� ����������� ����� � ��������, ��������� ������� ������.
	Map(string Name, string NameTexture, RenderWindow *window, View *view);
	//��������� �������� �����.
	int GetWidthOfMap();
	int GetHeightOfMap();
	//���������� �����.
	void update();
	bool GetValueMap(int x, int y, int width, int height);
	bool GetValueMap(int x, int y, int width, int height, int tp);
	void SetValueMap(int x, int y, int width, int height);
	void Clear(int x, int y, int width, int height);
	~Map();
private:
	RenderWindow *WorkWindow; //���� � ������� �������� �����.

	View *ViewMap; //���, ������� ���������� �����.

	int NumberOfSquaresX; //���������� ��������� ����� �� x.
	int NumberOfSquaresY; //������c��� ��������� ����� �� y.
	
	int SizeSquares; //������ ������ �������� ��� �������.
	int SizeSquaresMap; //������ ������ �������� ��� �����.
	
	int **MapArray; //������ �����, ���������� ����� � ���� �����.
	bool **FreeCellMap;//����� ������������� � ���� ������� �������� ��������� ��������� �����.
	
	Texture TextureMap; //�������� �����.
	VertexArray VerticesMap; //������� ��������� �����.
	
	virtual void draw(RenderTarget &target, RenderStates states) const; //��������� ����� �� ������.
	
	FloatRect BoundingBox; //��������������� �������.
};