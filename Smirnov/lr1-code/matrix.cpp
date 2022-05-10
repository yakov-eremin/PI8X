#include "matrix.h"

Matrix::Matrix()
{

}

Matrix::Matrix(QPoint Size)
{
    mtrx.resize(Size.x());
    for (int i = 0; i < Size.x(); i++) mtrx[i].fill(0, Size.y());
    size = Size;
}

QPoint Matrix::getSize()
{
    return size;
}

Matrix Matrix::T()
{
    Matrix buf({size.y(), size.x()});
    for (int i = 0; i < size.x(); i++) {
        for (int j = 0; j < size.y(); j++) {
            buf.mtrx[j][i] = mtrx[i][j];
        }
    }
    return buf;
}

Matrix Matrix::operator*(const Matrix &M)
{
    if (size.y() != M.size.x()) return Matrix();
    Matrix buf({size.x(), size.x()});
    for (int i = 0; i < size.y(); i++) {
        for (int j = 0; j < size.x(); j++) {
            buf.mtrx[i][j] = 0;
            for (int k = 0; k < size.y(); k++) {
                buf.mtrx[i][j] += mtrx[k][j] * M.mtrx[i][k];
            }
        }
    }
    return buf;
}

QVector<double>& Matrix::operator[](quint32 index)
{
    return mtrx[index];
}
