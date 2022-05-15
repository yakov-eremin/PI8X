#include "Construction.h"

Construction::Construction(string NameFont, string NameTexture, list<Building*> *Build, list<Resource*> *Res, Map *map, RenderWindow *window)
{
	//Устанавливаем указатели.
	WorkWindow = window;
	Buildings = Build;
	Resources = Res;
	WorldMap = map;

	//Поначалу координаты не важны.
	x = 0 ;
	y = 0;
	width = 0;
	height = 0;

	//Задаётся надпись на вкладке, все её свойства.
	FontTab.loadFromFile("Resources/Fonts/" + NameFont);
	NameTab.setString(L"   Строительство");
	NameTab.setFont(FontTab);
	NameTab.setFillColor(Color::Black);
	NameTab.setCharacterSize(20);
	NameTab.setPosition(x, y);

	//Создаются начальные кнопки.
	CountOfConstruction = 5;
	Delta = 0;
	ListButton.push_back( new Button(L"Маленький дом                  ", NameFont, 10, "Button1.png", x, y, WorkWindow));
	ListButton.push_back( new Button(L"Добытчик железной руды         ", NameFont, 10, "Button1.png", x, y, WorkWindow));
	ListButton.push_back( new Button(L"Лаборатория                    ", NameFont, 10, "Button1.png", x, y, WorkWindow));
	ListButton.push_back( new Button(L"Перерабатывающий завод         ", NameFont, 10, "Button1.png", x, y, WorkWindow));
	ListButton.push_back( new Button(L"Мастерская                     ", NameFont, 10, "Button1.png", x, y, WorkWindow));

	//Создаёться прямоугольник (фон) вкладки.
	ConstructionTexture.loadFromFile("Resources/Images/" + NameTexture);
	VerticesConstruction.setPrimitiveType(Quads);
	VerticesConstruction.resize(4);
	VerticesConstruction[0].texCoords = Vector2f(0, 0);
	VerticesConstruction[1].texCoords = Vector2f(0, ConstructionTexture.getSize().y);
	VerticesConstruction[2].texCoords = Vector2f(ConstructionTexture.getSize().x, ConstructionTexture.getSize().y);
	VerticesConstruction[3].texCoords = Vector2f(ConstructionTexture.getSize().x, 0);
	VerticesConstruction[0].position = Vector2f(x, y);
	VerticesConstruction[1].position = Vector2f(x, y + height);
	VerticesConstruction[2].position = Vector2f(x + width, y + height);
	VerticesConstruction[3].position = Vector2f(x + width, y);

	ConstructionIsProgress = false; 
	IsCanBuilding = false;
	list<Building*>::iterator it = Buildings->begin();
	ConstructionBoundary.left = (*it)->getX() - 20 * ((BaseBuilding*)(*it))->GetColonyLevel();
	ConstructionBoundary.top = (*it)->getY() - 20 * ((BaseBuilding*)(*it))->GetColonyLevel();
	ConstructionBoundary.width = 2 * 20 * ((BaseBuilding*)(*it))->GetColonyLevel() + 100;
	ConstructionBoundary.height = 2 * 20 * ((BaseBuilding*)(*it))->GetColonyLevel() + 100;
}

void Construction::draw(RenderTarget &target, RenderStates states) const
{
	//Загружается текстура.
	states.texture = &ConstructionTexture;

	//Отрисовывается фон.
	target.draw(VerticesConstruction, states);
	
	//Отрисовывается надпись.
	target.draw(NameTab);

	//Начинает искать те кнопки, которые будут отрисованы.
	int i = 0;
	list<Button*>::const_iterator it = ListButton.begin();

	while (i < Delta)
	{
		it++;
		i++;
	}

	//Отрисовывает кнопки.
	for (int i = Delta; i < Delta + 5; i++)
	{
		target.draw(**it);
		it++;
	}
	FloatRect Bounding;
	Bounding.left = WorkWindow->getView().getCenter().x - WorkWindow->getView().getSize().x / 2;
	Bounding.top = WorkWindow->getView().getCenter().y - WorkWindow->getView().getSize().y * 0.45;
	Bounding.width = WorkWindow->getView().getSize().x;
	Bounding.height = WorkWindow->getView().getSize().y * 0.6;
	Vector2f WorldMouseCoord = WorkWindow->mapPixelToCoords(Mouse::getPosition(*WorkWindow));
	if (Bounding.contains(WorldMouseCoord))
		if (IsCanBuilding)
		{
		
			RectangleShape rect;
			rect.setPosition((int)(WorldMouseCoord.x / 20) * 20, (int)(WorldMouseCoord.y / 20) * 20);
			rect.setFillColor(Color(0, 0, 0, 0));
			rect.setOutlineColor(Color::Green);
			rect.setOutlineThickness(3);
			rect.setSize(Vector2f(widthbuild, heightbuild));
			target.draw(rect);
		}

}

bool Construction::update()
{
	//Перечситывает координаты и передаёт их всех объектам, которые будут отрисованы.
	list<Building*>::iterator bit = Buildings->begin();
	ConstructionBoundary.left = (*bit)->getX() - 20 * ((BaseBuilding*)(*bit))->GetColonyLevel();
	ConstructionBoundary.top = (*bit)->getY() - 20 * ((BaseBuilding*)(*bit))->GetColonyLevel();
	ConstructionBoundary.width = 2 * 20 * ((BaseBuilding*)(*bit))->GetColonyLevel() + 100;
	ConstructionBoundary.height = 2 * 20 * ((BaseBuilding*)(*bit))->GetColonyLevel() + 100;
	x = WorkWindow->getView().getCenter().x + WorkWindow->getView().getSize().x * 0.17;
	y = WorkWindow->getView().getCenter().y + WorkWindow->getView().getSize().y * 0.17;
	width = WorkWindow->getView().getSize().x * 0.30;
	height = WorkWindow->getView().getSize().y * 0.30;
	NameTab.setPosition(x + 20, y + 5);
	VerticesConstruction[0].position = Vector2f(x, y);
	VerticesConstruction[1].position = Vector2f(x, y + height);
	VerticesConstruction[2].position = Vector2f(x + width, y + height);
	VerticesConstruction[3].position = Vector2f(x + width, y);

	list<Button*>::const_iterator it;
	int i = 0;
	for (it = ListButton.begin(); it != ListButton.end(); it++)
	{
		(*it)->SetXY(x + 25, y + 35 + i * 35);
		i++;
	}
	FloatRect Bounding;
	if (ConstructionIsProgress)
	{
		Bounding.left = WorkWindow->getView().getCenter().x - WorkWindow->getView().getSize().x / 2;
		Bounding.top = WorkWindow->getView().getCenter().y- WorkWindow->getView().getSize().y * 0.45;
		Bounding.width = WorkWindow->getView().getSize().x;
		Bounding.height = WorkWindow->getView().getSize().y * 0.6;
	}
	else
	{
		Bounding.left = x;
		Bounding.top = y;
		Bounding.width = width;
		Bounding.height = height;
	}
	Vector2f WorldMouseCoord = WorkWindow->mapPixelToCoords(Mouse::getPosition(*WorkWindow));
	if (!ConstructionIsProgress)
	{
		if (Bounding.contains(WorldMouseCoord))
		{
			//Начинает искать те кнопки, которые будут обработаны.
			int i = 0;
			list<Button*>::const_iterator it = ListButton.begin();

			while (i < Delta)
			{
				it++;
				i++;
			}

			//Обрабатывает кнопки.
			for (int i = Delta; i < Delta + 5; i++)
			{
				if ((*it)->isButtonPressed())
				{
					ConstructionIsProgress = true;
					selected = i;
					switch (selected)
					{
					case 0:
						widthbuild = 20;
						heightbuild = 20;
						break;
					case 1:
						widthbuild = 20;
						heightbuild = 20;
						break;
					case 2:
						widthbuild = 40;
						heightbuild = 40;
						break;
					case 3:
						widthbuild = 40;
						heightbuild = 40;
						break;
					case 4:
						widthbuild = 40;
						heightbuild = 60;
						break;
					}
				}
				it++;
			}
		}
	}
	else
	{
		if (Mouse::isButtonPressed(Mouse::Right))
		{
			ConstructionIsProgress = false;
			IsCanBuilding = false;
		}
		else
		{
			if (Bounding.contains(WorldMouseCoord))
			{
				if (ConstructionBoundary.contains(WorldMouseCoord)
					&& ConstructionBoundary.contains(Vector2f(WorldMouseCoord.x + widthbuild, WorldMouseCoord.y + heightbuild)))
				{
					IsCanBuilding = WorldMap->GetValueMap(WorldMouseCoord.x, WorldMouseCoord.y, widthbuild, heightbuild);
					if (Mouse::isButtonPressed(Mouse::Left))
					{
						ConstructionIsProgress = false;
						IsCanBuilding = false;
						int i = WorldMouseCoord.x / 20;
						int j = WorldMouseCoord.y / 20;
						list<Resource*>::iterator it;
						list<Resource*>::iterator it2;
						switch (selected)
						{
						case 0:
							it = Resources->begin();
							it2 = Resources->begin();
							while ((*it)->GetName() != "Iron")
								it++;
							if ((*it)->IsCanSpendResource(200))
							{
								(*it)->AddResource(-200);

								while ((*it2)->GetName() != "FreeWorkers")
									it2++;
								(*it2)->AddResource(5);
								it = Resources->begin();
								while ((*it)->GetName() != "XP")
									it++;

								Buildings->push_back(new SmallHouse(i * 20, j * 20, *it2, *it));
								WorldMap->SetValueMap(i * 20, j * 20, 20, 20);
							}
							break;
						case 1:
							it = Resources->begin();
							it2 = Resources->begin();
							while ((*it)->GetName() != "Iron")
								it++;
							if ((*it)->IsCanSpendResource(600) && WorldMap->GetValueMap(i * 20, j * 20, 20, 20, 3))
							{
								(*it)->AddResource(-600);
								bool IsOre = false;
								for (it2 = Resources->begin(); it2 != Resources->end(); it2++)
								{
									if ((*it2)->GetName() == "IronOre")
									{
										IsOre = true;
										break;
									}
								}
								if (!IsOre)
								{
									Resources->push_back(new Resource("IronOre", 0, "SeldomScene.otf", "IronOre.png"));
									it2 = Resources->end();
									it2--;
								}	
								Buildings->push_back(new IronOreMiner(i * 20, j * 20, *it2, *it));
								WorldMap->SetValueMap(i * 20, j * 20, 20, 20);
							}
							break;
						default:
							break;
						}
					}
				}
				else
					IsCanBuilding = false;
			}
			else
				IsCanBuilding = false;
		}
	}

	return ConstructionIsProgress;
}