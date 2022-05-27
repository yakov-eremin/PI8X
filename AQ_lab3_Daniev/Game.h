#pragma once
#include "Form.h"
#include "HUD.h"
#include "Buildings.h"

using namespace std;
using namespace sf;

/*!
	\brief Класс игры
	\details основной класс игры.
*/

class Game 
{
public:
	void PlaingGame(); // Начало игры.
	Game(int _width, int _hieght, string _name); //Конструктор, передаются аргументы для создания окна.
	~Game();
private:

	/*!
		\brief метод начала игры
	*/

	void NewGame(); //Начать новую игру.

	/*!
		\brief метод закрытия игры
	*/

	void FinishGame(); //Закончить игру и выйти в главное меню.
	
	/*!
		\brief метод проверки карты
	*/

	void update(Time time); //Проферяет все элементы игры и логика игры.

	/*!
		\brief метод отричовки
	*/
	void drawwindow(); //Отрисовывает все элементы игры.
	
	RenderWindow *window; //Окно игры.
	
	Form *form; //Указатель на формы меню, меню паузы.
	
	bool isGameStart; //Флаг начала игры.
	bool isGamePause; //Флаг приостановки игры.
	
	Clock clock; 
	Time *GameTime; //Игровое время, изначально 0.
	Time *PauseTime; //Подсчитывает задержку времени, между переходами из режимов.
	
	int width; //Ширина окна игры.
	int height; //Высота окна игры.
	
	string Name; //Имя окна игры.
	
	Map *GameMap; //Игровая карта.

	View WorldView; //Мировой вид, для действия в игре.

	HUD *hud; //HUD игрока, отображает миникарту, состояние выбранного юнита или здания, действия с выбранным.
	
	list<Resource*> Resources;//Список ресурсов, которые доступны игроку.

	list<Building*> Buildings;//Список построек, которые созданы игроком.
};