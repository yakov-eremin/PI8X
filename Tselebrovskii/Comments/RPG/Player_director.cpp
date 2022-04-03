#include "Player_director.h"

Player* Player_director::make_warrior()
{
	builder->build_health(200);
	builder->build_resource(0);
	builder->build_name("������ ����-�-���");
	builder->build_karma_points(10);
	//builder->build_class(1,1);
	return builder->get_player();
}

Player* Player_director::make_mage()
{
	builder->build_health(50);
	builder->build_resource(200);
	builder->build_name("��������� ��� ����");
	builder->build_karma_points(-5);
	//builder->build_class(2,2);
	return builder->get_player();
}

Player* Player_director::make_custom()
{
	std::cout << "������ ���������� �������� ���������? y/n" << std::endl;
	char ans;
	std::cin >> ans;
	if (ans == 'y')
	{
		std::cout << "������� ������������ �������� ��������� " << std::endl;
		int health;
		std::cin >> health;
		builder->build_health(health);
	}
	std::cout << "������ ���������� ������ ���������? y/n" << std::endl;
	std::cin >> ans;
	if (ans == 'y')
	{
		std::cout << "������� ������������ �������� ������� ��������� " << std::endl;
		int resource;
		std::cin >> resource;
		builder->build_resource(resource);
	}
	std::cout << "������ ���������� �� ���������? y/n" << std::endl;
	std::cin >> ans;
	if (ans == 'y')
	{
		std::cout << "������� �� ��������� " << std::endl;
		std::string name;
		std::cin >> name;
		builder->build_name(name);
	}
	std::cout << "������ ���������� ����� ���������? y/n" << std::endl;
	std::cin >> ans;
	if (ans == 'y')
	{
		std::cout << "������� ���� ����� ��������� " << std::endl;
		int karma;
		std::cin >> karma;
		builder->build_karma_points(karma);
	}
	return builder->get_player();
}

Player_director::Player_director()
{
	builder = new Player_builder();
}
