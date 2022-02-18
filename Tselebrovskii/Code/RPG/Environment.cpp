#include "Environment.h"

void Environment::add_NPC()
{
	assigned_NPCs.push_back(pool->get_NPC());
}

void Environment::spawn_NPCs()
{
	//TODO: спавнить неписей используя итератор
}

void Environment::add_env_object(Unique_state_env_obj* env_obj)
{
	env_objects.push_back(env_obj);
	std::cout << "Added ";
	env_obj->react();
	std::cout << std::endl;
}

void Environment::relocate_spawn_point(int x, int y, int index)
{
	spawn_points[index].first = x;
	spawn_points[index].second = y;
}

Environment::Environment(NPC_pool* new_pool)
{
	pool = new_pool;
}
