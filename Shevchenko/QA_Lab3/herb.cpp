#include "herb.h"

Herb::Herb()
{
    type = 1;
    birthTime = clock();
    lifespan = 0;
    growthLevel = 1;
    maxHealth = 1;
    currentHealth = 1;
    setPixmap(QPixmap(":/textures/assets/flower.png"));
    //--------------------STATIC
    agressivness = 3;
    reqLightLevel = 3;
    reqHumLevel = 4;
    name = "Herb";
    setZValue(2);
}

Herb::Herb(time_t newLifespan, int newGrowthLevel, int newCurrentHealth)
{
    type = 1;
    birthTime = clock() - newLifespan;
    lifespan = newLifespan;
    growthLevel = newGrowthLevel;
    currentHealth = newCurrentHealth;
    //--------------------STATIC
    setPixmap(QPixmap(":/textures/assets/flower.png"));
    agressivness = 3;
    reqLightLevel = 3;
    reqHumLevel = 4;
    name = "Herb";
    setZValue(1);
}

Herb::~Herb()
{

}
int Herb::getFertilityConsumprion(int additionalGrowthLevel){
    return growthLevel*2+additionalGrowthLevel;
}
int Herb::getFertilityConsumption(){
    return growthLevel*2;
}

int Herb::updateGrowthLevel(int additionalGrowthLevel){
    growthLevel = growthLevel + additionalGrowthLevel;
    return growthLevel;
}
QString Herb::getLifespan(){
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
