#include "States.h"

void Alive::interact()
{
	std::cout << "Hello, i'm alive!" << std::endl;
}

void Dead::interact()
{
	std::cout << "..." << std::endl;
}
