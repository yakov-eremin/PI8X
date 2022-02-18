#pragma once
#include "Ability_visitor.h"
#include "Abilities.h"
#include <cmath>
#include <string>

class Damage_ability; //??
class Healing_ability;
class Status_ability;

class Scaling_visitor : public Ability_visitor
{
public:
	float formula_multiplier;
	int status_extender;
	void visit_damage(Damage_ability*) override;
	void visit_healing(Healing_ability*) override;
	void visit_status(Status_ability*) override;
	Scaling_visitor(float, int);
};

