#pragma once
#include "Environmental_object.h"
#include <string>

class Primitive_object : public Environmental_object
{
public:
	Primitive_object();
	Primitive_object(std::string);
	void react() override;
};

