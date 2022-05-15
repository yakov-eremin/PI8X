#pragma once
#include "SFML/Graphics.hpp"
#include <string>

using namespace std;
using namespace sf;

/*!
	\brief ����� ������
	\details ����� �������� ������ ������� ������, �������� �������, ���������, ���������, ���������
*/
class Button : public Drawable, public Transformable
{
public:
	//NameFont � NameTexture ����������� � ���������, SizeText ����������� � ��������.
	Button(wstring _text, string NameFont, int _SizeText, string NameTexture, float _x, float _y, RenderWindow *window);
	/*!
		\brief ����� ��������� ������� �� ������
	*/

	bool isButtonPressed(); //��������� ������� �� ������.
	/*!
		\brief ����� �������� ������ ������
	*/
	Vector2f getSizeButton(); //�������� ������ ������.
	void SetXY(float _x, float _y);
private:
	RenderWindow *WorkWindow; //��������� �� ���� � ������� �������� ������.

	float x; 
	float y; 
	
	float width; //������ ������.
	float height; //������ ������.
	
	int SizeText;

	bool FlagIsButtonPressed;

	Text TextButton; //����� ������, ������� ����� ������� � ����� ������.
	Font FontButton; //����� ������.
	
	Texture TextureButton; //�������� ������.
	
	VertexArray VerticesButton; //������� ������.
	
	FloatRect BoundingBox; //��������������� �������.

	/*!
		\brief ����� ��������� ������ �� ������
	*/
	
	virtual void draw(RenderTarget &target, RenderStates states) const; //��������� ������ �� ������.
	
	bool isButtonFocus(); //��������� �������� ���� �� ������.
	
	void setScale(float factorX, float factorY); //��������������� ������� setScale ��� ����������� ��������� ������.
};