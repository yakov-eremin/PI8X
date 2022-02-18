#pragma once

class Damage_ability; //??
class Healing_ability;
class Status_ability;

class Ability_visitor
{
public:
	virtual void visit_damage(Damage_ability*);
	virtual void visit_healing(Healing_ability*);
	virtual void visit_status(Status_ability*);
};

