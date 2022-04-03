#include "Compound_object.h"

Compound_object::Compound_object()
{

}

Compound_object::Compound_object(std::string new_sprite)
{
	sprite = new_sprite;
}

void Compound_object::react()
{
	std::cout << "I'm compound with sprite " << sprite << " and I store those primitives: " << std::endl;
	for (auto prim : object_list)
	{
		prim->react();
	}
}

void Compound_object::add_env_obj(Environmental_object* obj)
{
	object_list.push_back(obj);
}

void Compound_object::remove_env_obj(int pos)
{
	object_list.erase(object_list.begin() + pos);
}