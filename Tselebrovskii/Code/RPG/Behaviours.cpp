#include "Behaviours.h"

void Active::react()
{
	std::cout << "������ ������� �������!" << std::endl;
}

void Inactive::react()
{
	std::cout << "�� ����������� � ���� �������" << std::endl;
}

void Destroyed::react()
{
	std::cout << "������ ��������, �������������� ����������" << std::endl;
}
