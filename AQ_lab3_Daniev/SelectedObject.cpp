#include "SelectedObject.h"

SelectedObject::SelectedObject(string NameFont, string NameTexture, list<Building*> *Build, list<Resource*> *Res, Map *map, RenderWindow *window)
{
	//������������� ���������.
	WorkWindow = window;
	Buildings = Build;
	Resources = Res;
	WorldMap = map;
	//��������� ���������� �� �������� ������.
	list<Building*>::iterator it = Buildings->begin();
	CurrentObject = *it;

	//�������� ���������� �� �����.
	x = 0;
	y = 0;
	width = 0;
	height = 0;

	//������� ������� �� �������, ��� � ��������.
	FontTab.loadFromFile("Resources/Fonts/" + NameFont);
	NameTab.setString(L"������� ������");
	NameTab.setFont(FontTab);
	NameTab.setFillColor(Color::Black);
	NameTab.setCharacterSize(15);
	NameTab.setPosition(x, y);

	//��� 1 ��������� ����.
	wstringstream ss; 
	wstring tabstr = L"�������: ";
	wstring str;
	ss.clear();
	ss << int(CurrentObject->GetWorkers());
	ss >> str;
	tabstr += str + "/";
	ss.clear();
	ss << int(CurrentObject->GetMaxWorkers());
	ss >> str;
	tabstr += str;
	NumberTab1.setString(tabstr);
	NumberTab1.setFont(FontTab);
	NumberTab1.setFillColor(Color::Black);
	NumberTab1.setCharacterSize(15);
	NumberTab1.setPosition(x, y);

	//��� 2 ��������� ����.
	tabstr = L"������� ����: ";
	ss.clear();
	ss << int(CurrentObject->GetSpecial());
	ss >> str;
	tabstr += str;
	NumberTab2.setString(tabstr);
	NumberTab2.setFont(FontTab);
	NumberTab2.setFillColor(Color::Black);
	NumberTab2.setCharacterSize(15);
	NumberTab2.setPosition(x, y);

	//��������� ������������� (���) �������.
	TextureSelected.loadFromFile("Resources/Images/" + NameTexture);
	VerticesSeelcted.setPrimitiveType(Quads);
	VerticesSeelcted.resize(4);
	VerticesSeelcted[0].texCoords = Vector2f(0, 0);
	VerticesSeelcted[1].texCoords = Vector2f(0, TextureSelected.getSize().y);
	VerticesSeelcted[2].texCoords = Vector2f(TextureSelected.getSize().x, TextureSelected.getSize().y);
	VerticesSeelcted[3].texCoords = Vector2f(TextureSelected.getSize().x, 0);
	VerticesSeelcted[0].position = Vector2f(x, y);
	VerticesSeelcted[1].position = Vector2f(x, y + height);
	VerticesSeelcted[2].position = Vector2f(x + width, y + height);
	VerticesSeelcted[3].position = Vector2f(x + width, y);

	//������ ��������.
	//������ ������ ������.
	ListButton.push_back(new Button(L"�������� ��������    ", NameFont, 10, "Button1.png", x, y, WorkWindow));
	ListButton.push_back(new Button(L"������ ��������      ", NameFont, 10, "Button1.png", x, y, WorkWindow));
	ListButton.push_back(new Button(L"������������         ", NameFont, 10, "Button1.png", x, y, WorkWindow));
	ListButton.push_back(new Button(L"���������� ������    ", NameFont, 10, "Button1.png", x, y, WorkWindow));
	
}

void SelectedObject::update()
{
	//������������� ���������� � ������� �� ���� ��������, ������� ����� ����������.
	x = WorkWindow->getView().getCenter().x - WorkWindow->getView().getSize().x * 0.30;
	y = WorkWindow->getView().getCenter().y + WorkWindow->getView().getSize().y * 0.17;
	width = WorkWindow->getView().getSize().x * 0.46;
	height = WorkWindow->getView().getSize().y * 0.30;
	NameTab.setPosition(x + 25, y + 5);
	VerticesSeelcted[0].position = Vector2f(x, y);
	VerticesSeelcted[1].position = Vector2f(x, y + height);
	VerticesSeelcted[2].position = Vector2f(x + width, y + height);
	VerticesSeelcted[3].position = Vector2f(x + width, y);
	
	//��������� 1 ��������� ����.
	wstringstream ss;
	wstring tabstr = L"�������: ";
	wstring str;
	ss << int(CurrentObject->GetWorkers());
	ss >> str;
	tabstr = tabstr +  str + "/";
	ss.clear();
	ss << int(CurrentObject->GetMaxWorkers());
	ss >> str;
	tabstr = tabstr + str;
	NumberTab1.setString(tabstr);
	NumberTab1.setPosition(x + 25, y + 115);

	//��������� 1 ��������� ����.
	if (CurrentObject->GetName() == L"������� ������")
		tabstr = L"������� ����: ";
	if (CurrentObject->GetName() == L"��������� ���")
		tabstr = L"��������� ������� (����������� 15): ";
	if (CurrentObject->GetName() == L"�������� �������� ����")
		tabstr = L"���������� ����: ";
	ss.clear();
	ss << int(CurrentObject->GetSpecial());
	ss >> str;
	tabstr = tabstr + str;
	NumberTab2.setString(tabstr);
	NumberTab2.setPosition(x + 25, y + 145);
	list<Button*>::const_iterator  it;
	int i = 0;
	for (it = ListButton.begin(); it != ListButton.end(); it++)
	{
		(*it)->SetXY(x + 25 + (i / 2) * 300, y + 35 + (i % 2) * 40);
		i++;
	}
	FloatRect Bounding;
	Bounding.left = x;
	Bounding.top = y;
	Bounding.width = width;
	Bounding.height = height;
	Vector2f WorldMouseCoord = WorkWindow->mapPixelToCoords(Mouse::getPosition(*WorkWindow));
	if (Bounding.contains(WorldMouseCoord))
	{
		i = 0;
		for (it = ListButton.begin(); it != ListButton.end(); it++)
		{
			if ((*it)->isButtonPressed())
			{
				list<Building*>::iterator bit;
				list<Resource*>::iterator rit;
				float _x;
				float _y;
				float _width;
				float _height;
				int workers;
				switch (i)
				{
				case 3:
					bit = Buildings->begin();
					while (*bit != CurrentObject)
						bit++;
					_x = (*bit)->Square().left;
					_y = (*bit)->Square().top;
					_width = (*bit)->Square().width;
					_height = (*bit)->Square().height;
					workers = CurrentObject->GetWorkers();
					if (CurrentObject->GetName() == L"������� ������")
					{
						rit = Resources->begin();
						while ((*rit)->GetName() != "FreeWorkers")
							rit++;
						(*rit)->AddResource(workers);
					}
					if (CurrentObject->Destroy())
					{
						Buildings->erase(bit);
						bit = Buildings->begin();
						CurrentObject = *bit;
						NameTab.setString(L"������� ������");
						WorldMap->Clear(_x, _y, _width, _height);
						rit = Resources->begin();
						while ((*rit)->GetName() != "FreeWorkers")
							rit++;
						(*rit)->AddResource(workers);
					}
					break;
				case 0:
					rit = Resources->begin();
					while ((*rit)->GetName() != "FreeWorkers")
						rit++;
					if ((*rit)->IsCanSpendResource(1) && !CurrentObject->IsMaxWorkers())
					{
						(*rit)->AddResource(-1);
						CurrentObject->AddWorkers(1);
					}
					break;
				case 1:
					rit = Resources->begin();
					while ((*rit)->GetName() != "FreeWorkers")
						rit++;
					if (!CurrentObject->IsNoWorkers())
					{
						(*rit)->AddResource(1);
						CurrentObject->AddWorkers(-1);
					}
					break;
				case 2:
					CurrentObject->Production();
					break;
				}
				break;
			}
				i++;
		}
	}
	Bounding.left = WorkWindow->getView().getCenter().x - WorkWindow->getView().getSize().x / 2;
	Bounding.top = WorkWindow->getView().getCenter().y - WorkWindow->getView().getSize().y * 0.45;
	Bounding.width = WorkWindow->getView().getSize().x;
	Bounding.height = WorkWindow->getView().getSize().y * 0.6;
	if (Bounding.contains(WorldMouseCoord))
	{ 
		list<Building*>::iterator it;
		if (Mouse::isButtonPressed(Mouse::Left))
		{
			for (it = Buildings->begin(); it != Buildings->end(); it++)
			{
				if ((*it)->Square().contains(WorldMouseCoord))
				{
					NameTab.setString((*it)->GetName());
					CurrentObject = *it;
					break;
				}
			}
		}
	}
}

void SelectedObject::draw(RenderTarget &target, RenderStates states) const
{
	//������� ��������.
	states.texture = &TextureSelected;

	//��������� �����.
	target.draw(VerticesSeelcted, states);

	//��������� ��������.
	target.draw(NameTab);
	target.draw(NumberTab1);
	target.draw(NumberTab2);

	//��������� ������.
	list<Button*>::const_iterator  it;
	for (it = ListButton.begin(); it != ListButton.end(); it++)
	{
		target.draw(**it);
	}
}