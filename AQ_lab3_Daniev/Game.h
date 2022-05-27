#pragma once
#include "Form.h"
#include "HUD.h"
#include "Buildings.h"

using namespace std;
using namespace sf;

/*!
	\brief ����� ����
	\details �������� ����� ����.
*/

class Game 
{
public:
	void PlaingGame(); // ������ ����.
	Game(int _width, int _hieght, string _name); //�����������, ���������� ��������� ��� �������� ����.
	~Game();
private:

	/*!
		\brief ����� ������ ����
	*/

	void NewGame(); //������ ����� ����.

	/*!
		\brief ����� �������� ����
	*/

	void FinishGame(); //��������� ���� � ����� � ������� ����.
	
	/*!
		\brief ����� �������� �����
	*/

	void update(Time time); //��������� ��� �������� ���� � ������ ����.

	/*!
		\brief ����� ���������
	*/
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