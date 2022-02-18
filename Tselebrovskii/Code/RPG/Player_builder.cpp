#include "Player_builder.h"

Player_builder::Player_builder()
{
	result = new Player();
}

void Player_builder::build_health(int health)
{
	result->set_health(health);
}

void Player_builder::build_resource(int resource)
{
	result->set_resource(resource);
}

void Player_builder::build_karma_points(int karma)
{
	result->karma_points = karma;
}

void Player_builder::build_name(std::string name)
{
	result->set_name(name);
}


Player* Player_builder::get_player()
{
	return result;
}
