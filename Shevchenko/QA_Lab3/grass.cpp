#include "grass.h"

Grass::Grass()
{
    type = 0;
    birthTime = clock();
    lifespan = 0;
    growthLevel = 1;
    maxHealth = 1;
    currentHealth = 1;
    //--------------------STATIC
    setPixmap(QPixmap(":/textures/assets/grass_ground.png"));
    agressivness = 3;
    reqLightLevel = 4;
    reqHumLevel = 2;
    name = "Grass";
    setZValue(1);
}

Grass::Grass(time_t newLifespan, int newGrowthLevel, int newCurrentHealth)
{
    type = 0;
    birthTime = clock() - newLifespan;
    lifespan = newLifespan;
    growthLevel = newGrowthLevel;
    currentHealth = newCurrentHealth;
    //--------------------STATIC
    setPixmap(QPixmap(":/textures/assets/grass_ground.png"));
    agressivness = 3;
    reqLightLevel = 4;
    reqHumLevel = 2;
    name = "Grass";
    setZValue(1);
    updateGrowthLevel(growthLevel);
}

Grass::~Grass()
{

}
int Grass::getFertilityConsumprion(int additionalGrowthLevel){
    return growthLevel + additionalGrowthLevel;
}
int Grass::getFertilityConsumption(){
    return growthLevel;
}

int Grass::updateGrowthLevel(int additionalGrowthLevel){
    agressivness++;
    growthLevel = growthLevel + additionalGrowthLevel;
    return growthLevel;
}

QString Grass::getLifespan()
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
