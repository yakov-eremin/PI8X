#include "simulation.h"
#include "plant.h"
#include "grass.h"
#include "herb.h"
#include "shrub.h"
#include <QDir>
#include <QBrush>
#include <QImage>
#include <ctime>
#include <QTimer>

// Class constructor
Simulation::Simulation(int newRowsCount, int newColumnsCount){
    rowsCount = newRowsCount;
    columnsCount = newColumnsCount;
    elapsedTime = 0;
    loadTime = clock();
    tiles = QVector<QVector<GroundTile*>>(rowsCount);
    QTimer *timer = new QTimer(this);
    for (int i = 0; i < rowsCount; i++){
        tiles[i] = QVector<GroundTile*>(columnsCount);
        for (int j = 0; j < columnsCount; j++){
            tiles[i][j] = new GroundTile(5);
            QObject::connect(tiles[i][j],&GroundTile::clicked,this,&Simulation::sendChangeToForm);
            QObject::connect(timer,&QTimer::timeout,this,&Simulation::simulationTick);
        }
    }
    selectedTile = tiles[0][0];
    scene = getGraphicsScene();
    fileSaveName = "";
    timer->start(15000);
}


// Saves current simulation to file w/ given name. Directory is always the same
int Simulation::saveToFile(QString filename){
    QDir saves(QDir::currentPath() + "/saves");
    if (!saves.exists()){
        saves.cd(QDir::currentPath());
        saves.mkdir("saves");
        saves.cd("saves");
    }
    saves.mkpath("/" + filename + ".psf");
    QFile file(QDir::currentPath() + "/saves/" + filename + ".psf");
    if (!file.open(QIODevice::WriteOnly | QIODevice::Text))
        return(1);
    QTextStream ts(&file);
                                                                                // Saving
    ts << rowsCount << " " << columnsCount << "\n";                             // Rows count and columns count
    ts << clock() - loadTime - elapsedTime << "\n";                             // Calculating and saving simulation time
    ts << light << " " << lightDirection << "\n"<< humidity << "\n";
    for (int row = 0; row < rowsCount; row++)                                   // For each tile
        for (int column = 0; column < columnsCount; column++){
            GroundTile* tile = tiles[row][column];                              // Copy for easy access
            ts << tile->fertility << " " << tile->plants.size() << "\n";        // Tile fertility and amount of plants in a tile
            // ts << tile->plants.size() << "\n";                                   // Amount of plants in a tile
            for (int i = 0; i < tile->plants.size(); i++){                      // For each plant
                Plant* plant = tile->plants.at(i);                              // Copy for easy access
                ts << plant->type << "\n";                                      // Saving type
                ts << plant->lifespan << "\n";                                  // Timings
                ts << plant->growthLevel << "\n";                               // Level of growth
                ts << plant->currentHealth << "\n";                             // Current health
            }
        }
    file.close();
    fileSaveName = filename;
    return 0;
}
// Loads simulation from file
int Simulation::loadFromFile(QString filePath){
    QFile file(filePath);
    if (!file.open(QIODevice::ReadOnly | QIODevice::Text))
        return(1);
    fileSaveName = file.fileName();
    QTextStream ts(&file);
    resetSimulation();
                                                                // Loading
    ts >> rowsCount >> columnsCount;                            // Rows count and columns count
    tiles = QVector<QVector<GroundTile*>>(rowsCount);
    for (int i = 0; i < rowsCount; i++){
        tiles[i] = QVector<GroundTile*>(columnsCount);
    }
    ts >> elapsedTime;                                          // Elapsed time
    ts >> light >> lightDirection >> humidity;
    loadTime = clock();                                         // Inniting load time
    for (int row = 0; row < rowsCount; row++)                   // For each tile
        for (int column = 0; column < columnsCount; column++){
            int buff;
            ts >> buff;
            tiles[row][column] = new GroundTile(buff);
            ts >> buff;
            for (int i = 0; i < buff; i++){
                int plantType;
                ts >> plantType;
                switch(plantType){
                Grass* grass;
                Herb* herb;
                Shrub* shrub;
                int lifespan;
                int growthLevel;
                int currentHealth;
                case 0:
                    ts >> lifespan >> growthLevel >> currentHealth;
                    grass = new Grass(lifespan, growthLevel, currentHealth);
                    tiles[row][column]->plants.push_back(grass);
                    break;
                case 1:
                    ts >> lifespan >> growthLevel >> currentHealth;
                    herb = new Herb(lifespan, growthLevel, currentHealth);
                    tiles[row][column]->plants.push_back(herb);
                    break;
                case 2:
                    ts >> lifespan >> growthLevel >> currentHealth;
                    shrub = new Shrub(lifespan, growthLevel, currentHealth);
                    tiles[row][column]->plants.push_back(shrub);
                    break;
                case 3:
                    break;
                }
                QObject::connect(tiles[row][column],&GroundTile::plantDied,this,&Simulation::plantDied);
            }
            QObject::connect(tiles[row][column],&GroundTile::clicked,this,&Simulation::sendChangeToForm);
        }
    fileSaveName = file.fileName();
    selectedTile = tiles[0][0];
    scene = getGraphicsScene();
    return 0;
}
// Returns completed graphics scene of simulation
QGraphicsScene * Simulation::getGraphicsScene(){
    QGraphicsScene *newscene = new QGraphicsScene;
    for (int row = 0; row < rowsCount; row++){
        for (int column = 0; column < columnsCount; column++){
            tiles[row][column]->setPos(column*60,row*60);
            newscene->addItem(tiles[row][column]);
             for (int plant = 0; plant < tiles[row][column]->plants.size(); plant++){
                 tiles[row][column]->plants.at(plant)->setX(column*60);
                 tiles[row][column]->plants.at(plant)->setY(row*60);
                 newscene->addItem(tiles[row][column]->plants.at(plant));
             }
        }
    }
    newscene->setBackgroundBrush(QBrush(QImage(":/textures/assets/commonBackground.png")));
    scene = newscene;
    return newscene;
}
// "Resender" of the "clicked" signal from tile to UI
void Simulation::sendChangeToForm(GroundTile* tile){
    selectedTile = tile;
    emit changeInfo(tile);
}
// Slot, recieves signal from Plant object when plant dies and should be removed from the scene
void Simulation::plantDied(Plant *plant){
    scene->removeItem(plant);
}
//----------------Getters
QString Simulation::getFileSaveName() {                     // Returns name of the last savefile
    return fileSaveName;
}
int Simulation::getRowsCount(){
    return rowsCount;
}
int Simulation::getColumnsCount(){
    return columnsCount;
}

GroundTile *Simulation::getSelectedTile(){
    return selectedTile;
}
// Resetting simulation
void Simulation::resetSimulation(){
    for (int row = 0; row < rowsCount; row++){
        // TODO: clearing memory
        /*for (int column = 0; column < columnsCount; column++){
            for (int plant = 0; plant < tiles[row][column]->plants.size(); plant++){
                delete(tiles[row][column]->plants[plant]);
            }
            delete(tiles[row][column]);
        }*/
        if (!tiles[row].size()) continue;
        tiles[row].clear();
        tiles[row].squeeze();
    }
    tiles.clear();
    tiles.squeeze();
}
// Returns simulation time as a QString
QString Simulation::getSimulationTime(){
    time_t currentTime = clock() - loadTime + elapsedTime;
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

void Simulation::simulationTick(){
    for (int row = 0; row < rowsCount; row++){
        for (int column = 0; column < columnsCount; column++){
            tiles[row][column]->simulationTick(light,humidity);
        }
    }
}

void Simulation::refreshShadows()
{
    int n = 0;
    int w = 0;
    int s = 0;
    int e = 0;
    if (lightDirection == "N") n = 1;
    if (lightDirection == "S") s = 1;
    if (lightDirection == "W") w = 1;
    if (lightDirection == "E") e = 1;
    for (int row = 0; row < rowsCount; row++){
        for (int column = 0; column < columnsCount; column++){
            GroundTile* tile = tiles[row][column];
            for (int plant = 0; plant < tile->plants.size(); plant++){
                if (tile->plants.at(plant)->type > 1){
                    for (int offset = 1; offset < tile->plants.at(plant)->growthLevel; offset++)
                        if ((row - n*offset >= 0) && (row + s*offset < rowsCount) && (column - w*offset >= 0) && (column + e*offset < columnsCount))
                            tiles[row - n*offset + + s*offset][column - w*offset + e*offset]->shadow = 1;
                }
            }
        }
    }
}
