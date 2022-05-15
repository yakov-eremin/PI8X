#include "Minimap.h"

Minimap::Minimap(string NameTexture, Map *_map)
{

	//��������� �� �����, ������� ���������� ���������.
	map = _map;

	//����� ������ �����.
	width = map->GetWidthOfMap();
	height = map->GetHeightOfMap();

	//��������� ���� ��� ���������.
	MinimapView.setViewport(FloatRect(0.02, 0.67, 0.17, 0.31));
	MinimapView.setCenter(width / 2, height / 2);
	MinimapView.setSize(width + 100, height + 100);

	//��������� �������� ���������.
	ImageMinimap.loadFromFile("Resources/Images/" + NameTexture);
	ImageMinimap.createMaskFromColor(Color::White);
	TextureMinimap.loadFromImage(ImageMinimap);

	//�������� ������.
	VerticesMinimap.setPrimitiveType(Quads);
	VerticesMinimap.resize(4);
	VerticesMinimap[0].texCoords = Vector2f(0, 0);
	VerticesMinimap[1].texCoords = Vector2f(0, TextureMinimap.getSize().y);
	VerticesMinimap[2].texCoords = Vector2f(TextureMinimap.getSize().x, TextureMinimap.getSize().y);
	VerticesMinimap[3].texCoords = Vector2f(TextureMinimap.getSize().x, 0);
	VerticesMinimap[0].position = Vector2f(0 - 50, 0 - 50);
	VerticesMinimap[1].position = Vector2f(0 - 50, height + 50);
	VerticesMinimap[2].position = Vector2f(width + 50, height + 50);
	VerticesMinimap[3].position = Vector2f(width + 50, 0 - 50);
}

void Minimap::draw(RenderTarget &target, RenderStates states) const
{
	//����� ��������.
	states.texture = &TextureMinimap;

	View view = target.getView();

	RectangleShape Rect;
	Rect.setPosition(view.getCenter().x - view.getSize().x / 2, view.getCenter().y - view.getSize().y / 2);
	Rect.setSize(view.getSize());
	Rect.setFillColor(Color(0, 0, 0, 0));
	Rect.setOutlineColor(Color::Green);
	Rect.setOutlineThickness(10);

	target.setView(MinimapView);


	//������������ �����.
	target.draw(*map);

	target.draw(Rect);

	// ������ ����� ������.
	target.draw(VerticesMinimap, states);

	target.setView(view);

}