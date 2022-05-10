#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "player.h"
#include "doctor.h"
#include "inhabitant.h"
#include "mafia.h"
#include "gamemodel.h"
#include <vector>
#include <algorithm>
#include <QFile>
#include <QtXml>
#include <QTextDecoder>
#include <iostream>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_pushButton_clicked()
{
    QTextCodec *russianCodec = QTextCodec::codecForName("UTF-8");
    QTextCodec::setCodecForLocale(russianCodec);
    std::vector<player*> PlayersList;
    std::vector<quint8> Cards; //Колоду карт для игры "Мафия" достаточно представить массивом из целочисленного типа данных, т.к. эти карты владеют лишь одним параметром. Создавать класс для карты нет смысла.
    //Заполним колоду
    for (int i = 0; i < ui->spinBox_2->value(); i++) {
        Cards.push_back(1);
    }
    Cards.push_back(2);
    for (int i = 0; i < ui->spinBox->value() - ui->spinBox_2->value() - 1; i++) {
        Cards.push_back(0);
    }
    unsigned seed = std::chrono::system_clock::now().time_since_epoch().count();
       std::default_random_engine e(seed);

    std::shuffle(Cards.begin(), Cards.end(), e);
    //Получаем список игроков из файла
    QFile file("players.xml");
    if (file.open(QIODevice::ReadOnly)) {
        QDomDocument doc;
        if (doc.setContent(&file)) {
            QDomElement elem = doc.documentElement();
            if (elem.tagName() != "list") {
                ui->statusbar->showMessage("players.xml повреждён! Замените файл!");
                return;
            }
            QDomNode domNode = elem.firstChild();
            for (int i = 0; i < ui->spinBox->value(); i++) {
                QDomElement el;
                el = domNode.toElement();
                if (el.tagName() != "player") {
                    ui->statusbar->showMessage("players.xml повреждён! Замените файл!");
                    return;
                }
                QString name = el.attribute("name", "error");
                QString gender = el.attribute("gender", "error");
                if (name == "error" || gender == "error") {
                    ui->statusbar->showMessage("players.xml повреждён! Замените файл!");
                    return;
                };
                bool ok = true;
                qint8 age, elo, inc, agg, det;

                age = el.attribute("age", "error").toInt(&ok);
                if (!ok) {
                    ui->statusbar->showMessage("players.xml повреждён! Замените файл!");
                    return;
                } else {
                    if (age < 0) age *= -1;
                    if (age > 99) age = 25;
                }

                elo = el.attribute("eloquence", "error").toInt(&ok);
                if (!ok) {
                    ui->statusbar->showMessage("players.xml повреждён! Замените файл!");
                    return;
                } else {
                    if (elo < 0) elo = 1;
                    if (elo > 9) elo = 9;
                }

                inc = el.attribute("incredulity", "error").toInt(&ok);
                if (!ok) {
                    ui->statusbar->showMessage("players.xml повреждён! Замените файл!");
                    return;
                } else {
                    if (inc < 0) inc = 1;
                    if (inc > 9) inc = 9;
                }

                agg = el.attribute("aggression", "error").toInt(&ok);
                if (!ok) {
                    ui->statusbar->showMessage("players.xml повреждён! Замените файл!");
                    return;
                } else {
                    if (agg < 0) agg = 1;
                    if (agg > 9) agg = 9;
                }

                det = el.attribute("determination", "error").toInt(&ok);
                if (!ok) {
                    ui->statusbar->showMessage("players.xml повреждён! Замените файл!");
                    return;
                } else {
                    if (det < 0) det = 1;
                    if (det > 9) det = 9;
                }

                switch (Cards[i]) {
                case 0: PlayersList.push_back(new inhabitant(i + 1,(el.attribute("name")), el.attribute("gender"), el.attribute("age").toInt(), el.attribute("eloquence").toInt(), el.attribute("incredulity").toInt(), el.attribute("aggression").toInt(), el.attribute("determination").toInt()));
                    break;
                case 1: PlayersList.push_back(new mafia(i+1, el.attribute("name"), el.attribute("gender"), el.attribute("age").toInt(), el.attribute("eloquence").toInt(), el.attribute("incredulity").toInt(), el.attribute("aggression").toInt(), el.attribute("determination").toInt()));
                    break;
                case 2: PlayersList.push_back(new doctor(i+1, el.attribute("name"), el.attribute("gender"), el.attribute("age").toInt(), el.attribute("eloquence").toInt(), el.attribute("incredulity").toInt(), el.attribute("aggression").toInt(), el.attribute("determination").toInt()));
                    break;
                }
                domNode = domNode.nextSiblingElement();
            }
        }
        else {
            ui->statusbar->showMessage("players.xml повреждён! Замените файл!");
            return;
        }
    }
    GameModel *window = new GameModel(nullptr,&PlayersList, ui->checkBox_5->isChecked());
    window->show();
    this->close();
}

void MainWindow::on_spinBox_valueChanged(int arg1)
{
    switch (arg1) {
    case 5:
        ui->spinBox_2->setMaximum(1);
        break;
    case 6:
    case 7:
        ui->spinBox_2->setMaximum(2);
        break;
    case 8:
    case 9:
        ui->spinBox_2->setMaximum(3);
        break;
    case 10:
    case 11:
        ui->spinBox_2->setMaximum(4);
        break;
    case 12:
    case 13:
        ui->spinBox_2->setMaximum(5);
        break;
    case 14:
    case 15:
    case 16:
        ui->spinBox_2->setMaximum(6);
        break;
    }
}
