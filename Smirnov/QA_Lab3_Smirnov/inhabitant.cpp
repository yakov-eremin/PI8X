#include "inhabitant.h"
#include <QGraphicsView>
#include <QFont>
#include <QGraphicsTextItem>

inhabitant::inhabitant()
{

}

inhabitant::inhabitant(const player &player)
{
    Name = player.Name;
    Gender = player.Gender;
    Age = player.Age;
    Mental = player.Mental;
    image = ":/resource/img/inhabitant_.png";
}

inhabitant::inhabitant(quint8 id, QString name, QString gender, quint8 age, quint8 elo, quint8 inc, quint8 pas, quint8 det) : player (id,name,gender,age,elo,inc,pas,det) {
    image = ":/resource/img/inhabitant_.png";
}

quint8 inhabitant::Action(quint16 time, std::vector<player*> p_list, quint8 *votes) {
    return time + p_list.size() + *votes;
}

quint8 inhabitant::Discussion(quint16 time, std::vector<player*> p_list) {
    if (!is_life) return p_list.size() + 1;
    srand(std::time(0));
    if (time < rand() % 39) return 0;
    std::vector<quint8> possibly;
    for (unsigned int i = 0; i < p_list.size(); i++) {
        if (p_list[i]->is_life) {
            if (i+1 == ID) continue;
            possibly.push_back(i+1);
        }
    }
    quint8 result = 0;
    if (enemies.empty()) {
        result = possibly[rand() % possibly.size()];
        if (accident(Mental.Determination)) {
            for (unsigned int i = 0; i < p_list.size(); i++) {
                p_list[i]->Listen(this, result, !accident(Mental.Aggression));
            }
        }
        else {
            return p_list.size() + 1;
        }
    } else {
        std::sort(enemies.begin(), enemies.end(), comp);
        result = enemies[0].id;
        for (unsigned int i = 0; i < p_list.size(); i++) {
            if (i+1 == ID) continue;
            p_list[i]->Listen(this, result, false);
        }
    }
    return result;
}

void inhabitant::Listen(player* a, quint8 b, bool is_good) {
    if (!is_life) return;
    if (b == ID) {
        addEnemy(a->ID, 2);
        return;
    }
    quint8  number = a->Mental.Eloquence - Mental.Incredulity * 3 / 4;
    if (number < 0) number = 0;
    if (accident(number)) {
        if (is_good) addEnemy(b, -1);
        else addEnemy(b, 1);
    }
    else {
        if (accident(a->Mental.Aggression)) {
            addEnemy(a->ID, 2);
            if (is_good) addEnemy(b, 1);
            else addEnemy(b, -1);
        }
        else addEnemy(a->ID, 1);
    }
}
