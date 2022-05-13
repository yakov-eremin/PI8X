#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QFileDialog>
#include <QMap>
#include <QtMath>
#include <QRandomGenerator>
#include <QTime>


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


void MainWindow::on_pushButton_7_clicked() //Открыть файл
{
    QString fileName = QFileDialog::getOpenFileName(this,
                                    QString::fromUtf8("Открыть файл"),
                                    QDir::currentPath(),
                                    QString::fromUtf8("Изображение JPG (*.jpg);;Все файлы (*.*)"));
    ui->FileName->setText(fileName);
}


void MainWindow::on_download_clicked() // Загрузить
{
    original = QImage(ui->FileName->text());
    if (original.isNull()) return;
    QGraphicsScene *scene = new QGraphicsScene();
    scene->addPixmap(QPixmap::fromImage(original));
    scene->setSceneRect(0,0,original.width(),original.height());
    ui->imageOutput->setScene(scene);

    copy = original;

    QMap<int, int> Red, Green, Blue;
    for (int i = 0; i < original.width(); i++) {
        for (int j = 0; j < original.height(); j++) {
            QRgb color = original.pixel(i,j);
            Red[qRed(color)]++;
            Green[qGreen(color)]++;
            Blue[qBlue(color)]++;
        }
    }
    for (int i = 0; i < 255; i++) {
        AveRed += i * Red[i];
        AveGreen += i * Green[i];
        AveBlue += i * Blue[i];
    }

    AveRed /= original.width() * original.height();
    AveGreen /= original.width() * original.height();
    AveBlue /= original.width() * original.height();
}

int MainWindow::getBrightness(QRgb rgb) { //Расчитать яркость
    return 0.299*qRed(rgb) + 0.5876*qGreen(rgb) + 0.114*qBlue(rgb);
}

QImage MainWindow::Filter(Matrix F) { //Применение фильтра
    int shift = F.getSize().x() / 2;
    QImage buf(copy.width() + 2 * shift, copy.height() + 2 * shift, copy.format());
    buf.fill(QColor(AveRed, AveGreen, AveBlue)); //Во избежание краевого эффекта создаем рамку со средним цветом
    QPainter dr(&buf);
    dr.drawImage(shift, shift, copy);

    for (int i = shift; i < original.width(); i++) {
        for (int j = shift; j < original.height(); j++) {
            double sumRed = 0, sumGreen = 0, sumBlue = 0;
            for (int k = 0; k < F.getSize().x(); k++) {
                for (int l = 0; l < F.getSize().x(); l++) {
                    sumRed += qRed(buf.pixel(i + k - shift, j + l - shift)) * F[k][l];
                    sumGreen += qGreen(buf.pixel(i + k - shift, j + l - shift)) * F[k][l];
                    sumBlue += qBlue(buf.pixel(i + k - shift, j + l - shift)) * F[k][l];
                }
            }
            copy.setPixelColor(i - shift, j - shift, QColor(sumRed, sumGreen, sumBlue));
            buf.setPixelColor(i, j, QColor(sumRed, sumGreen, sumBlue));
        }
    }
    return copy;
}


void MainWindow::on_NotNoiseButton_clicked() //Удалить шум
{
    copy = original;
    ui->imageOutput->scene()->addPixmap(QPixmap::fromImage(copy));
}


void MainWindow::on_NoiseButton_clicked() //Добавить шум
{
    QRandomGenerator gen(QTime::currentTime().msec());
    for (int i = 0; i < original.width(); i++) {
        for (int j = 0; j < original.height(); j++) {
            double x = gen.generateDouble(), s = gen.generateDouble();
            while (s == 0) s = gen.generateDouble();
            double z = x * qSqrt(-2 * qLn(s) / s);
            QRgb color = copy.pixel(i,j);
            int R = qRed(color), G = qGreen(color), B = qBlue(color);
            R = qMin(qMax(0., R + z), 255.);
            G = qMin(qMax(0., G + z), 255.);
            B = qMin(qMax(0., B + z), 255.);
            copy.setPixelColor(i,j,QColor(R,G,B));
        }
    }
    ui->imageOutput->scene()->addPixmap(QPixmap::fromImage(copy));
}


void MainWindow::on_GaussButton_clicked() //Создание матрицы Гаусса и применение
{
    Matrix F({ui->spinBox->value(),ui->spinBox->value()});
    double sigma = ui->doubleSpinBox->value();
    int center = ui->spinBox->value() / 2; // Центральная позиция шаблона, которая является источником координат
    double x2, y2, sum = 0;
    for (int i = 0; i < ui->spinBox->value(); i++) {
        x2 = pow(i - center, 2);
        for (int j = 0; j < ui->spinBox->value(); j++) {
            y2 = pow(j - center, 2);
            double g = qExp(-(x2 + y2) / (2 * sigma * sigma)); //Гаусианна
            g /= 2 * M_PI * sigma;
            F[i][j] = g;
            sum += g;
        }
    }
    for (int i = 0; i < ui->spinBox->value(); i++) {
        for (int j = 0; j < ui->spinBox->value(); j++) {
            F[i][j] /= sum;
        }
    }
    ui->imageOutput->scene()->addPixmap(QPixmap::fromImage(Filter(F)));
}


void MainWindow::on_MedianButton_clicked() //Медианный фильтр
{
    int shift = ui->spinBox_2->value() / 2;
    QImage buf(copy.width() + 2 * shift, copy.height() + 2 * shift, copy.format());
    buf.fill(QColor(AveRed, AveGreen, AveBlue));
    QPainter dr(&buf);
    dr.drawImage(shift, shift, copy);

    for (int i = shift; i < original.width(); i++) {
        for (int j = shift; j < original.height(); j++) {
            QVector<int> ListR, ListG, ListB;
            for (int k = 0; k <  ui->spinBox_2->value(); k++) {
                for (int l = 0; l <  ui->spinBox_2->value(); l++) {
                    ListR.push_back(qRed(buf.pixel(i + k - shift, j + l - shift)));
                    ListG.push_back(qGreen(buf.pixel(i + k - shift, j + l - shift)));
                    ListB.push_back(qBlue(buf.pixel(i + k - shift, j + l - shift)));
                }
            }
            std::sort(ListR.begin(), ListR.end());
            std::sort(ListG.begin(), ListG.end());
            std::sort(ListB.begin(), ListB.end());
            copy.setPixelColor(i - shift, j - shift, QColor(ListR[ListR.size()/2], ListG[ListG.size()/2], ListB[ListB.size()/2]));
            buf.setPixelColor(i, j, QColor(ListR[ListR.size()/2], ListG[ListG.size()/2], ListB[ListB.size()/2]));
        }
    }
    ui->imageOutput->scene()->addPixmap(QPixmap::fromImage(copy));
}


void MainWindow::on_GaussButton_3_clicked() //Создание матрицы резкости и применение
{
    Matrix F({ui->spinBox_5->value(), ui->spinBox_5->value()});
    for (int k = 0; k <  ui->spinBox_5->value(); k++) {
        for (int l = 0; l <  ui->spinBox_5->value(); l++) {
            F[k][l] = -ui->doubleSpinBox_3->value() / (ui->spinBox_5->value() * ui->spinBox_5->value() - 1);
        }
    }
    F[ui->spinBox_5->value()/2][ui->spinBox_5->value()/2] = 1 + ui->doubleSpinBox_3->value();
    ui->imageOutput->scene()->addPixmap(QPixmap::fromImage(Filter(F)));
}


void MainWindow::on_ContButton_clicked()
{}

void MainWindow::on_GaussButton_4_clicked() // Оконтование
{
    int n = ui->spinBox_4->value();
    int shift = n/2;
    Matrix Gx({n,n}), Gy({n,n});
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            double I = i - shift, J = j - shift;
            if (I != 0) Gx[i][j] = I / (I*I + J*J);
            if (J != 0) Gy[i][j] = J / (I*I + J*J);
        }
    }

    QImage buf(copy.width() + 2 * shift, copy.height() + 2 * shift, copy.format());
    buf.fill(QColor(AveRed, AveGreen, AveBlue));
    QPainter dr(&buf);
    dr.drawImage(shift, shift, copy);

    int minG = 255, maxG = 255;

    for (int i = shift; i < original.width(); i++) {
        for (int j = shift; j < original.height(); j++) {
            double sumGx = 0, sumGy = 0;
            for (int k = 0; k <  n; k++) {
                for (int l = 0; l <  n; l++) {
                    sumGx += getBrightness(buf.pixel(i + k - shift, j + l - shift)) * Gx[k][l];
                    sumGy += getBrightness(buf.pixel(i + k - shift, j + l - shift)) * Gy[k][l];
                }
            }
            int G = qSqrt(sumGx * sumGx + sumGy * sumGy);
            minG = qMin(minG, G);
            maxG = qMax(maxG, G);
            if (G > ui->spinBox_3->value()) {
                copy.setPixelColor(i - shift, j - shift, QColor(255,255,255));
                //buf.setPixelColor(i, j, QColor(255,255,255));
            } else {
                copy.setPixelColor(i - shift, j - shift, QColor(0,0,0));
                //buf.setPixelColor(i, j, QColor(0,0,0));
            }
        }
    }

    ui->imageOutput->scene()->addPixmap(QPixmap::fromImage(copy));
    //ui->imageOutput->scene()->addPixmap(QPixmap::fromImage(buf.copy(shift,shift,copy.width(),copy.height())));

}




