using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace PowerWin
{
    internal class ChangeWindowsTheme
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            uint Msg,
            IntPtr wParam,
            string lParam
        );

        public static void SetWindowsTheme(bool enable)
        {
            // Путь к ключу реестра
            const string keyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            try
            {
                using RegistryKey? key = Registry.CurrentUser.OpenSubKey(keyPath, writable: true);
                if (key == null)
                {
                    Console.WriteLine("Не удалось найти ключ реестра.");
                    return;
                }

                // Установить тему для приложений
                key.SetValue("AppsUseLightTheme", enable ? 0 : 1, RegistryValueKind.DWord);

                // Установить тему для системы (панель задач, меню Пуск и т.д.)
                key.SetValue("SystemUsesLightTheme", enable ? 0 : 1, RegistryValueKind.DWord);

                Console.WriteLine($"Тема изменена на {(enable ? "тёмную" : "светлую")}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при изменении темы: {ex.Message}");
            }
        }
    }
}
