#include "Map_snapshot.h"

Map_snapshot::Map_snapshot(Map* map)
{
	name = map->name;
	height = map->height;
	width = map->width;
	env = new Environment(map->env->pool);
	*env = *(map->env);
	bg_image = map->bg_image;
	background_generator = new Background_generator();
	*background_generator = *(map->bg_generator);
	time_t lt;
	lt = time(NULL);
	snapshot_date = ctime(&lt);
}

std::string Map_snapshot::get_name()
{
	return name;
}

int Map_snapshot::get_height()
{
	return height;
}

int Map_snapshot::get_width()
{
	return width;
}

Environment* Map_snapshot::get_environment()
{
	return env;
}

std::string Map_snapshot::get_bg_image()
{
	return bg_image;
}

Background_generator* Map_snapshot::get_background_generator()
{
	return background_generator;
}

std::string Map_snapshot::get_snapshot_date()
{
	return snapshot_date;
}
