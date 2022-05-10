#include "doctor.h"
#include <QGraphicsTextItem>

doctor::doctor()
{

}

doctor::doctor(const player &player)
{
    Name = player.Name;
    Gender = player.Gender;
    Age = player.Age;
    Mental = player.Mental;
    image = ":/resource/img/doctor.png";
}

doctor::doctor(quint8 id, QString name, QString gender, quint8 age, quint8 elo, quint8 inc, quint8 pas, quint8 det) : player (id,name,gender,age,elo,inc,(pas < 3)? 0 : pas - 2,det) {
    image = ":/resource/img/doctor.png";
}

quint8 doctor::Action(quint16 time, std::vector<player*> p_list, quint8 *votes) {
    srand(std::time(0));
    if (time < rand() % 9) return 0;
    std::vector<quint8> possibly;
    for (unsigned int i = 0; i < p_list.size(); i++) {
        if ((i+1) == last_choice) continue;
        if (p_list[i]->is_life) {
            bool f = true;
            for (unsigned int j = 0; j < enemies.size(); j++) {
                if (enemies[j].id == i+1 && enemies[j].priority > 1) {
                    f = false;
                    break;
                }
            }
            if (f) possibly.push_back(i+1);
        }
    }
    if (possibly.empty()) {
        for (unsigned int j = 0; j < enemies.size(); j++) {
            enemies[j].priority--;
            if (enemies[j].id != last_choice) {
                possibly.push_back(enemies[j].id);
            }
        }
    }
    return last_choice = possibly[rand() % possibly.size()];
}

quint8 doctor::Discussion(quint16 time, std::vector<player*> p_list) {
    if (!is_life) return p_list.size() + 1;
    srand(std::time(0));
    if (time < rand() % 39) return 0;
    std::vector<quint8> possibly;
    for (unsigned int i = 0; i < p_list.size(); i++) {
        if (p_list[i]->is_life) {
            if (i+1 == ID || i+1 == last_choice) continue;
            possibly.push_back(i+1);
        }
    }
    quint8 result = 0;
    if (enemies.empty()) {
        result = possibly[rand() % possibly.size()];
        if (accident(Mental.Determination)) {
            for (unsigned int i = 0; i < p_list.size(); i++) {
                p_list[i]->Listen(this, result, true);
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

void doctor::Listen(player* a, quint8 b, bool is_good) {
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
