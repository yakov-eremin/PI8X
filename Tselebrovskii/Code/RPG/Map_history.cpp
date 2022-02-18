#include "Map_history.h"

void Map_history::save_map()
{
	Map_snapshot* snap = new Map_snapshot(map);
	snapshot_history.push_back(snap);
}

void Map_history::restore_snapshot(int n)
{
	Map_snapshot* snap = snapshot_history[n];
	map->name = snap->get_name();
	map->height = snap->get_height();
	map->width = snap->get_width();
	map->env = new Environment(snap->get_environment()->pool);
	*(map->env) = *(snap->get_environment());
	map->bg_image = snap->get_bg_image();
	map->bg_generator = new Background_generator();
	*(map->bg_generator) = *(snap->get_background_generator());
}

void Map_history::get_history()
{
	for (auto snap : snapshot_history)
	{
		std::cout << "���� ������ " << snap->get_snapshot_date() << std::endl;
		std::cout << "��� ����� " << snap->get_name() << std::endl;
		std::cout << "������ ����� " << snap->get_height() << std::endl;
		std::cout << "������ ����� " << snap->get_width() << std::endl;
		std::cout << "�������� ����������� ������� ���� " << snap->get_bg_image() << std::endl;
		//TODO:���-������ �������� ���������� �� ��������� � ���������� ������� ����? �� � ���������� ���� ���������� ���
	}
}

Map_history::Map_history(Map* inp_map)
{
	map = inp_map;
}
