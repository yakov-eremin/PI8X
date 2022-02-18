#include "Class_ability.h"

Class_ability::Class_ability(float range, std::string base_desc)
{
	cast_range = range;
	desc = base_desc;
}

Class_ability::Class_ability()
{

}

void Class_ability::cast(Character* chr)
{

}

std::string Class_ability::get_description()
{
	return desc;
}

void Class_ability::accept_visitor(Ability_visitor*)
{
}
