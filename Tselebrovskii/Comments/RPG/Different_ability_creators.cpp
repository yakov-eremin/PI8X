#include "Different_ability_creators.h"

Damage_ability_creator::Damage_ability_creator(int damage)
{
	damage_formula = damage;
}

Class_ability* Damage_ability_creator::create_ability(float range, std::string desc)
{
	return new Damage_ability(damage_formula, range, desc);
}

Healing_ability_creator::Healing_ability_creator(int healing)
{
	healing_formula = healing;
}

Class_ability* Healing_ability_creator::create_ability(float range, std::string desc)
{
	return new Healing_ability(healing_formula, range, desc);
}

Status_ability_creator::Status_ability_creator(std::string status, int duration)
{
	applied_status = status;
	status_duration = duration;
}

Class_ability* Status_ability_creator::create_ability(float range, std::string desc)
{
	return new Status_ability(applied_status, status_duration, range, desc);
}
