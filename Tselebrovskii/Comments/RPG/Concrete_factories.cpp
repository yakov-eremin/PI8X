#include "Concrete_factories.h"

//TODO: ������� ����������� ������� � ��������� ���� ��������, ����� ������ ���� ������ ������.

Class* Melee_factory::create_physical()
{
	std::cout << "������ ���������� ���������� �����" << std::endl;
	return new Physical_Melee();
}

Class* Melee_factory::create_magical()
{
	std::cout << "������ ���������� ���������� �����" << std::endl;
	return new Magical_Melee();
}

Class* Ranged_factory::create_physical()
{
	std::cout << "������ ���������� ������������ �����" << std::endl;
	return new Physical_Ranged();
}

Class* Ranged_factory::create_magical()
{
	std::cout << "������ ���������� ������������ �����" << std::endl;
	return new Magical_Ranged();
}
