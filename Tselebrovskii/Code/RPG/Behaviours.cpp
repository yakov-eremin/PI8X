#include "Behaviours.h"

void Active::react()
{
	std::cout << "Объект удалось открыть!" << std::endl;
}

void Inactive::react()
{
	std::cout << "Не открывается с этой стороны" << std::endl;
}

void Destroyed::react()
{
	std::cout << "Объект разрушен, взаимодействие невозможно" << std::endl;
}
