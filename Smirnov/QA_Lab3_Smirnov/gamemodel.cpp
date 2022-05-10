#include "gamemodel.h"
#include "ui_gamemodel.h"
#include <QTimer>


GameModel::GameModel(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::GameModel)
{
    ui->setupUi(this);
    ui->textBrowser->append("Карты розданы. Игра началась!");
    timer = new QTimer();
    connect(timer, SIGNAL(timeout()),this,SLOT(timerInterrupt()));
    timer->start(1000);
}

GameModel::GameModel(QWidget *parent, std::vector<player*> *list, bool h) :
    QWidget(parent),
    ui(new Ui::GameModel),
    Players (*list),
    is_hidden(h)
{
    ui->setupUi(this);
    mafia d;
    doctor b;
    std::vector<quint8> *buf = new std::vector<quint8>;
    quint8 m = (Players.size() < 10) ? 3 : 4;
    quint8 n = Players.size() / m;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            if (typeid(*Players[i*m+j]) == typeid(b)) Doctor = Players[i*m+j];
            if (typeid(*Players[i*m+j]) == typeid(d)) {
                Mafia.push_back(Players[i*m+j]);
                buf->push_back(i*m+j+1);
                m_count++;
            } else c_count++;
            QGraphicsView *buff = new QGraphicsView();
            QGraphicsScene *scene = Players[i*m+j]->createScene(is_hidden);
            buff->setScene(scene);
            buff->setToolTip("<h3>"+ QString::number(i*m+j + 1)+ " " + Players[i*m+j]->Name +"</h3><p>Пол: " + ((Players[i*m+j]->Gender == 0) ? "Мужской" : "Женский") + "<br>Возраст: " + QString::number(Players[i*m+j]->Age) + "<br><b>Данные:</b><br><i>Красноречие: " + QString::number(Players[i*m+j]->Mental.Eloquence) + "</i><br><i>Скептичность: " + QString::number(Players[i*m+j]->Mental.Incredulity) + "</i><br><i>Агрессивность: " + QString::number(Players[i*m+j]->Mental.Aggression) + "</i><br><i>Решимость: " + QString::number(Players[i*m+j]->Mental.Determination) + "</i></p>");
            Players[i*m+j]->setGraphicsView(buff);
            ui->gridLayout->addWidget(buff, i, j);
        }
    }
    m = Players.size() % m;
    for (int i = 0; i < m; i++) {
        if (typeid(*Players[Players.size() - m + i]) == typeid(b)) Doctor = Players[Players.size() - m + i];
        if (typeid(*Players[Players.size() - m + i]) == typeid(d)) {
            Mafia.push_back(Players[Players.size() - m + i]);
            buf->push_back(Players.size() - m + i + 1);
            m_count++;
        } else c_count++;
        QGraphicsView *buff = new QGraphicsView();
        QGraphicsScene *scene = Players[Players.size() - m + i]->createScene(is_hidden);
        buff->setScene(scene);
        buff->setToolTip("<h3>"+ QString::number(Players.size() - m + i + 1)+ " " + Players[Players.size() - m + i]->Name +"</h3><p>Пол: " + ((Players[Players.size() - m + i]->Gender == 0) ? "Мужской" : "Женский") + "<br>Возраст: " + QString::number(Players[Players.size() - m + i]->Age) + "<br><b>Данные:</b><br><i>Красноречие: " + QString::number(Players[Players.size() - m + i]->Mental.Eloquence) + "</i><br><i>Скептичность: " + QString::number(Players[Players.size() - m + i]->Mental.Incredulity) + "</i><br><i>Агрессивность: " + QString::number(Players[Players.size() - m + i]->Mental.Aggression) + "</i><br><i>Решимость: " + QString::number(Players[Players.size() - m + i]->Mental.Determination) + "</i></p>");
        Players[Players.size() - m + i]->setGraphicsView(buff);
        ui->gridLayout->addWidget(buff, n, i);
    }
    for (unsigned int i = 0; i < buf->size(); i++) {
        static_cast<mafia*>(Mafia[i])->addAllies(buf);
    }
    votes = new quint8[Players.size()];
    for (unsigned int i = 0; i < Players.size(); i++) votes[i] = 0;
    flags = new bool[Players.size()];
    for (unsigned int i = 0; i < Players.size(); i++) flags[i] = false;
    flags_night = new bool[Mafia.size()];
    for (unsigned int i = 0; i < Mafia.size(); i++) flags_night[i] = false;
    ui->textBrowser->append("Карты розданы. Игра началась!");
    timer = new QTimer();
    connect(timer, SIGNAL(timeout()),this,SLOT(timerInterrupt()));
    timer->start(1000);
}

GameModel::~GameModel()
{
    delete ui;
    delete timer;
}

void GameModel::timerInterrupt()
{
    if (internalTime == 0) ui->textBrowser->append("Город засыпает. Просыпается мафия.");
    if (internalTime > 0 && internalTime < 21) {
        for (unsigned int i = 0; i < Mafia.size(); i++) {
            if (flags_night[i]) continue;
            quint8 m = Mafia[i]->Action(internalTime, Players, votes);
            if (m != 0) {
                if (m != Players.size() + 1) {
                    votes[m - 1]++;
                    if (is_hidden) {
                        ui->textBrowser->append("<i>Мафия " + QString::number(i+1) + " голосует за " + QString::number(m)+ " " + Players[m-1]->Name + ".</i>");
                    } else {
                        ui->textBrowser->append("<i>" + QString::number(Mafia[i]->ID) + " " + Mafia[i]->Name + " голосует за " + QString::number(m)+ " " + Players[m-1]->Name + ".</i>");
                    }
                    ui->textBrowser->update();
                }
                flags_night[i] = true;
            }
        }
        bool f = true;
        for (unsigned int i = 0; i < Mafia.size(); i++) {
            if (!flags_night[i]) {f = false; break;}
        }
        if (f) {
            ui->textBrowser->append("Все члены мафии сделали решение.");
            internalTime = 21;
            return;
        }
    }
    if (internalTime == 21) {
        quint8 index, max = 0;
        bool duplicate = false;
        for (unsigned int i = 0; i < Players.size(); i++) {
            if (votes[i] == max) {
                duplicate = true;
            }
            if (votes[i] > max) {
                max = votes[i];
                index = i;
                duplicate = false;
            }
        }
        if (duplicate) {
            is_wounded = 0;
        } else {
            is_wounded = index + 1;
        }
        if (Doctor->is_life) {
            ui->textBrowser->append("Мафия засыпает. Просыпается доктор.");
            for (unsigned int i = 0; i < Mafia.size(); i++) flags_night[i] = false;
        }
        else {
            ui->textBrowser->append("Мафия засыпает. Ночь подходи к концу.");
            internalTime = 31;
        }
        for (unsigned int i = 0; i < Mafia.size(); i++) flags_night[i] = false;
        for (unsigned int i = 0; i < Players.size(); i++) votes[i] = 0;
    }
    if (internalTime > 21 && internalTime < 31) {
        quint8 h = Doctor->Action(internalTime - 21, Players);
        if (h != 0) {
            is_healed = h;
            if (is_hidden) {
                ui->textBrowser->append("<i>Доктор выбрал " + QString::number(h)+ " " + Players[h-1]->Name + ".</i>");
            } else {
                ui->textBrowser->append("<i>" + QString::number(Doctor->ID) + " " + Doctor->Name + " выбрал " + QString::number(h)+ " " + Players[h-1]->Name + ".</i>");
            }
            ui->textBrowser->update();
            ui->textBrowser->append("Доктор сделал решение.");
            internalTime = 31;
            return;
        }
    }
    if (internalTime == 31) {

        if (is_wounded != is_healed && is_wounded != 0) {
            ui->textBrowser->append("Сегодня ночью был убит игрок - " + QString::number(is_wounded) + " " + Players[is_wounded - 1]->Name + ".");
            Players[is_wounded - 1]->Die(is_hidden);
            for (unsigned int i = 0; i < Players.size();i++) {
                Players[i]->delEnemy(is_wounded);
            }
            mafia d;
            if (typeid(*Players[is_wounded - 1]) == typeid(d)) m_count--;
            else c_count--;
        }
        else ui->textBrowser->append("Ночь прошла без происшествий.");
        ui->textBrowser->append("Город просыпается. Начинается обсуждение.");
        is_wounded = is_healed = 0;
        for (unsigned int i = 0; i < Players.size(); i++) {
            votes[i] = 0;
        }
        if (m_count == c_count) {
            GameOver(false);
        }
        if (m_count == 0) {
            GameOver(true);
        }
    }
    if (internalTime > 31 && internalTime < 71) {
        for (unsigned int i = 0; i < Players.size(); i++) {
            if (flags[i]) continue;
            quint8 m = Players[i]->Discussion(internalTime - 31, Players);
            if (m != 0) {
                flags[i] = true;
                if (m != Players.size() + 1) ui->textBrowser->append("<i>" + QString::number(Players[i]->ID) + " " + Players[i]->Name + " высказал своё мнение о " + QString::number(m)+ " " + Players[m-1]->Name + ".</i>");
                ui->textBrowser->update();
            }
        }
        bool f = true;
        for (unsigned int i = 0; i < Players.size(); i++) {
            if (!flags[i]) {f = false; break;}
        }
        if (f) {
            ui->textBrowser->append("Все игроки выссказались.");
            internalTime = 71;
            return;
        }
    }
    if (internalTime == 71) {
        ui->textBrowser->append("Обсуждение подошло к концу. Время голосовать.");
        for (unsigned int i = 0; i < Players.size(); i++) flags[i] = false;
    }
    if (internalTime > 71 && internalTime < 89) {
        for (unsigned int i = 0; i < Players.size(); i++) {
            if (flags[i]) continue;
            quint8 m = Players[i]->vote(internalTime, votes, Players.size());
            if (m != 0) {
                flags[i] = true;
                if (m != (Players.size() + 1)) {
                    votes[m - 1]++;
                    ui->textBrowser->append("<i>" + QString::number(Players[i]->ID) + " " + Players[i]->Name + " голосует за " + QString::number(m)+ " " + Players[m-1]->Name + ".</i>");
                    ui->textBrowser->update();
                }
            }
        }
        bool f = true;
        for (unsigned int i = 0; i < Players.size(); i++) {
            if (!flags[i]) {f = false; break;}
        }
        if (f) {
            ui->textBrowser->append("Все игроки проголосовали.");
            internalTime = 89;
            return;
        }
    }
    if (internalTime == 89) {
        quint8 index, max = 0;
        bool duplicate = false;
        for (unsigned int i = 0; i < Players.size(); i++) {
            if (votes[i] == max) {
                duplicate = true;
            }
            if (votes[i] > max) {
                duplicate = false;
                max = votes[i];
                index = i;
            }
        }
        if (duplicate) {
            ui->textBrowser->append("Жители не смогли определиться.");
        } else {
            ui->textBrowser->append("Жители приняли решение. Казнён игрок - " + QString::number(index + 1) + " " + Players[index]->Name + ".");
            Players[index]->Die(is_hidden);
            for (unsigned int i = 0; i < Players.size();i++) {
                Players[i]->delEnemy(index+1);
            }
            mafia d;
            if (typeid(*Players[index]) == typeid(d)) m_count--;
            else c_count--;
        }
        for (unsigned int i = 0; i < Players.size(); i++) flags[i] = false;
        for (unsigned int i = 0; i < Players.size(); i++) votes[i] = 0;
        ui->textBrowser->append("День подошёл к концу.");
        if (m_count == c_count) {
            GameOver(false);
        }
        if (m_count == 0) {
            GameOver(true);
        }
    }
    internalTime++;
    ui->textBrowser->update();
    if (internalTime == 90) {
        internalTime = 0;
    }
}

void GameModel::GameOver(bool winner) {
    timer->stop();
    if (winner) {
        ui->textBrowser->append("Победила команда мирных жителей. Город стал светлее, чем обычно.");
    }
    else {
        ui->textBrowser->append("Победила мафия. Город заполонила тьма.");
    }
    ui->textBrowser->append("Для завершения закройте окно.");
}
