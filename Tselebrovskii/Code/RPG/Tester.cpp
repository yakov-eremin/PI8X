#include "Tester.h"

void Tester::play()
{
	World* current_world = World::get_instance("������ ����� ���");
	Player* current_player = current_world->get_player();
	Map* current_map = current_world->get_map();
	Environment* current_environment = current_map->get_env();
	current_player->x = 0;
	current_player->y = 0;
	int choice;
	int tmp;
	do
	{
		system("cls");
		std::cout << "�� ������ ��������� ����������: \n";
		for (int i = 0; i < current_environment->assigned_NPCs.size(); i++)
		{
			std::cout << current_environment->assigned_NPCs[i]->get_name() << ", �������� " << current_environment->assigned_NPCs[i]->get_health()
				<< ", ���������� :" << current_environment->assigned_NPCs[i]->x << "," << current_environment->assigned_NPCs[i]->y << ";\n";
		}
		std::cout << "�� ����� ������ ��������� �������: \n";
		for (int i = 0; i < current_environment->env_objects.size(); i++)
		{
			std::cout << current_environment->env_objects[i]->name << ", �������� " << current_environment->env_objects[i]->health
				<< ", ���������� :" << current_environment->env_objects[i]->coordinates.first << "," << current_environment->env_objects[i]->coordinates.second << ";\n";
		}
		std::cout << "���� ����������: " << current_player->x << "," << current_player->y << "\n";
		std::cout << "���� ��������: \n" << "1. ��������� \n" << "2. ������������ ����������� \n" 
			<< "3. ������������ ������ \n" << "4. ��������� ���� � ����� � ������� ���� \n";
		std::cin >> choice;
		switch (choice)
		{
		case 1:
			move_player(current_player);
			break;
		case 2:
			choose_ability();
			std::cin.ignore();
			std::cout << "������� Enter ����� ����������";
			std::cin.ignore();
			break;
		case 3:
			use_object();
			std::cin.ignore();
			std::cout << "������� Enter ����� ����������";
			std::cin.ignore();
			break;
		case 4:
			return;
		default:
			break;
		}
	} while (choice > 0 && choice < 4);
}

void Tester::move_player(Player* current_player)
{
	int choice;
	int x;
	int y;
	do
	{
		std::cout << "1. ��������� �� ��� X \n" << "2. ��������� �� ��� Y \n" << "3. ����� �� ������ �������� \n";
		std::cin >> choice;
		switch (choice)
		{
		case 1:
			std::cout << "������� �� ����� ���������� �� ������ ���������� ����� ��� X ";
			std::cin >> x;
			current_player->x += x;
			break;
		case 2:
			std::cout << "������� �� ����� ���������� �� ������ ���������� ����� ��� y ";
			std::cin >> y;
			current_player->y += y;
			break;
		case 3:
			return;
		default:
			break;
		}
	} while (choice > 0 && choice < 5);
}

void Tester::choose_ability()
{
	World* current_world = World::get_instance("������ ����� ���");
	Player* current_player = current_world->get_player();
	int choice;
	std::cout << "�������� ����� ����������� \n";
	for (int i = 0; i < current_player->game_class->list_of_abilities.size(); i++)
	{
		std::cout << i+1 << " " << current_player->game_class->list_of_abilities[i]->get_description() << "\n";
	}
	std::cin >> choice;
	if (choice > 0 && choice <= current_player->game_class->list_of_abilities.size())
	{
		choose_target(current_player->game_class->list_of_abilities[choice - 1]);
	}
}

void Tester::choose_target(Class_ability* ability)
{
	World* current_world = World::get_instance("������ ����� ���");
	Player* current_player = current_world->get_player();
	Map* current_map = current_world->get_map();
	Environment* current_environment = current_map->get_env();
	int choice;
	int counter = 0;
	std::cout << "�������� ���� �� ������������: \n";
	for (int i = 0; i < current_environment->assigned_NPCs.size(); i++)
	{
		std::cout << ++counter << ". " << current_environment->assigned_NPCs[i]->get_name() << ", �������� " << current_environment->assigned_NPCs[i]->get_health()
			<< ", ���������� :" << current_environment->assigned_NPCs[i]->x << "," << current_environment->assigned_NPCs[i]->y << ";\n";
	}
	//��������� ������ ���������, ������ ��� ������ �� ��� ���� ����� ������������ �����������
	std::cin >> choice;
	if (choice > 0 && choice <= current_environment->assigned_NPCs.size()) //������� ���������� ����
	{
		Character* target = current_environment->assigned_NPCs[choice - 1];
		//������ ��������, ��������� �� �� �� ������������
		if (sqrt((current_player->x - target->x) * (current_player->x - target->x) + (current_player->y - target->y) * (current_player->y - target->y))
				<= current_player->game_class->preferred_range)
		{
			ability->cast(target);
		}
		else
		{
			std::cout << "���� ������� ������! ��������� �� ���������� �� ����� " << current_player->game_class->preferred_range << "\n";
		}
	}
}

void Tester::use_object()
{
	World* current_world = World::get_instance("������ ����� ���");
	Player* current_player = current_world->get_player();
	Map* current_map = current_world->get_map();
	Environment* current_environment = current_map->get_env();
	int choice;
	int counter = 0;
	std::cout << "���� ����������: " << current_player->x << "," << current_player->y << "\n";
	std::cout << "�� ������ ��������� �������, �������� ���� �� ��� ��� ��������������: \n";
	for (int i = 0; i < current_environment->env_objects.size(); i++)
	{
		std::cout << ++counter << ". " << current_environment->env_objects[i]->name << ", �������� " << current_environment->env_objects[i]->health
			<< ", ���������� :" << current_environment->env_objects[i]->coordinates.first << "," << current_environment->env_objects[i]->coordinates.second << ";\n";
	}
	std::cin >> choice;
	if (choice > 0 && choice <= current_environment->assigned_NPCs.size()) //������� ���������� ����
	{
		Unique_state_env_obj* target = current_environment->env_objects[choice - 1];
		//������ ��������, ��������� �� �� �� ������������
		if (sqrt((current_player->x - target->coordinates.first) * (current_player->x - target->coordinates.first) +
			(current_player->y - target->coordinates.second) * (current_player->y - target->coordinates.second)) <= 10) //����� ���� ��� ������� ������������ �� ���������� 10
		{
			target->react();
		}
		else
		{
			std::cout << "������ ������� ������! ��������� �� ���������� �� ����� 10\n";
		}
	}
}

void Tester::main_menu()
{
	World::get_instance("������ ����� ���"); //������� ����� ���, ������� ����� ����� ������������
	int choice;
	do
	{
		system("cls");
		std::cout << "�������� ���� �� ������� ����: \n" << "1. ��������/�������������� ��������� ������ \n" << "2. ��������/�������������� ����� \n"
			<< "3. �������������� ���������� ����\n" << "4. ����� �� ��������� \n";
		std::cin >> choice;
		switch (choice)
		{
		case 1:
			work_with_player();
			break;
		case 2:
			work_with_map();
			break;
		case 3:
			play();
			break;
		case 4:
			return;
		default:
			break;
		}
	} while (choice > 0 && choice < 5);
}

void Tester::work_with_player()
{
	//������� do while
	World* current_world = World::get_instance("������ ����� ���");
	Player* current_player = current_world->get_player(); //��������� �������� ������
	int choice;
	do
	{
		system("cls");
		std::cout << "�������� ���� �� ������� ����: \n" << "1. ������� ������ ��������� \n" << "2. ������������� ������������� ��������� \n"
			<< "3. �������� � ������� ������ \n" << "4. �������� ��������� ������������ \n" << "5. ��������� � ������� ���� \n";
		std::cin >> choice;
		switch (choice)
		{
		case 1:
			current_world->change_player(create_player()); //���� ��������� ���-������, ��� �������� ��������
			if (current_world->get_player() == nullptr)
			{
				Player_director* director = new Player_director();
				current_world->change_player(director->make_warrior()); //������ ������������ �����
			}
			current_player = current_world->get_player();
			break;
		case 2:
			edit_player(current_player);
			current_world->change_player(current_player);
			break;
		case 3:
			choose_class(current_player);
			break;
		case 4:
			add_abilities(current_player);
			break;
		case 5:
			return;
		default:
			break;
		}
	} while (choice > 0 && choice < 5);
}

Player* Tester::create_player()
{
	Player_director* director = new Player_director();
	int choice;
	system("cls");
	std::cout << "�������� ���� �� ������� ����: \n" << "1. ������� ������������������ ����� \n" << "2. ������� ������������������ ����\n" 
		<< "3. ������� ������ ��������� \n" << "4. ��������� � ������� ���� \n";
	std::cin >> choice;
	switch (choice)
	{
	case 1:
		return director->make_warrior();
	case 2:
		return director->make_mage();
	case 3:
		return director->make_custom();
	default:
		return nullptr;
	}
}

void Tester::edit_player(Player* input_player)
{
	if (input_player == nullptr)
		input_player = new Player("testplayer");
	int choice;
	int health;
	int resource;
	std::string name;
	int karma;
	do
	{
		system("cls");
		std::cout << "�������� ���� �� ������� ����: \n" << "1. �������� �������� ��������� \n" << "2. �������� ������ ��������� \n"
			<< "3. �������� ��� ��������� \n" << "4. �������� ����� ��������� \n" << "5. ��������� � ���������� ���� \n";
		std::cin >> choice;
		switch (choice)
		{
		case 1:
			std::cout << "������� ������������ �������� ��������� " << std::endl;
			std::cin >> health;
			input_player->set_health(health);
			break;
		case 2:
			std::cout << "������� ������������ �������� ������� ��������� " << std::endl;
			std::cin >> resource;
			input_player->set_resource(resource);
			break;
		case 3:
			std::cout << "������� ��� ��������� " << std::endl;
			std::cin >> name;
			input_player->set_name(name);
			break;
		case 4:
			std::cout << "������� ���� ����� ��������� " << std::endl;
			std::cin >> karma;
			input_player->karma_points = karma;
			break;
		case 5:
			return;
		default:
			break;
		}
	} while (choice > 0 && choice < 5);
}

void Tester::work_with_map()
{
	World* current_world = World::get_instance("������ ����� ���");
	Map* current_map = current_world->get_map(); //��������� ������� �����
	int choice;
	do
	{
		system("cls");
		std::cout << "�������� ���� �� ������� ����: \n" << "1. ������� ����� ����� \n" << "2. ������������� ������������ ����� \n"
			<< "3. �������� � ���������� ����� \n" << "4. ��������� � ������� ���� \n";
		std::cin >> choice;
		switch (choice)
		{
		case 1:
			current_world->load_map(new Map()); //��� ������ �������� ������ �����, ������� ���� ����� ��������
			current_map = current_world->get_map(); //��������� ������� �����
			break;
		case 2:
			edit_map(current_map);
			current_world->load_map(current_map);
			break;
		case 3:
			//������ � ���������� �����
			work_with_map_env(current_map);
			break;
		case 4:
			return;
		default:
			break;
		}
	} while (choice > 0 && choice < 4);
}

void Tester::edit_map(Map* current_map)
{
	int choice;
	std::string name;
	int height;
	int width;
	do
	{
		system("cls");
		std::cout << "�������� ���� �� ������� ����: \n" << "1. �������� �������� ����� \n" << "2. �������� ������ ����� \n"
			<< "3. �������� ������ ����� \n" << "4. �������� ��������� ������� ���� � ������������� ����� ��� \n" << "5. ��������� � ������� ���� \n";
		std::cin >> choice;
		switch (choice)
		{
		case 1:
			std::cout << "������� �������� ����� " << std::endl;
			std::cin >> name;
			current_map->name = name;
			break;
		case 2:
			std::cout << "������� ������ ����� " << std::endl;
			std::cin >> height;
			current_map->height = height;
			break;
		case 3:
			std::cout << "������� ������ ����� " << std::endl;
			std::cin >> width;
			current_map->width = width;
			break;
		case 4:
			//���� ������ �� ������
			break;
		case 5:
			return;
		default:
			break;
		}
	} while (choice > 0 && choice < 5);
}

void Tester::work_with_map_env(Map* current_map)
{
	Environment* current_environment = current_map->get_env();
	int npc_amount = 10; //����� ���-������ ����������
	if (current_environment == nullptr) //����� �������� � ������ ����� ���������
	{
		current_environment = new Environment(new NPC_pool(npc_amount));
		current_map->env = current_environment;
	}
	int choice;
	Unique_state_env_obj* env_obj;
	NPC* new_npc;
	NPC_pool* npc_pool;
	do
	{
		system("cls");
		std::cout << "�������� ���� �� ������� ����: \n" << "1. �������� ����� ������� ��������� \n" << "2. �������� ����������� ������� ��������� (������) \n" 
			<< "3. �������� ������ ��� �� ���� � ��������� \n" << "4. ��������� � ������� ���� \n";
		std::cin >> choice;
		switch (choice)
		{
		case 1:
			env_obj = create_env_obj();
			if (env_obj->coordinates.first >= current_map->width) env_obj->coordinates.first = current_map->width - 1;
			if (env_obj->coordinates.second >= current_map->height) env_obj->coordinates.second = current_map->height - 1;
			current_environment->add_env_object(env_obj);
			break;
		case 2:
			env_obj = new Unique_state_env_obj("������", 100, rand() % 100, rand() % 100);
			if (env_obj->coordinates.first >= current_map->width) env_obj->coordinates.first = current_map->width - 1;
			if (env_obj->coordinates.second >= current_map->height) env_obj->coordinates.second = current_map->height - 1;
			current_environment->add_env_object(env_obj);
			break;			
		case 3:
			current_environment->add_NPC(); //��������� �� ����
			current_environment->assigned_NPCs[current_environment->assigned_NPCs.size() - 1]->x = rand() % 100; //������ ��������� ����������
			current_environment->assigned_NPCs[current_environment->assigned_NPCs.size() - 1]->y = rand() % 100;
			break;
		case 4:
			return;
		default:
			break;
		}
	} while (choice > 0 && choice < 4);
}

Unique_state_env_obj* Tester::create_env_obj()
{
	Unique_state_env_obj* result;
	int choice;
	std::string name = "";
	int x = 0;
	int y = 0;
	int health = 10;
	do
	{
		system("cls");
		std::cout << "�������� ���� �� ������� ����: \n" << "1. ������ �������� ������� \n" << "2. ������ ���������� x ������� \n"
			<< "3. ������ ���������� y ������� \n" << "4. ������ �������� ������� \n" << "5. ��������� � ��������� � ������� ���� \n";
		std::cin >> choice;
		switch (choice)
		{
		case 1:
			std::cout << "������� �������� ������� " << std::endl;
			std::cin >> name;
			break;
		case 2:
			std::cout << "������� ���������� x ������� " << std::endl;
			std::cin >> x;
			if (x < 0) x = 0;
			break;
		case 3:
			std::cout << "������� ���������� y ������� " << std::endl;
			std::cin >> y;
			if (y < 0) y = 0;
			break;
		case 4:
			std::cout << "������� �������� ������� " << std::endl;
			std::cin >> health;
			break;
		case 5:
			result = new Unique_state_env_obj(name, health, x, y);
			result->set_behaviour("inactive"); //�������
			return result;
		default:
			break;
		}
	} while (choice > 0 && choice < 5);
}

void Tester::choose_class(Player* current_player)
{
	bool isMagical =  false;
	char choice;
	std::cout << "�� ������ ������� ����������� ���������? y/n: \n";
	std::cin >> choice;
	if (choice == 'y')
	{
		current_player->factory = new Melee_factory();
	}
	else
	{
		current_player->factory = new Ranged_factory();
	}
	std::cout << "�� ������ ������� ����������� ���������? y/n: \n";
	std::cin >> choice;
	if (choice == 'y')
		isMagical = true;
	current_player->set_class(isMagical);
}

void Tester::add_abilities(Player* current_player)
{
	int choice;
	Ability_creator* creator;
	int damage;
	int healing;
	std::string status_name;
	int status_duration;
	if (current_player->game_class == nullptr)
		choose_class(current_player);
	float range = current_player->game_class->preferred_range;
	do
	{
		system("cls");
		std::cout << "�������� ���� �� ������� ����: \n" << "1. �������� ����� �����������, ��������� ���� \n" << "2. �������� ����� ���������� ����������� \n"
			<< "3. �������� ����� �����������, ������������� ��������� ������ \n" << "4. ��������� � ������� ���� \n";
		std::cin >> choice;
		switch (choice)
		{
		case 1:
			std::cout << "������� ���������� �����, ���������� ������������ ";
			std::cin >> damage;
			creator = new Damage_ability_creator(damage);
			current_player->game_class->add_ability(creator->create_ability(range, "damage " + std::to_string(damage)));
			break;
		case 2:
			std::cout << "������� ���������� ��������, ������������������ ������������ ";
			std::cin >> healing;
			creator = new Healing_ability_creator(healing);
			current_player->game_class->add_ability(creator->create_ability(range, "healing " + std::to_string(healing)));
			break;
		case 3:
			std::cout << "������� �������� ���������� �������, �������������� ������������ ";
			std::cin >> status_name;
			std::cout << "������� ������������ ���������� �������, �������������� ������������ ";
			std::cin >> status_duration;
			creator = new Status_ability_creator(status_name, status_duration);
			current_player->game_class->add_ability(creator->create_ability(range, "status " + status_name));
			break;
		case 4:
			return;
		default:
			break;
		}
	} while (choice > 0 && choice < 4);
}