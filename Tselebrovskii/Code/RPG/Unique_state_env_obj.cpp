#include "Unique_state_env_obj.h"

Unique_state_env_obj::Unique_state_env_obj(std::string new_name, int new_health, int x, int y)
{
	name = new_name;
	health = new_health;
	coordinates = std::make_pair(x, y);
	behaviour = new Active(); //по умолчанию все объекты активные
}

void Unique_state_env_obj::set_env_obj(Environmental_object* new_env_obj)
{
	env_obj = new_env_obj;
}

void Unique_state_env_obj::react()
{
	std::cout << "I'm a " << name << " at (" << coordinates.first << "," << coordinates.second << ")" << std::endl;
	if (env_obj != nullptr)
		env_obj->react();
	behaviour->react();
}

void Unique_state_env_obj::set_behaviour(std::string str)
{
	if (str == "active")
		behaviour = new Active();
	if (str == "inactive")
		behaviour = new Inactive();
	if (str == "destroyed")
		behaviour = new Destroyed();
}

Unique_state_env_obj* Unique_state_env_obj::clone()
{
	Unique_state_env_obj* clone = new Unique_state_env_obj(name, health, coordinates.first, coordinates.second);
	return clone;
}
