#include "Buildings.h"

Building::Building(float _x, float _y, Resource *Res, Resource *Cons)
{
	//Установка координат.
	x = _x;
	y = _y;

	Health = 1;
	workers = 0;

	State = 0;

	//Текстура отображающая при строительстве специальную картинку.
	TextureIsBuild.loadFromFile("Resources/Images/ImageBuildings/IsBuild.png");
	DestroyTexture.loadFromFile("Resources/Images/ImageBuildings/Destroy.png");

	WorkResource = Res;
	ConsumedResource = Cons;
}

void Building::update()
{
	switch (State)
	{
	case 0:
		build();
		break;
	case 1:
		Working();
		break;
	}
}

bool Building::IsMaxWorkers()
{
	if (workers == MaxWorkers)
		return true;
	else
		return false;
}

bool Building::IsNoWorkers()
{
	if (workers == 0)
		return true;
	else
		return false;
}

void Building::AddWorkers(int count)
{
	workers += count;
}

bool Building::Destroy()
{
	if (State == 0)
		return false;
	State = 2;
	delete this;
	return true;
}

void Building::build()
{
	if (Health < MaxHealth)
	{
		//Постройка или починка.
		Health += 1;
	}
	else
		State = 1;
}

float Building::getX()
{
	return x;
}

float Building::getY()
{
	return y;
}

FloatRect Building::Square()
{
	return FloatRect(x, y, width, height);
}

wstring Building::GetName()
{
	return Name;
}

int Building::GetWorkers()
{
	return workers;
}

int Building::GetMaxWorkers()
{
	return MaxWorkers;
}

void Building::draw(RenderTarget &target, RenderStates states) const
{
	if (State == 1)
		states.texture = &BuildTexture;
	else
		if (State == 2)
			states.texture = &DestroyTexture;
		else
			states.texture = &TextureIsBuild;

	target.draw(VerticesBuild, states);
}

BaseBuilding::BaseBuilding(float _x, float _y, Resource *Res, Resource *Cons) : Building(_x, _y, Res, Cons)
{
	//Задание характиристик.
	Name = L"Главное здание";
	MaxHealth = 1000;
	MaxWorkers = 5;
	width = 80;
	height = 80;
	ColonyLevel = 1;
	//Загрузка текстуры.
	BuildTexture.loadFromFile("Resources/Images/ImageBuildings/Base.png");
	VerticesBuild.setPrimitiveType(Quads);
	VerticesBuild.resize(4);
	//Установка вершин на свои места в мире.
	VerticesBuild[0].texCoords = Vector2f(0, 0);
	VerticesBuild[1].texCoords = Vector2f(0, BuildTexture.getSize().y);
	VerticesBuild[2].texCoords = Vector2f(BuildTexture.getSize().x, BuildTexture.getSize().y);
	VerticesBuild[3].texCoords = Vector2f(BuildTexture.getSize().x, 0);
	VerticesBuild[0].position = Vector2f(x, y);
	VerticesBuild[1].position = Vector2f(x, y + height);
	VerticesBuild[2].position = Vector2f(x + width, y + height);
	VerticesBuild[3].position = Vector2f(x + width, y);
}

BaseBuilding::BaseBuilding(int _x, int _y, Resource *Res, Resource *Cons) : Building(float(_x), float(_y), Res, Cons)
{
	//Задание характиристик.
	Name = L"Главное здание";
	MaxHealth = 1000;
	MaxWorkers = 5;
	width = 80;
	height = 80;
	ColonyLevel = 1;
	//Загрузка текстуры.
	BuildTexture.loadFromFile("Resources/Images/ImageBuildings/Base.png");
	VerticesBuild.setPrimitiveType(Quads);
	VerticesBuild.resize(4);
	//Установка вершин на свои места в мире.
	VerticesBuild[0].texCoords = Vector2f(0, 0);
	VerticesBuild[1].texCoords = Vector2f(0, BuildTexture.getSize().y);
	VerticesBuild[2].texCoords = Vector2f(BuildTexture.getSize().x, BuildTexture.getSize().y);
	VerticesBuild[3].texCoords = Vector2f(BuildTexture.getSize().x, 0);
	VerticesBuild[0].position = Vector2f(x, y);
	VerticesBuild[1].position = Vector2f(x, y + height);
	VerticesBuild[2].position = Vector2f(x + width, y + height);
	VerticesBuild[3].position = Vector2f(x + width, y);
}

bool BaseBuilding::Destroy()
{
	if (State == 0)
		return false;
	Health = 1;
	workers = 0;
	State = 0;
	return false;
}

void BaseBuilding::Production()
{
	if (State == 1)
	{
		int summa = 0;
		if (ColonyLevel == 1)
		{
			summa = 1000;
		}
		else
		{
			summa = (ColonyLevel - 1) * 10000;
		}
		if (ConsumedResource->IsCanSpendResource(summa))
		{
			ConsumedResource->AddResource(-summa);
			ColonyLevel++;
			MaxWorkers += 2;
		}
	}
}

int BaseBuilding::GetColonyLevel()
{
	return ColonyLevel;
}

void BaseBuilding::Working()
{
	//Количество зарабатываемого опыта со здания.
	//Зависит от количества рабочих и уровня колонии.
	float ResourceAdd = ColonyLevel * workers * 0.05; 
	WorkResource->AddResource(ResourceAdd);
}

int BaseBuilding::GetSpecial()
{
	return ColonyLevel;
}

SmallHouse::SmallHouse(int _x, int _y, Resource *Res, Resource *Cons) : Building(_x, _y, Res, Cons)
{
	//Задание характиристик.
	Name = L"Маленький дом";
	MaxHealth = 200;
	MaxWorkers = 0;
	width = 20;
	height = 20;
	CountOfWorkers = 5;
	//Загрузка текстуры.
	BuildTexture.loadFromFile("Resources/Images/ImageBuildings/SmallHouse.png");
	VerticesBuild.setPrimitiveType(Quads);
	VerticesBuild.resize(4);
	//Установка вершин на свои места в мире.
	VerticesBuild[0].texCoords = Vector2f(0, 0);
	VerticesBuild[1].texCoords = Vector2f(0, BuildTexture.getSize().y);
	VerticesBuild[2].texCoords = Vector2f(BuildTexture.getSize().x, BuildTexture.getSize().y);
	VerticesBuild[3].texCoords = Vector2f(BuildTexture.getSize().x, 0);
	VerticesBuild[0].position = Vector2f(x, y);
	VerticesBuild[1].position = Vector2f(x, y + height);
	VerticesBuild[2].position = Vector2f(x + width, y + height);
	VerticesBuild[3].position = Vector2f(x + width, y);
}

bool SmallHouse::Destroy()
{
	if (WorkResource->IsCanSpendResource(CountOfWorkers))
	{
		if (State == 0)
			return false;
		State = 2;
		WorkResource->AddResource(-CountOfWorkers);
		delete this;
		return true;
	}
	else
		return false;
}

void SmallHouse::Production()
{
	if (State == 1)
		if (CountOfWorkers < 15)
			if (ConsumedResource->IsCanSpendResource(10000))
			{
				ConsumedResource->AddResource(-10000);
				CountOfWorkers += 5;
				WorkResource->AddResource(5);
			}
}

void SmallHouse::Working()
{
	if (ConsumedResource->IsCanSpendResource(CountOfWorkers * 0.04))
		ConsumedResource->AddResource(-CountOfWorkers * 0.04);
}

int SmallHouse::GetSpecial()
{
	return CountOfWorkers;
}

IronOreMiner::IronOreMiner(int _x, int _y, Resource *Res, Resource *Cons) : Building(_x, _y, Res, Cons)
{
	//Задание характиристик.
	Name = L"Добытчик железной руды";
	MaxHealth = 2000;
	MaxWorkers = 10;
	width = 20;
	height = 20;
	OreAmount = 50000;
	//Загрузка текстуры.
	BuildTexture.loadFromFile("Resources/Images/ImageBuildings/IronOreMiner.png");
	VerticesBuild.setPrimitiveType(Quads);
	VerticesBuild.resize(4);
	//Установка вершин на свои места в мире.
	VerticesBuild[0].texCoords = Vector2f(0, 0);
	VerticesBuild[1].texCoords = Vector2f(0, BuildTexture.getSize().y);
	VerticesBuild[2].texCoords = Vector2f(BuildTexture.getSize().x, BuildTexture.getSize().y);
	VerticesBuild[3].texCoords = Vector2f(BuildTexture.getSize().x, 0);
	VerticesBuild[0].position = Vector2f(x, y);
	VerticesBuild[1].position = Vector2f(x, y + height);
	VerticesBuild[2].position = Vector2f(x + width, y + height);
	VerticesBuild[3].position = Vector2f(x + width, y);
}

void IronOreMiner::Production()
{
	if (State == 1)
		if (OreAmount >= 10000)
		{
			OreAmount -= 10000;
			ConsumedResource->AddResource(250);
		}
}

void IronOreMiner::Working()
{
	if (OreAmount > 0)
	{
		OreAmount -= workers * 0.05;
		WorkResource->AddResource(workers * 0.05);
	}
}

int IronOreMiner::GetSpecial()
{
	return OreAmount;
}