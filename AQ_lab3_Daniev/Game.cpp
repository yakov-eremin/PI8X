#include "Game.h"

using namespace sf;
using namespace std;

Game::Game(int _width, int _height, string _name)
{
	//Задаёт ширину, высоту и имя окна игры.
	width = _width;
	height = _height;
	Name = _name;

	//Создание окна игры.
	window = new RenderWindow(VideoMode(width, height), Name);
	window->setVerticalSyncEnabled(true);

	//Создание формы меню.
	form = new StartMenuForm("StartMenu.png", float(0), float(0), float(width), float(height), window);

	//Установка флагов.
	isGameStart = false;
	isGamePause = false;

	//Пока игра не запученна этих элементов не существует.
	GameMap = NULL;
	hud = NULL;

	//Время используемое во мремя игры.
	GameTime = NULL;
	PauseTime = NULL;

	//Установка вида изначально для меню.
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

//Цикл с игрой.
void Game::PlaingGame()
{
	while (window->isOpen())
	{
		Time TimeCycle = clock.restart();
		sf::Event event;
		while (window->pollEvent(event))
		{
			//Закрытие игры по крестику.
			if (event.type == sf::Event::Closed)
			{
				window->close();
			}
		}

		update(TimeCycle);
		
		drawwindow();
	}
}

//Проверяет все элементы игры и логика игры.
void Game::update(Time time)
{
	
	if (!isGameStart) //Если игра не началась.
	{
		int stat = form->update();
		if (stat == 1)
			NewGame();
	}
	else //Если игра началась.
	{
		//Переход в состояние паузы и наоборот.
		if (Keyboard::isKeyPressed(Keyboard::Escape) && PauseTime->asSeconds() > 0.5)
		{
			//Создаёт счётчит времени в режиме паузы.
			delete PauseTime;
			PauseTime = new Time();
			if (!isGamePause)
				isGamePause = true;
			else
				isGamePause = false;
		}
		
		//Состояние игры при потере фокуса выставляется в паузу.
		if (!window->hasFocus())
			isGamePause = true;

		//Считает время в одном из режимах.
		*PauseTime += time;

		if (!isGamePause) //Если игра не на паузе.
		{ 
			//Считает игровое время в игре.
			*GameTime += time;
			list<Building*>::iterator bit;
			for (bit = Buildings.begin(); bit != Buildings.end(); bit++)
			{
				(**bit).update();
			}
			GameMap->update();
			hud->update();
		}
		else //Игра приостановлена.
		{

		}
	}

}

//Отрисовывает все элементы игры.
void Game::drawwindow()
{
	//Очистка экрана.
	window->clear();
	
	//Установка вида.
	window->setView(WorldView);

	//Отображение в буфере.
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
		
		if (isGamePause)//Отрисовка меню при паузе.
		{
			 
		}
	}

	//Отображение на экране.
	window->display();
}

//Начало игры. Загрузка карты 
//и установка первых юнитов и зданий, установка флага.
void Game::NewGame()
{
	//Установка флага.
	isGameStart = true;

	//Создание игровой карты.
	GameMap = new Map("Map1.txt", "Map1Set.png", window, &WorldView);

	//Добавление ресурсов.
	Resources.push_back(new Resource("XP", 0, "SeldomScene.otf", "XP.png"));
	Resources.push_back(new Resource("Iron", 1000, "SeldomScene.otf", "Iron.png"));
	Resources.push_back(new Resource("FreeWorkers", 10, "SeldomScene.otf", "FreeWorkers.png"));

	//Создание построек.
	list<Resource*>::iterator it = Resources.begin();
	Buildings.push_back(new BaseBuilding(GameMap->GetWidthOfMap() / 2, GameMap->GetHeightOfMap() / 2, *it, *it));
	GameMap->SetValueMap(GameMap->GetWidthOfMap() / 2, GameMap->GetHeightOfMap() / 2, 80, 80);

	//Создание HUD.
	hud = new HUD("hud.png", "Minimap.png", GameMap, &Buildings, &Resources, window);

	//Удаляет объекты, которые не относятся к игровому процессу.
	delete form;
	form = NULL;

	//Создание игрового времени.
	GameTime = new Time();
	PauseTime = new Time();

	//Устанавливает новый обзор для WorldView.
	WorldView.setCenter(float(GameMap->GetWidthOfMap() / 2), float(GameMap->GetHeightOfMap() / 2));
}

//Закончить игру и выйти в главное меню.
void Game::FinishGame()
{
	isGameStart = false;
	isGamePause = false;

	//Создание формы меню.
	form = new StartMenuForm("StartMenu.png", 0, 0, float(width), float(height), window);

	//Ощичает списки.
	Buildings.clear();
	Resources.clear();

	//Удаляет объекты, которые относятся к игровому процессу.
	delete hud;
	delete GameMap;

	hud = NULL;
	GameMap = NULL;

	//Обнуление игрового времени (удаление объекта).
	delete GameTime;
	delete PauseTime;

	GameTime = NULL;
	PauseTime = NULL;

	//Устанавливает новый обзор для WorldView.
	WorldView.setCenter(float(width / 2), float(height / 2));
}