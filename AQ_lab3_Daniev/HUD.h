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

	bool ConstructionIsProgress;//Флаг сигнализирует о том, что игрок в режиме строительства.

	RenderWindow *WorkWindow; //Окно в котором отрисовывается HUD.

	Image ImageHUD;
	Texture TextureHUD;
	VertexArray VerticesHUD;

	Minimap *minimap; //Миникарта, отображающая всё карту.

	list<Resource*> *Resources;//Указатель на список ресурсов.
	Construction *ConstructionTab;
	SelectedObject *SelectedTab;

	virtual void draw(RenderTarget &target, RenderStates states) const; //Отрисовывает HUD.
};