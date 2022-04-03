#pragma once
#include "Environment.h"
#include "Background_generator.h"

class Map
{
private:
public:
	//���� ������ �������, get set ��� ��������� �����, �� ������ ��� �������� � ����.
	std::string name;
	int height;
	int width;
	std::string bg_image;
	Environment* env;
	Background_generator* bg_generator;
	std::string get_name();
	void set_name(std::string);
	Environment* get_env();
	void set_env(Environment*);
	void add_env_object(Unique_state_env_obj*);
	Map();
	Map(std::string);
	~Map();
	void load_bg_image();
	void set_bg_generator(Background_generator*);
};

