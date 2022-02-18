#pragma once
#include "State.h"
#include <iostream>

class Alive : public State
{
	void interact() override;
};

class Dead : public State
{
	void interact() override;
};

