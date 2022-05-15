#pragma once
#include "Minimap.h"
#include <list>
#include "Resource.h"
#include "Buildings.h"
#include "Construction.h"
#include "SelectedObject.h"

class HUD : public Drawable
{
public:
	HUD(string NameTextureHUD, string NameTextureMinimap, Map *_map, list<Building*> *_Buildings, list<Resource*> *_Resources, RenderWindow *window);
	void update();
	~HUD();
private:

	bool ConstructionIsProgress;//���� ������������� � ���, ��� ����� � ������ �������������.

	RenderWindow *WorkWindow; //���� � ������� �������������� HUD.

	Image ImageHUD;
	Texture TextureHUD;
	VertexArray VerticesHUD;

	Minimap *minimap; //���������, ������������ �� �����.

	list<Resource*> *Resources;//��������� �� ������ ��������.
	Construction *ConstructionTab;
	SelectedObject *SelectedTab;

	virtual void draw(RenderTarget &target, RenderStates states) const; //������������ HUD.
};