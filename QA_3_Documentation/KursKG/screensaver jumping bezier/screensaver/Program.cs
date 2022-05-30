using System;
using System.Windows.Forms;

namespace screensaver
{
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    /// <param name="args"><</param>
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].ToLower().Trim().Substring(0, 2) == "/s")
                {
                    // Отобразить заставку
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    ShowScreenSaver();
                    Application.Run();
                }
                else if (args[0].ToLower().Trim().Substring(0, 2) == "/p")
                {
                    // Предварительный просмотр заставки
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmMain());
                }
                else if (args[0].ToLower().Trim().Substring(0, 2) == "/c")
                {
                    // Отображение окна с настройками заставки
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormConfigure());
                }
            }
            else
            {
                // Отобразить заставку    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ShowScreenSaver();
                Application.Run();
            }
        }

        // Инициализируем скринсейвер
        static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                frmMain screensaver = new frmMain();
                screensaver.Show();
            }
        }
    }
}
