#include "tree.h"

Tree::Tree()
{
    type = 3;
    birthTime = clock();
    lifespan = 0;
    growthLevel = 1;
    maxHealth = 10;
    currentHealth = 10;
    //--------------------STATIC
    setPixmap(QPixmap(":/textures/assets/tree.png"));
    agressivness = 4;
    reqLightLevel = 5;
    reqHumLevel = 4;
    name = "Tree";
    setZValue(3);
}

Tree::Tree(time_t newLifespan, int newGrowthLevel, int newCurrentHealth)
{
    type = 3;
    birthTime = clock();
    lifespan = newLifespan;
    growthLevel = newGrowthLevel;
    updateGrowthLevel(newGrowthLevel);
    currentHealth = newCurrentHealth;
    //--------------------STATIC
    setPixmap(QPixmap(":/textures/assets/tree.png"));
    agressivness = 4;
    reqLightLevel = 5;
    reqHumLevel = 4;
    name = "Tree";
    setZValue(3);
}

Tree::~Tree()
{

}

int Tree::getFertilityConsumprion(int additionalGrowthLevel)
{
    return 2*(growthLevel + 1);
}

int Tree::getFertilityConsumption()
{
    return 2*growthLevel;
}

int Tree::updateGrowthLevel(int additionalGrowthLevel)
{

    growthLevel+= additionalGrowthLevel;
    return growthLevel;
}

QString Tree::getLifespan()
{
    time_t currentTime = clock() - birthTime + lifespan;
        int sec = currentTime / CLK_TCK;
        int min = 0;
        int hour = 0;
        if (sec > 60) {
            min = sec / 60;
            sec %= 60;
        }
        if (min > 60) {
            hour = min / 60;
            min %= 60;
        }
        QString result = QString::number(hour) + ":" + QString::number(min) + ":" + QString::number(sec);
        return result;
}

