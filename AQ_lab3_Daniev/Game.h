#pragma once
#include "Form.h"
#include "HUD.h"
#include "Buildings.h"

using namespace std;
using namespace sf;

class Game 
{
public:
	void PlaingGame(); // ������ ����.
	Game(int _width, int _hieght, string _name); //�����������, ���������� ��������� ��� �������� ����.
	~Game();
private:
	void NewGame(); //������ ����� ����.
	void FinishGame(); //��������� ���� � ����� � ������� ����.
	
	void update(Time time); //��������� ��� �������� ���� � ������ ����.
	void drawwindow(); //������������ ��� �������� ����.
	
	RenderWindow *window; //���� ����.
	
	Form *form; //��������� �� ����� ����, ���� �����.
	
	bool isGameStart; //���� ������ ����.
	bool isGamePause; //���� ������������ ����.
	
	Clock clock; 
	Time *GameTime; //������� �����, ���������� 0.
	Time *PauseTime; //������������ �������� �������, ����� ���������� �� �������.
	
	int width; //������ ���� ����.
	int height; //������ ���� ����.
	
	string Name; //��� ���� ����.
	
	Map *GameMap; //������� �����.

	View WorldView; //������� ���, ��� �������� � ����.

	HUD *hud; //HUD ������, ���������� ���������, ��������� ���������� ����� ��� ������, �������� � ���������.
	
	list<Resource*> Resources;//������ ��������, ������� �������� ������.

	list<Building*> Buildings;//������ ��������, ������� ������� �������.
};