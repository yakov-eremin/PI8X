#include "Saver_decorator.h"

Saver_decorator::Saver_decorator()
{

}

Saver_decorator::Saver_decorator(Saver* saver)
{
	wrapee = saver;
}

void Saver_decorator::save_world(std::string filename)
{
	std::cout << "World saved as " << filename << std::endl;
}