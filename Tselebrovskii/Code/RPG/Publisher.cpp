#include "Publisher.h"

void Publisher::subscribe(Subscriber* sub)
{
	subscribers.push_back(sub);
}

void Publisher::unsubscribe(int n) //удаляет n-ного подписчика. Не самое элегантное решение, но пусть будет так
{
	if (n < subscribers.size())
		subscribers.erase(subscribers.begin() + n);
}

void Publisher::notify_subscribers()
{
	//как-то понимать, когда умер персонаж
	//возможно, помещать паблишера в environment, чтобы он там следил за НИП
	//вообще, посмотреть момент смерти НИП, как раз в environment, когда буду тестить в том числе object pool
	//паблишер будет уведомлять, когда непись умрёт и вернётся в пул неписей
	for (auto sub : subscribers)
	{
		sub->scale_abilities();
	}
	std::cout << "Подписчики уведомлены" << std::endl;
}
