#include "Map.h"

std::string Map::get_name()
{
	return name;
}

Environment* Map::get_env()
{
	return this->env;
}

void Map::set_name(std::string input_name)
{
	this->name = input_name;
	this->height = 100;
	this->width = 100;
	this->env = new Environment(new NPC_pool(10));
}

Map::Map() 
{
	this->name = "Карта";
	this->height = 100;
	this->width = 100;
	this->env = new Environment(new NPC_pool(10));
}

Map::Map(std::string input_name) 
{
	this->name = input_name;
}

Map::~Map() {}

void Map::load_bg_image()
{
	bg_image = bg_generator->generate_background();
	std::cout << "Background changed to " << bg_image << std::endl;
}

void Map::set_bg_generator(Background_generator* bg_gen)
{
	bg_generator = bg_gen;
}

void Map::set_env(Environment* new_env)
{
	env = new_env;
}

void Map::add_env_object(Unique_state_env_obj* new_obj)
{
	env->add_env_object(new_obj);
}