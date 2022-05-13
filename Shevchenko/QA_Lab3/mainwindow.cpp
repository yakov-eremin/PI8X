#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QInputDialog>
#include <QMessageBox>
#include <QFileDialog>
#include <QBrush>
#include <QImage>
#include <QLabel>
#include <QTimer>



MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    ui->graphicsView_Simulation->setFixedSize(600, 600);
    ui->pushButton_simMenu->setStyleSheet("border-image = url(qrc:/textures/assets/simMenu.png) 60 60 60 60");
}

MainWindow::~MainWindow()
{
    delete ui;
}
//---------------------------------------------- Main menu
void MainWindow::on_pushButton_NewField_clicked()
{
    bool success;
    // Getting new file name via dialog
    QString filename = QInputDialog::getText(this, tr("New field creation"),
                                             tr("New save name (If save with simillar name exists, it will be overwritten):"), QLineEdit::Normal,
                                              "plot", &success);
    // Returning if something gone wrong
    if (!success) return;
    // Input checking, if there is any prohibited symbols
    QString incorrSymbols = ".,<>/?!@#$%^&*\\|;:\'\"";
    for (int i = 0; i < filename.length(); i++){
        if (incorrSymbols.contains(filename[i])){
            QMessageBox messageBox;
            messageBox.setText("Symbol " + filename[i] + " is forbidden!");
            messageBox.setWindowTitle("Save creation error!");
            messageBox.exec();
            return;
        }
    }

    // Getting rows and columns
    int rows = QInputDialog::getInt(this, tr("New field creation"),
                                    tr("Amount of rows (Max - 10):"), 10, 1, 10, true, &success);
    if (!success) return;
    int columns = QInputDialog::getInt(this, tr("New field creation"),
                                     tr("Amount of columns (Max - 10):"), 10, 1, 10, true, &success);
    if (!success) return;
    // Creating "empty" simulation and saving it to disk
    sim = new Simulation(rows, columns);
    int buff = QInputDialog::getInt(this, tr("New field creation"), tr("Humidity value:"),5,1,10,true,&success);
    if (!success) return;
    sim->humidity = buff;
    buff = QInputDialog::getInt(this, tr("New field creation"), tr("Light value:"),5,1,10,true,&success);
    if (!success) return;
    sim->light = buff;
    QStringList list;
    list << "N" << "W" << "S" << "E";
    sim->lightDirection = QInputDialog::getItem(this, tr("New field creation"), tr("Direction of a light:"),list,0,false,&success);
    if (!success) return;
    sim->saveToFile(filename);
    QObject::connect(sim,&Simulation::changeInfo,this,&MainWindow::displayTileInfo);
    // Updating simulation "window"
    ui->graphicsView_Simulation->setScene(sim->getGraphicsScene());
    displayTileInfo(sim->getSelectedTile());
    // Switching to simulation page
    ui->label_simSaveName->setText(filename);
    QTimer * timer = new QTimer(this);
    connect(timer, &QTimer::timeout, this, &MainWindow::updateTime);
    timer->start(1000);
    ui->label_simInfo->setText("Humidity: " + QString::number(sim->humidity) + "\nLight: " + QString::number(sim->light) + sim->lightDirection);
    ui->stackedWidget_Main->setCurrentIndex(1);
}

// Closing app if "Quit" button clicked, with additional question
void MainWindow::on_pushButton_Quit_clicked()
{
    QMessageBox msgBox;
    msgBox.setWindowTitle("Planterra");
    msgBox.setText("Are you sure you want to quit?");
    msgBox.setStandardButtons(QMessageBox::No | QMessageBox::Yes);
    msgBox.setDefaultButton(QMessageBox::No);
    int res = msgBox.exec();
    if (res == QMessageBox::Yes) MainWindow::close();
}
// Loading existing simulation
void MainWindow::on_pushButton_LoadField_clicked(){
    QDir saves(QDir::currentPath() + "/saves");
    if (!saves.exists()){
        saves.cd(QDir::currentPath());
        saves.mkdir("saves");
        saves.cd("saves");
    }
    QString filename = QFileDialog::getOpenFileName(this, tr("Open Save file"),
                                                    saves.path(), tr("Planterra save files (*.psf)"));
    Simulation * sim = new Simulation(1,1);
    int result = sim->loadFromFile(filename);
    if (result) return;
    ui->label_simInfo->setText("Humidity: " + QString::number(sim->humidity) + "\nLight: " + QString::number(sim->light) + sim->lightDirection);
    QObject::connect(sim,&Simulation::changeInfo,this,&MainWindow::displayTileInfo);
    ui->graphicsView_Simulation->setScene(sim->getGraphicsScene());
    displayTileInfo(sim->getSelectedTile());
    ui->label_simSaveName->setText(sim->getFileSaveName());
    // Switching to simulation page
    ui->stackedWidget_Main->setCurrentIndex(1);
    QTimer * timer = new QTimer(this);
    connect(timer, &QTimer::timeout, this, &MainWindow::updateTime);
    timer->start(1000);
}
//---------------------------------------------- Simulation
// Switching to menu panel in simulation
void MainWindow::on_pushButton_simMenu_clicked(){
    ui->stackedWidget_SimulationInteractions->setCurrentIndex(1);
}
// Switching to tile panel in simulation
void MainWindow::on_pushButton_simBack_clicked(){
    ui->stackedWidget_SimulationInteractions->setCurrentIndex(0);
}
// Saving simulation
void MainWindow::on_pushButton_simSave_clicked()
{
    bool success;
    QString filename = QInputDialog::getText(this, tr("Save file"),
                                             tr("Save name (If save with simillar name exists, it will be overwritten):"),
                                             QLineEdit::Normal,
                                             sim->getFileSaveName(), &success);
    if (!success) return;
    // Input checking, if there is any prohibited symbols
        QString incorrSymbols = ".,<>/?!@#$%^&*\\|;:\'\"";
        for (int i = 0; i < filename.length(); i++){
            if (incorrSymbols.contains(filename[i])){
                QMessageBox messageBox;
                messageBox.setText("Symbol " + filename[i] + " is forbidden!");
                messageBox.setWindowTitle("Save creation error!");
                messageBox.exec();
                return;
            }
        }
    sim->saveToFile(filename);
}
// Loading simulation
void MainWindow::on_pushButton_simLoad_clicked(){
    QDir saves(QDir::currentPath() + "/saves");
    if (!saves.exists()){
        saves.cd(QDir::currentPath());
        saves.mkdir("saves");
        saves.cd("saves");
    }
    QString filename = QFileDialog::getOpenFileName(this, tr("Open Save file"),
                                                    saves.path(), tr("Planterra save files (*.psf)"));
    ui->label_simSaveName->setText(sim->getFileSaveName());

    ui->graphicsView_Simulation->scene()->clear();                  // Clearing view
    ui->graphicsView_Simulation->scene()->update();
    sim->resetSimulation();
    sim->loadFromFile(filename);
    ui->label_simInfo->setText("Humidity: " + QString::number(sim->humidity) + "\nLight: " + QString::number(sim->light) + sim->lightDirection);
    QTimer * timer = new QTimer(this);
    connect(timer, &QTimer::timeout, this, &MainWindow::updateTime);
    timer->start(1000);
}
// Returning to main menu from simulation
void MainWindow::on_pushButton_simReturn_clicked(){
    QMessageBox msgBox;                                             // Confirming intent
    msgBox.setWindowTitle("Planterra");
    msgBox.setText("Return to main menu?");
    msgBox.setStandardButtons(QMessageBox::No | QMessageBox::Yes);
    msgBox.setDefaultButton(QMessageBox::No);
    int res = msgBox.exec();
    if (res == QMessageBox::Yes){                                   // Saving simulation if needed
        msgBox.setText("Save changes?");
        res = msgBox.exec();
        if (res == QMessageBox::Yes){
            sim->saveToFile(sim->getFileSaveName());
        }
    }
    ui->graphicsView_Simulation->scene()->clear();                  // Clearing view
    ui->graphicsView_Simulation->scene()->update();
    sim->resetSimulation();                                         // Clearing simulation
    delete sim;                                                     // Finishing freeing memory
    ui->stackedWidget_Main->setCurrentIndex(0);                     // Returning to main menu
}
// Quitting app from the simulation
void MainWindow::on_pushButton_simQuit_clicked(){
    QMessageBox msgBox;                                 // Confirming intent and quitting if real
    msgBox.setWindowTitle("Planterra");
    msgBox.setText("Are you shure rou want to quit?");
    msgBox.setStandardButtons(QMessageBox::No | QMessageBox::Yes);
    msgBox.setDefaultButton(QMessageBox::No);
    int res = msgBox.exec();
    if (res == QMessageBox::Yes){
        MainWindow::close();
    }
}
// Display info about given tile
void MainWindow::displayTileInfo(GroundTile *tile){
    sim->refreshShadows();
    while (auto item = ui->verticalLayout_itemProps->takeAt(0)) {                   // Clearing widget before adding info about new tile
       delete item->widget();
    }
    QLabel *label = new QLabel();                                                   // Adding basic info about a tile
    label->setText("Tile (" + QString::number(tile->y()/60 + 1) + "," + QString::number(tile->x()/60 + 1) +
                   ")\nFertility: " + QString::number(tile->fertility) +
                   "\nConsumed fertility: " + QString::number(tile->getFertilityConsumption())+
                   "\nLight level: "+ QString::number(sim->light - tile->shadow) +
                   "\nAmount of plants: " + QString::number(tile->plants.size())+
                   "\nPlants:");
    ui->verticalLayout_itemProps->addWidget(label);
    for (int plant = 0; plant < tile->plants.size(); plant++){                      // Adding info about each plant
        Plant *currPlant = tile->plants.at(plant);
        QLabel *plantInfo = new QLabel();
        plantInfo->setText(QString::number(plant + 1) + ") " + currPlant->name +
                           "\nLevel of growth:" + QString::number(currPlant->growthLevel) +
                           "\n" + currPlant->getLifespan() +
                           "\nHealth:" + QString::number(currPlant->currentHealth) + "/" + QString::number(currPlant->maxHealth) +
                           "\nFertility consumption: " + QString::number(currPlant->getFertilityConsumption())+
                           "\n\tat next level: " + QString::number(currPlant->getFertilityConsumprion(1)) +
                           "\nAgressiveness level: " + QString::number(currPlant->agressivness) +
                           "\nRequired light level: " + QString::number(currPlant->reqLightLevel) +
                           "\nRequired humidity level: " + QString::number(currPlant->reqHumLevel));
        ui->verticalLayout_itemProps->addWidget(plantInfo);
    }
}
// Asks user index of a tile to be deleted and deletes it
void MainWindow::on_pushButton_simDeletePlant_clicked()
{
    GroundTile *tile = sim->getSelectedTile();                                      // Copy of a pointer to the selected tile, so we wont get it every time again
    if (tile->plants.size() == 0){                                                  // No plants -> nothing to delete
        QMessageBox msgBox;
        msgBox.setWindowTitle("Planterra");
        msgBox.setText("Selected tile has no plants!");
        msgBox.setStandardButtons(QMessageBox::Ok);
        msgBox.setDefaultButton(QMessageBox::Ok);
        msgBox.exec();
        return;
    }
    bool success;
    int plant = QInputDialog::getInt(this, tr("Delete plant"),                      // Getting index of a plant to be deleted
                                    tr("Enter index of plant to delete:"), 1, 1, tile->plants.size(), true, &success);
    if (!success) return
    ui->graphicsView_Simulation->scene()->removeItem(tile->plants.at(plant - 1));   // First, removing from the scene
    delete(tile->plants[plant - 1]);                                                                   // Third, from the memory
    tile->plants.remove(plant - 1);                                                 // Second, from the tile
    displayTileInfo(tile);                                                          // Updating tile info
}

void MainWindow::on_pushButton_simAddPlant_clicked(){
    GroundTile *tile = sim->getSelectedTile();
    if (tile->plants.size()){
        QMessageBox msgBox;                                             // Confirming intent
        msgBox.setWindowTitle("Planterra");
        msgBox.setText("This tile already has a plant in it!");
        msgBox.setStandardButtons(QMessageBox::Ok);
        msgBox.setDefaultButton(QMessageBox::Ok);
        int res = msgBox.exec();
        return;
    }
    QStringList types;
    types << "Grass" << "Herb" << "Shrub" << "Tree";
    bool success;
    QString type = QInputDialog::getItem(this, tr("Add plant"),tr("Select type of plant"),types,0,false, &success);
    if (!success)
        return;
    int plant = 0;
    if (type == "Grass"){
        plant = 0;
    } else if (type == "Herb"){
        plant = 1;
    } else if (type == "Shrub"){
        plant = 2;
    } else {
        plant = 3;
    }
    tile->addPlant(plant);
    sim->refreshShadows();
    ui->graphicsView_Simulation->setScene(sim->getGraphicsScene());
}

void MainWindow::updateTime(){
    ui->label_simTime->setText(sim->getSimulationTime());
    displayTileInfo(sim->getSelectedTile());
}

void MainWindow::on_pushButton_simHumidity_clicked(){
    bool success;
    int hum = QInputDialog::getInt(this, tr("Change humidity"),
                                    tr("Humidity value:"), 5, 1, 10, true, &success);
    if (!success) return;
    sim->humidity = hum;
     ui->label_simInfo->setText("Humidity: " + QString::number(sim->humidity) + "\nLight: " + QString::number(sim->light) + sim->lightDirection);
}

void MainWindow::on_pushButton_simLight_clicked(){
    bool success;
    int lig = QInputDialog::getInt(this, tr("Change humidity"),
                                    tr("Light value:"), 5, 1, 10, true, &success);
    if (!success) return;
    sim->light= lig;
    QStringList list;
    list << "N" << "W" << "S" << "E";
    QString res = QInputDialog::getItem(this, tr("New field creation"), tr("Direction of a light:"),list,0,false,&success);
    if (!success) return;
    sim->lightDirection = res;
    ui->label_simInfo->setText("Humidity: " + QString::number(sim->humidity) + "\nLight: " + QString::number(sim->light) + sim->lightDirection);
    sim->refreshShadows();
}
