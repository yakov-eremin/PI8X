#include "Game.h"

using namespace sf;
using namespace std;

Game::Game(int _width, int _height, string _name)
{
	//����� ������, ������ � ��� ���� ����.
	width = _width;
	height = _height;
	Name = _name;

	//�������� ���� ����.
	window = new RenderWindow(VideoMode(width, height), Name);
	window->setVerticalSyncEnabled(true);

	//�������� ����� ����.
	form = new StartMenuForm("StartMenu.png", float(0), float(0), float(width), float(height), window);

	//��������� ������.
	isGameStart = false;
	isGamePause = false;

	//���� ���� �� ��������� ���� ��������� �� ����������.
	GameMap = NULL;
	hud = NULL;

	//����� ������������ �� ����� ����.
	GameTime = NULL;
	PauseTime = NULL;

	//��������� ���� ���������� ��� ����.
	WorldView.setCenter(float(width / 2), float(height / 2));
	WorldView.setSize(float(width), float(height));
}

Game::~Game()
{
	if (hud != NULL)
		delete hud;
	if (GameMap != NULL)
		delete GameMap;
	if (GameTime != NULL)
		delete GameTime;
	if (PauseTime != NULL)
		delete PauseTime;
	if (form != NULL)
		delete form;
	delete window;
}

//���� � �����.
void Game::PlaingGame()
{
	while (window->isOpen())
	{
		Time TimeCycle = clock.restart();
		sf::Event event;
		while (window->pollEvent(event))
		{
			//�������� ���� �� ��������.
			if (event.type == sf::Event::Closed)
			{
				window->close();
			}
		}

		update(TimeCycle);
		
		drawwindow();
	}
}

//��������� ��� �������� ���� � ������ ����.
void Game::update(Time time)
{
	
	if (!isGameStart) //���� ���� �� ��������.
	{
		int stat = form->update();
		if (stat == 1)
			NewGame();
	}
	else //���� ���� ��������.
	{
		//������� � ��������� ����� � ��������.
		if (Keyboard::isKeyPressed(Keyboard::Escape) && PauseTime->asSeconds() > 0.5)
		{
			//������ ������� ������� � ������ �����.
			delete PauseTime;
			PauseTime = new Time();
			if (!isGamePause)
				isGamePause = true;
			else
				isGamePause = false;
		}
		
		//��������� ���� ��� ������ ������ ������������ � �����.
		if (!window->hasFocus())
			isGamePause = true;

		//������� ����� � ����� �� �������.
		*PauseTime += time;

		if (!isGamePause) //���� ���� �� �� �����.
		{ 
			//������� ������� ����� � ����.
			*GameTime += time;
			list<Building*>::iterator bit;
			for (bit = Buildings.begin(); bit != Buildings.end(); bit++)
			{
				(**bit).update();
			}
			GameMap->update();
			hud->update();
		}
		else //���� ��������������.
		{

		}
	}

}

//������������ ��� �������� ����.
void Game::drawwindow()
{
	//������� ������.
	window->clear();
	
	//��������� ����.
	window->setView(WorldView);

	//����������� � ������.
	if (!isGameStart)
		window->draw(*form);
	else
	{
		window->draw(*GameMap);
		list<Building*>::iterator bit;
		for (bit = Buildings.begin(); bit != Buildings.end(); bit++)
		{
			window->draw(**bit);
		}
		window->draw(*hud);
		
		if (isGamePause)//��������� ���� ��� �����.
		{
			 
		}
	}

	//����������� �� ������.
	window->display();
}

//������ ����. �������� ����� 
//� ��������� ������ ������ � ������, ��������� �����.
void Game::NewGame()
{
	//��������� �����.
	isGameStart = true;

	//�������� ������� �����.
	GameMap = new Map("Map1.txt", "Map1Set.png", window, &WorldView);

	//���������� ��������.
	Resources.push_back(new Resource("XP", 0, "SeldomScene.otf", "XP.png"));
	Resources.push_back(new Resource("Iron", 1000, "SeldomScene.otf", "Iron.png"));
	Resources.push_back(new Resource("FreeWorkers", 10, "SeldomScene.otf", "FreeWorkers.png"));

	//�������� ��������.
	list<Resource*>::iterator it = Resources.begin();
	Buildings.push_back(new BaseBuilding(GameMap->GetWidthOfMap() / 2, GameMap->GetHeightOfMap() / 2, *it, *it));
	GameMap->SetValueMap(GameMap->GetWidthOfMap() / 2, GameMap->GetHeightOfMap() / 2, 80, 80);

	//�������� HUD.
	hud = new HUD("hud.png", "Minimap.png", GameMap, &Buildings, &Resources, window);

	//������� �������, ������� �� ��������� � �������� ��������.
	delete form;
	form = NULL;

	//�������� �������� �������.
	GameTime = new Time();
	PauseTime = new Time();

	//������������� ����� ����� ��� WorldView.
	WorldView.setCenter(float(GameMap->GetWidthOfMap() / 2), float(GameMap->GetHeightOfMap() / 2));
}

//��������� ���� � ����� � ������� ����.
void Game::FinishGame()
{
	isGameStart = false;
	isGamePause = false;

	//�������� ����� ����.
	form = new StartMenuForm("StartMenu.png", 0, 0, float(width), float(height), window);

	//������� ������.
	Buildings.clear();
	Resources.clear();

	//������� �������, ������� ��������� � �������� ��������.
	delete hud;
	delete GameMap;

	hud = NULL;
	GameMap = NULL;

	//��������� �������� ������� (�������� �������).
	delete GameTime;
	delete PauseTime;

	GameTime = NULL;
	PauseTime = NULL;

	//������������� ����� ����� ��� WorldView.
	WorldView.setCenter(float(width / 2), float(height / 2));
}