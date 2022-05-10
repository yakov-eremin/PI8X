#ifndef PLAYER_H
#define PLAYER_H
#include <QString>
#include <QGraphicsView>
#include <vector>


/*!
    \brief Абстрактный класс, предназнасенный для описания игровых персонажей

    Данный класс предназначен для описания классов игровых персонажей "Мафии" на его основе.
*/
class player
{
protected:
    ///Структура элемента списка подозрительных
    struct _vote {
        quint8 id; ///<Номер игрока
        qint8 priority; ///<Его приоритет
        bool operator== (const quint8 &c)
        {
            return (this->id == c);
        }
    };
        QString image = "";
        std::vector<_vote> enemies;
        /*!
        Вносит игрока в список подозрительных если его там нет. В ином случае изменяет его приоритет.
        \param[in] i Номер вносимого игрока
        \param[in] p Приоритет
        */
        void addEnemy(quint8 i, qint8 p);


        static bool comp(const _vote &a, const _vote &b);

private:
    QGraphicsView *block;
public:

    bool is_life = true;
    //Блок описания игрока
    quint8 ID; ///Номер
    QString Name; ///Имя
    ///Определяет пол персонажа
    enum {
        male, ///< Мужчина
        female ///< Женщина
    } Gender;
    quint8 Age; ///Возраст
    /// Психологические параметры
    struct {
        quint8 Eloquence; ///<Красноречие
        quint8 Incredulity; ///<Недоверчивость
        quint8 Aggression; ///<Скрытая агрессия
        quint8 Determination; ///<Решимость
    } Mental;
    player();
    /*!
    \param[in] id Порядковый номер игрока
    \param[in] name Имя игрока
    \param[in] gender Пол игрока
    \param[in] age Возраст игрока
    \param[in] elo Уровень красноречия
    \param[in] inc Уровень недоверчивости
    \param[in] pas Уровень агрессии
    \param[in] det Уровень решимости
    */
    player(quint8 id, QString name, QString gender, quint8 age, quint8 elo, quint8 inc, quint8 pas, quint8 det);
    /*!
    Определяет голос игрока в ночном голосовании
    \param[in] time Текущая секунда игры
    \param[in] votes Общая таблица голосов на текущей стадии
    \param[in] p_list Список игроков
    \return Номер игрока, за которого проголосовал текущий игрок
    */
    virtual quint8 Action(quint16 time, std::vector<player*> p_list, quint8 *votes = nullptr) = 0;
    /*!
    Действие игрока в момент обсуждения
    \param[in] time Текущая секунда игры
    \param[in] p_list Список игроков
    \return Номер игрока, о котором хочет высказаться текущий игрок
    */
    virtual quint8 Discussion(quint16 time, std::vector<player*> p_list) = 0;
    /*!
    Действие игрока в случае когда ему высказывают своё мнение
    \param[in] a Игрок, который высказывается
    \param[in] b Номер игрока, о котором высказываются
    \param[in] is_good Высказывание положительное?
    */
    virtual void Listen(player* a, quint8 b, bool is_good) = 0;
    /*!
    Определяет голос игрока в дневном голосовании
    \param[in] time Текущая секунда игры
    \param[in] votes Общая таблица голосов на текущей стадии
    \param[in] p_count Общее число игроков
    \return Номер игрока, за которого проголосовал текущий игрок
    */
    quint8 vote(quint16 time, quint8* votes, quint8 p_count);

    void Die(bool h);
    /*!
    Создает графическую сцену для вывода иконки персонажа. При h = true скрывает роль.
    \param[in] h Флаг сокрытия роли
    \return Ссылку на графическую сцену
    */
    QGraphicsScene* createScene(bool h);
    /*!
    Привязывает к классу его выджет для вывода
    \param[in] b Ссылка на виджет
    */
    void setGraphicsView(QGraphicsView *b);
    /*!
    Удаляет игрока из собственного списка подозреваемых персонажа
    \param[in] i индекс в списке
    */
    void delEnemy(quint8 i);
    /*!
    Высчитывает вероятность согласно коэффициенту(p*11), и с помощью генерации случайного числа приводит её в реальность.
    \param[in] p Коэффициент
    \return true с вероятностью (p*11)%, иначе false
    */
    static bool accident(quint8 p);
};

#endif // PLAYER_H
