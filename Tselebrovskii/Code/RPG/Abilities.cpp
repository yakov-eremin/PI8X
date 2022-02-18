#include "Abilities.h"
#include "Character.h"

Damage_ability::Damage_ability(int damage, float range, std::string description) : Class_ability(range, description)
{
	damage_formula = damage;
}

void Damage_ability::accept_visitor(Ability_visitor* visitor)
{
	visitor->visit_damage(this);
}


void Damage_ability::cast(Character* target)
{
	target->set_health(target->get_health() - damage_formula);
	std::cout << "�������� ����������� " << this->get_description() << std::endl << "���� ������: " << damage_formula << std::endl;
}

Healing_ability::Healing_ability(int healing, float range, std::string description) : Class_ability(range, description)
{
	healing_formula = healing;
}

void Healing_ability::accept_visitor(Ability_visitor* visitor)
{
	visitor->visit_healing(this);
}

void Healing_ability::cast(Character* target)
{
	target->set_health(target->get_health() + healing_formula);
	std::cout << "�������� ����������� " << this->get_description() << std::endl << "������� ���������" << std::endl;
}

Status_ability::Status_ability(std::string status_name, int duration, float range, std::string description) : Class_ability(range, description)
{
	applied_status = status_name;
	status_duration = duration;
}

void Status_ability::accept_visitor(Ability_visitor* visitor)
{
	visitor->visit_status(this);
}

void Status_ability::cast(Character* target)
{
	std::cout << "�������� ����������� " << this->get_description() << std::endl;
	std::cout << "��������� ������ " << applied_status << " ������� � ���� " << target->get_name() << ", ������������ ������� " << status_duration << std::endl;
}