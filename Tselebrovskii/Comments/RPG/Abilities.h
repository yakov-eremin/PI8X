#pragma once
#include "Class_ability.h"
#include <iostream>

class Character;

class Damage_ability : public Class_ability
{
private:
	
public:
	int damage_formula;
	void cast(Character*) override;
	Damage_ability(int, float, std::string);
	void accept_visitor(Ability_visitor*) override;
};

class Healing_ability : public Class_ability
{
private:
	
public:
	int healing_formula;
	void cast(Character*) override;
	Healing_ability(int, float, std::string);
	void accept_visitor(Ability_visitor*) override;
};

class Status_ability : public Class_ability
{
private:
	
public:
	std::string applied_status;
	int status_duration;
	void cast(Character*) override;
	Status_ability(std::string, int, float, std::string);
	void accept_visitor(Ability_visitor*) override;
};