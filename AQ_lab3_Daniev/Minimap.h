#pragma once
#include "Map.h"

using namespace sf;
using namespace std;

class Minimap : public Drawable
{
public:
	Minimap(string NameTexture, Map *_map);
	FloatRect getBoundingBox();//���������� ������� �������� ���������.
private:
	View MinimapView; //���������, ��� ����������� ���� �����.

	int width; //������ �����.
	int height; //������ �����.

	Image ImageMinimap;
	Texture TextureMinimap; //�������� ���������.

	VertexArray VerticesMinimap;//������� ���������.
	Map *map; //��������� �� ����� ������� ���������� ���������.

	virtual void draw(RenderTarget &target, RenderStates states) const; //��������� ��������� �� ������.
};