#include "Publisher.h"

void Publisher::subscribe(Subscriber* sub)
{
	subscribers.push_back(sub);
}

void Publisher::unsubscribe(int n) //������� n-���� ����������. �� ����� ���������� �������, �� ����� ����� ���
{
	if (n < subscribers.size())
		subscribers.erase(subscribers.begin() + n);
}

void Publisher::notify_subscribers()
{
	//���-�� ��������, ����� ���� ��������
	//��������, �������� ��������� � environment, ����� �� ��� ������ �� ���
	//������, ���������� ������ ������ ���, ��� ��� � environment, ����� ���� ������� � ��� ����� object pool
	//�������� ����� ����������, ����� ������ ���� � ������� � ��� �������
	for (auto sub : subscribers)
	{
		sub->scale_abilities();
	}
	std::cout << "���������� ����������" << std::endl;
}
