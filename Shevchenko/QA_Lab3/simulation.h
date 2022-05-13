#ifndef SIMULATION_H
#define SIMULATION_H

#include <QObject>
#include <QString>
#include <QFile>
#include <QTextStream>
#include <QVector>
#include <ctime>
#include "groundtile.h"
#include <QGraphicsScene>
#include <QGraphicsPixmapItem>

/*!
    \brief Основной класс, отвечающий за механику процесса

    Предназначен для произведение симуляции развития и смерти растений
*/

class Simulation : public QObject
{
    Q_OBJECT
    /// Количество рядов в поле
    int rowsCount;
    /// Количество колонок в поле
    int columnsCount;
    /// Время, прошедщее с начала симуляции
    time_t elapsedTime;
    /// Смещение времени, если симуляция была загружена из сохранения
    time_t loadTime;
    /// Массив клеток рабочего поля
    QVector<QVector<GroundTile *>> tiles;
    /// Текущая выбранная клетка
    GroundTile *selectedTile;
    /// Фоновое изображение
    QGraphicsPixmapItem background;
    /// Указатель на сцену рендера
    QGraphicsScene *scene;
    /// Имя для файла сохранения по-умолчанию
    QString fileSaveName;
public:
    /// Глобальный показатель влажности
    int humidity;
    /// Глобавльный показатель освещённости
    int light;
    /// Направление ветра
    QString lightDirection;
    /*!
        \brief Конструктор симуляции
        \param[in] newRowsCount Количество рядов
        \param[in] newcolumnsCount Количество столбцов
    */
    Simulation(int newRowsCount, int newColumnsCount);  // Class constructor
    /// Геттер количества рядов
    int getRowsCount();
    /// Геттер количества столбцов
    int getColumnsCount();
    /// Геттер выбранной клетки
    GroundTile* getSelectedTile();
    /*!
        \brief метод сохранения симуляции в файл
        \param[in] filename Имя файла для сохранения
    */
    int saveToFile(QString filename);
    /*!
        \brief загрузки симуляции из файла
        \param[in] filename Имя файла для загрузки
    */
    int loadFromFile(QString filePath);
    /// геттер сцены рендера
    QGraphicsScene *getGraphicsScene();
    /// Геттер имени сохранения файла
    QString getFileSaveName();
    /// Сбрасывает состояние симуляции
    void resetSimulation();
    /// Геттер времени, прошедшего с симуляции
    QString getSimulationTime();
    /// Метод, производящий шаг симуляции
    void simulationTick();
    /// Метод обновления состояния теней
    void refreshShadows();
public slots:
    void sendChangeToForm(GroundTile* tile);            // "Resender" of the "clicked" signal from tile to UI
    /*!
        \brief Сигнал о смерти растения и необходимости удалить его со сцены
        \param[in] plant указатель на растение
    */
    void plantDied(Plant* plant);                       // Slot, recieves signal from Plant object when plant dies and should be removed from the scene
signals:
    /*!
        \brief Сигнал, обновляющий информацию о выбранной клетке
        \param[in] tile указатель на клетку
    */
    void changeInfo(GroundTile* tile);
};



#endif // SIMULATION_H
