#include "groundtile.h"
#include <QMouseEvent>
#include "mainwindow.h"

GroundTile::GroundTile(){
    fertility = 0;
    shadow = 0;
    setRect(0,0,60,60);
    setZValue(5);
    setFlag(QGraphicsItem::ItemIsFocusable);
}
GroundTile::GroundTile(int newFertility){
    fertility = newFertility;
    shadow = 0;
    setRect(0,0,60,60);
    setZValue(5);
    setFlag(QGraphicsItem::ItemIsFocusable);
    fertility = newFertility;
}
GroundTile::~GroundTile(){
    for (int i = 0; i < plants.size();i++)
        delete(plants[i]);
}
int GroundTile::getFertilityConsumption(){
    int result = 0;
    for (int i = 0; i < plants.size();i++)
        result += plants.at(i)->getFertilityConsumption();
    return result;
}
void GroundTile::mousePressEvent(QGraphicsSceneMouseEvent *event){
    emit clicked(this);
}

void GroundTile::deletePlant(int index){


}

Plant* GroundTile::addPlant(int index){
switch (index) {
    case 0:
        plants.push_back(new Grass());
        return(plants.back());
    case 1:
        plants.push_back(new Herb());
        return(plants.back());
    case 2:
        plants.push_back(new Shrub());
        return(plants.back());
    case 3:
    plants.push_back(new Tree());
        return(plants.back());
}
return NULL;
}

void GroundTile::simulationTick(int light, int humidity){
    for (int i = 0; i < plants.size(); i++){
        if (abs(humidity - plants.at(i)->reqHumLevel) > plants.at(i)->agressivness) plants[i]->currentHealth--;
        if (light!=0)
            if (abs(light - plants.at(i)->reqLightLevel) > plants.at(i)->agressivness) plants[i]->currentHealth--;
        if (plants.at(i)->currentHealth < 1){
            deletePlant(i);
        }
        if ((abs(humidity - plants.at(i)->reqHumLevel) < plants.at(i)->agressivness)&&(abs(light - plants.at(i)->reqLightLevel) < plants.at(i)->agressivness)){
            if (plants[i]->currentHealth == plants[i]->maxHealth){
                if (getFertilityConsumption() - plants[i]->getFertilityConsumption() + plants[i]->getFertilityConsumprion(1) <= fertility)
                plants[i]->updateGrowthLevel(1);
            } else plants[i]->currentHealth++;
        }
    }
}
