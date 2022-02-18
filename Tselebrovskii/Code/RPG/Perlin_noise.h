#pragma once
#include "Background_generator.h"

class Perlin_noise : public Background_generator
{
public:
	std::string generate_background() override;
};

