#pragma once
#include "Abstract_factory.h"
#include <iostream>
#include "Four_classes.h"

class Melee_factory : public Abstract_factory
{
	Class* create_physical() override;
	Class* create_magical() override;
};

class Ranged_factory : public Abstract_factory
{
	Class* create_physical() override;
	Class* create_magical() override;
};
