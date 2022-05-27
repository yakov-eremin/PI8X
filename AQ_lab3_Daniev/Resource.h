#pragma once

#include "SFML/Graphics.hpp"
#include <string>
#include <iostream>
#include <sstream>

using namespace sf;
using namespace std;

/*!
	\brief ����� �������
	\details ��������� �������� ����
*/

class Resource : public Drawable
{
public:
	Resource(string Name, float count, string FontName, string NameTexture);
	void SetXY(float _x, float _y);
	float GetWidth();
	string GetName();

	/*!
		\brief ����� ������������� ��������
	*/

	bool IsCanSpendResource(float count);//���������� ����� �� ������������ ����������� ���������� �������.

	/*!
		\brief ����� ��������� ��������
	*/

	void AddResource(float count);//���������� ��� ��������� ���������� �������.
private:
	string NameResource; //�������� �������.
	float CountOfRecources; //���������� ������� � ������.


	//��� ����������� ������� � HUD.
	float x;
	float y;
	float width;
	Font FontResource;
	Text NumberResource; 
	Texture TextureResource;//�������� �������.
	VertexArray VerticesResource; //������� ��� ���������.
	/*!
		\brief ����� ���������
	*/

	virtual void draw(RenderTarget &target, RenderStates states) const; //������������ �������� �������.
};