#pragma once
#include "Background_generator.h"

class Voronoi_diagramm : public Background_generator
{
public:
	std::string generate_background() override;
};
