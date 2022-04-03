#pragma once
#include "Background_generator.h"

class Loader : public Background_generator
{
public:
	std::string generate_background() override;
};
