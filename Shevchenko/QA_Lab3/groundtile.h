#ifndef GROUNDTILE_H
#define GROUNDTILE_H

#include <QVector>
#include "plant.h"
#include "grass.h"
#include "herb.h"
#include "shrub.h"
#include "tree.h"
#include <QMouseEvent>
#include <QGraphicsRectItem>
#include <QObject>

#include <QDebug>

/*!
    \brief Класс клетки карты
*/

class GroundTile : public QObject, public QGraphicsRectItem
{
    Q_OBJECT
public:
    /// Плодородие клетки
    int fertility;
    /// Растения, находящиеся на этой клетке
    QVector<Plant*> plants; 
    /// Конструктор класса по умолчанию
    GroundTile();
    /*!
        \brief Конструктор класса
        \param[in] newFertility Уровень плодородия клетки
    */
    GroundTile(int newFertility);
    /// Деструктор класса
    ~GroundTile();
    /// Метод обновления роста всех растений на клетке
    void growthStep();
    /*!
        \brief Возвращает суммарное потребления плодородия растениями
        \return Значение потребления плодородия
    */
    int getFertilityConsumption();
    /*!
        \brief обработчик нажатия на клетку
        \param[in] event Указатель на ивент клика мыщи
    */
    void mousePressEvent(QGraphicsSceneMouseEvent *event);
    /*!
        \brief метод удаления растения по индексу
        \param[in] index индекс элемента, который необходимо удалить
    */
    void deletePlant(int index);
    /*!
        \brief добавления растения на клетку по индексу его типа
        \param[in] index индекс типа растения
    */
    Plant* addPlant(int index);
    /*!
        \brief метод шага симуляции
        \param[in] light показатель света для рассчётов
        \param[in] humidity
    */
    void simulationTick(int light, int humidity);
    /// значение затенения клетки
    int shadow;
signals:
    /*!
        \brief сигнал клика на клетку
        \param[in] tile Указатель на целевую клетку
    */
    void clicked(GroundTile *tile);
    /*!
        \brief сигнал гибели растения
        \param[in] plant указатель на растение
    */
    void plantDied(Plant* plant);
};

#endif // GROUNDTILE_H
