#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <matrix.h>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    int getBrightness(QRgb);
    ~MainWindow();

private slots:
    void on_pushButton_7_clicked();

    void on_download_clicked();

    void on_NotNoiseButton_clicked();

    void on_NoiseButton_clicked();

    void on_GaussButton_clicked();

    void on_MedianButton_clicked();

    void on_GaussButton_3_clicked();

    void on_ContButton_clicked();

    void on_GaussButton_4_clicked();

private:
    Ui::MainWindow *ui;

    QImage original, copy;
    int AveRed, AveGreen, AveBlue;
    QImage Filter(Matrix F);
};
#endif // MAINWINDOW_H
