using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PowerWin
{
    internal class HotkeyManager
    {
        private Dictionary<string, Action> _hotkeys;

        // WinAPI константы
        private const int MOD_CTRL = 0x0002;
        private const int MOD_ALT = 0x0001;
        private const int MOD_SHIFT = 0x0004;
        private const int MOD_WIN = 0x0008;

        [DllImport("user32.dll")]
        public static extern int RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern int UnregisterHotKey(IntPtr hWnd, int id);

        public HotkeyManager()
        {
            _hotkeys = new Dictionary<string, Action>();
        }

        // Регистрация горячих клавиш
        public void RegisterHotkey(string hotkey, Action action)
        {
            _hotkeys[hotkey] = action;
        }

        // Разбор строки горячей клавиши и преобразование в коды
        private (uint modifiers, uint keyCode) ParseHotkeyString(string hotkey)
        {
            uint modifiers = 0;
            uint keyCode = 0;

            // Разбираем строку на компоненты (например, "Ctrl + Alt + D5")
            var parts = hotkey.Split(new[] { " + " }, StringSplitOptions.None);

            foreach (var part in parts)
            {
                if (part.Contains("Ctrl"))
                {
                    modifiers |= MOD_CTRL;
                }
                else if (part.Contains("Alt"))
                {
                    modifiers |= MOD_ALT;
                }
                else if (part.Contains("Shift"))
                {
                    modifiers |= MOD_SHIFT;
                }
                else if (part.Contains("Win"))
                {
                    modifiers |= MOD_WIN;
                }
                else
                {
                    keyCode = ConvertKeyToKeyCode(part);
                }
            }

            return (modifiers, keyCode);
        }

        // Преобразование символа клавиши в код (например, D5 -> VK_D5)
        private uint ConvertKeyToKeyCode(string key)
        {
            switch (key.Trim())
            {
                case "D5":
                    return (uint)Keys.D5;
                case "D6":
                    return (uint)Keys.D6;
                // Добавьте другие клавиши по мере необходимости
                default:
                    throw new ArgumentException($"Unsupported key: {key}");
            }
        }

        // Метод для запуска прослушивания горячих клавиш
        public void Start()
        {
            foreach (var hotkey in _hotkeys)
            {
                var (modifiers, keyCode) = ParseHotkeyString(hotkey.Key);
                RegisterHotKey(IntPtr.Zero, hotkey.Key.GetHashCode(), modifiers, keyCode);
            }

            // Запуск цикла прослушивания горячих клавиш
            // ...
        }
    }
}
