#pragma once
#include "Ability_creator.h"
#include "Abilities.h"

class Damage_ability_creator : public Ability_creator
{
private:
    int damage_formula;
public:
    Damage_ability_creator(int);
    Class_ability* create_ability(float, std::string) override;
};

class Healing_ability_creator : public Ability_creator
{
private:
    int healing_formula;
public:
    Healing_ability_creator(int);
    Class_ability* create_ability(float, std::string) override;
};

class Status_ability_creator : public Ability_creator
{
private:
    std::string applied_status;
    int status_duration;
public:
    Status_ability_creator(std::string, int);
    Class_ability* create_ability(float, std::string) override;
};
