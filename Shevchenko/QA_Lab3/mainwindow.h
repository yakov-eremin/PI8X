#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "simulation.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
public:
    explicit MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
public slots:
    void displayTileInfo(GroundTile *tile);
private slots:
    void on_pushButton_NewField_clicked();

    void on_pushButton_LoadField_clicked();

    void on_pushButton_Quit_clicked();
//------------------------------------------------------

    void on_pushButton_simBack_clicked();

    void on_pushButton_simSave_clicked();

    void on_pushButton_simLoad_clicked();

    void on_pushButton_simReturn_clicked();

    void on_pushButton_simQuit_clicked();

    void on_pushButton_simDeletePlant_clicked();

    void on_pushButton_simMenu_clicked();

    void on_pushButton_simAddPlant_clicked();
//-------------------------------------------------------
    void updateTime();

    void on_pushButton_simHumidity_clicked();

    void on_pushButton_simLight_clicked();

private:
    Ui::MainWindow *ui;
    Simulation *sim;
};

#endif // MAINWINDOW_H
