#include "Concrete_factories.h"

//TODO: сделать кострукторы классов с передачей туда описания, чтобы делать типо разные классы.

Class* Melee_factory::create_physical()
{
	std::cout << "Создан физический рукопашный класс" << std::endl;
	return new Physical_Melee();
}

Class* Melee_factory::create_magical()
{
	std::cout << "Создан магический рукопашный класс" << std::endl;
	return new Magical_Melee();
}

Class* Ranged_factory::create_physical()
{
	std::cout << "Создан физический дальнобойный класс" << std::endl;
	return new Physical_Ranged();
}

Class* Ranged_factory::create_magical()
{
	std::cout << "Создан магический дальнобойный класс" << std::endl;
	return new Magical_Ranged();
}
