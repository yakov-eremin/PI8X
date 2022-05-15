#include "HUD.h"

HUD::HUD(string NameTextureHUD, string NameTextureMinimap, Map *_map, list<Building*> *_Buildings, list<Resource*> *_Resources, RenderWindow *window)
{
	//��������� �� ���������� ����.
	WorkWindow = window;

	//��������� �� ������ ��������.
	Resources = _Resources;

	//������ ���������.
	minimap = new Minimap(NameTextureMinimap, _map);

	//C����� ��� �������: ������� ������������� � ������� ���������� �������.
	ConstructionTab = new Construction("SeldomScene.otf", "Construction.png", _Buildings, Resources, _map, WorkWindow);
	SelectedTab = new SelectedObject("SeldomScene.otf", "Construction.png", _Buildings, Resources, _map, WorkWindow);

	//����� �������� HUD.
	ImageHUD.loadFromFile("Resources/Images/" + NameTextureHUD);
	ImageHUD.createMaskFromColor(Color::White);
	TextureHUD.loadFromImage(ImageHUD);

	//�������� ������.
	VerticesHUD.setPrimitiveType(Quads);
	VerticesHUD.resize(4);
	VerticesHUD[0].texCoords = Vector2f(0, 0);
	VerticesHUD[1].texCoords = Vector2f(0, TextureHUD.getSize().y);
	VerticesHUD[2].texCoords = Vector2f(TextureHUD.getSize().x, TextureHUD.getSize().y);
	VerticesHUD[3].texCoords = Vector2f(TextureHUD.getSize().x, 0);
	float x = WorkWindow->getView().getCenter().x - WorkWindow->getView().getSize().x / 2;
	float y = WorkWindow->getView().getCenter().y - WorkWindow->getView().getSize().y / 2;
	float width = WorkWindow->getView().getSize().x;
	float height = WorkWindow->getView().getSize().y;
	VerticesHUD[0].position = Vector2f(x, y);
	VerticesHUD[1].position = Vector2f(x, y + height);
	VerticesHUD[2].position = Vector2f(x + width, y + height);
	VerticesHUD[3].position = Vector2f(x + width, y);
}

HUD::~HUD()
{
	delete minimap;
	delete ConstructionTab;
	delete SelectedTab;
}

//��� ��������� HUDa �� ����� ����.
void HUD::update()
{
	//�������� ��������� HUD.
	float x = WorkWindow->getView().getCenter().x - WorkWindow->getView().getSize().x / 2;
	float y = WorkWindow->getView().getCenter().y - WorkWindow->getView().getSize().y / 2;
	float width = WorkWindow->getView().getSize().x;
	float height = WorkWindow->getView().getSize().y;
	VerticesHUD[0].position = Vector2f(x, y);
	VerticesHUD[1].position = Vector2f(x, y + height);
	VerticesHUD[2].position = Vector2f(x + width, y + height);
	VerticesHUD[3].position = Vector2f(x + width, y);
	x += 5;
	y += 5;
	list<Resource*>::iterator it;
	for (it = Resources->begin(); it != Resources->end(); it++)
	{
		(**it).SetXY(x, y);
		x += (**it).GetWidth() + 10;
	}
	ConstructionIsProgress = ConstructionTab->update();
	SelectedTab->update();
}

void HUD::draw(RenderTarget &target, RenderStates states) const
{
	//����� ��������.
	states.texture = &TextureHUD;

	//������ ����� HUD.
	target.draw(VerticesHUD, states);
	
	//������������ �������.
	list<Resource*>::iterator it;
	for (it = Resources->begin(); it != Resources->end(); it++)
	{
		target.draw(**it);
	}

	//������������ ���������.
	target.draw(*minimap);

	//������������ ������� �������������.
	target.draw(*ConstructionTab);

	//������������ ������� ����������� �������.
	target.draw(*SelectedTab);
}