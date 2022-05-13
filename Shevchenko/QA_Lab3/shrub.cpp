#include "shrub.h"

Shrub::Shrub()
{
    type = 2;
    birthTime = clock();
    lifespan = 0;
    growthLevel = 0;
    maxHealth = 1;
    currentHealth = 1;
    setPixmap(QPixmap(":/textures/assets/shrubTransparent.png"));
    //--------------------STATIC
    agressivness = 1;
    reqLightLevel = 1;
    reqHumLevel = 1;
    name = "Shrub";
    setZValue(3);
}

Shrub::Shrub(time_t newLifespan, int newGrowthLevel, int newCurrentHealth)
{
    type = 2;
    birthTime = clock() - newLifespan;
    lifespan = newLifespan;
    growthLevel = newGrowthLevel;
    currentHealth = newCurrentHealth;
    //--------------------STATIC
    setPixmap(QPixmap(":/textures/assets/shrubTransparent.png"));
    agressivness = 1;
    reqLightLevel = 1;
    reqHumLevel = 1;
    name = "Shrub";
    setZValue(3);
}

Shrub::~Shrub()
{

}
int Shrub::getFertilityConsumprion(int additionalGrowthLevel){
    return (1 + (additionalGrowthLevel + growthLevel)/1.5);
}
int Shrub::getFertilityConsumption(){
    return (1 + (growthLevel)/1.5);
}

int Shrub::updateGrowthLevel(int additionalGrowthLevel){
    growthLevel = growthLevel + additionalGrowthLevel;
    return growthLevel;
}
QString Shrub::getLifespan(){
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
