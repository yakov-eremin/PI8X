#ifndef MATRIX_H
#define MATRIX_H
#include <QPoint>
#include <QVector>


class Matrix
{
private:
    QPoint size;
    QVector<QVector<double>> mtrx;
public:
    Matrix();
    Matrix(QPoint Size);
    QPoint getSize();
    Matrix T();
    Matrix operator*(const Matrix &M);
    QVector<double>& operator[](quint32 index);
};

#endif // MATRIX_H
