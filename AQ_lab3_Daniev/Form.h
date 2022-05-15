#pragma once
#include "Button.h"

using namespace sf;

/*!
	\brief ����� �����
	\details ����������� ����� �����.
*/

//����������� ����� �����.
class Form : public Drawable
{
public:
	Form(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window);
	virtual int update() = 0; //��������� ������ �����.
	void setStatus(int _status);//������������� ������ �����.
protected:
	RenderWindow *WorkWindow;
	
	float x;
	float y;
	
	float width; //������ �����.
	float height; //������ �����.
	
	int status; //��������� �����.
	
	Button **ArrayButton; //������ ������.
	
	int AmountOfButtons; //���������� ������ � �����. 
	
	Texture TextureForm; //�������� �����.
	
	VertexArray VerticesForm; //������� �����.

	/*!
		\brief ����� �������� ��������� �����
	*/
	
	virtual int checkStatus(); //��������� ��������� �����.
	
	/*!
		\brief ����� ���������
	*/

	virtual void draw(RenderTarget &target, RenderStates states) const; //��������� ����� �� ������.
};

/*!
	\brief ����� ������ �� �����
	
*/


//����� ��� ������ �� ����.
class ExitForm : public Form
{
public:
	ExitForm(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window);
	~ExitForm();
	/*!
		\brief ����� ��������� �����
	*/

	virtual int update(); //��������� �����.
};

/*!
	\brief ����� �������� ���� ��� ����
	\details/����� �������� ���� ��� ����.
*/

//����� �������� ���� ��� ����.
class StartMenuForm : public Form
{
public:
	StartMenuForm(string NameTexture, float _x, float _y, float _width, float _height, RenderWindow *window);
	~StartMenuForm();
	virtual int update(); //��������� �������� ����.
private:
	ExitForm *exitForm;
	
	/*!
		\brief ����� ���������
	*/

	virtual void draw(RenderTarget &target, RenderStates states) const; //��������� ����� �� ������.
};