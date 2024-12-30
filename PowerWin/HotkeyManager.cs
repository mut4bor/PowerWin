using System.Runtime.InteropServices;

namespace PowerWin
{
    internal class HotkeyManager
    {
        private const int MOD_CONTROL = 0x0002;
        private const int MOD_ALT = 0x0001;
        private const int MOD_SHIFT = 0x0004;

        [DllImport("user32.dll")]
        public static extern int RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern int UnregisterHotKey(IntPtr hWnd, int id);

        private int hotkeyIdCounter = 1;
        private readonly HashSet<int> registeredHotkeys = [];

        public HotkeyManager()
        {
            Application.AddMessageFilter(new HotkeyMessageFilter());
        }

        public void RegisterHotkey(string[] hotkeyCombinations, Action callback)
        {
            uint modifiers = 0;
            uint key = 0;

            foreach (var keyPart in hotkeyCombinations)
            {
                switch (keyPart.Trim().ToUpper())
                {
                    case "CTRL":
                        modifiers |= MOD_CONTROL;
                        break;
                    case "ALT":
                        modifiers |= MOD_ALT;
                        break;
                    case "SHIFT":
                        modifiers |= MOD_SHIFT;
                        break;
                    default:
                        if (Enum.TryParse(keyPart.Trim().ToUpper(), out Keys parsedKey))
                        {
                            key = Convert.ToUInt32(parsedKey);
                        }
                        else
                        {
                            MessageBox.Show("Error parsing resolution hotkeys");
                        }
                        break;
                }
            }

            if (RegisterHotKey(IntPtr.Zero, hotkeyIdCounter, modifiers, key) != 0)
            {
                registeredHotkeys.Add(hotkeyIdCounter);
                HotkeyMessageFilter.AddHotkeyCallback(hotkeyIdCounter++, callback);
            }
            else
            {
                throw new InvalidOperationException("Failed to register hotkey.");
            }
        }

        public void UnregisterAllHotkeys()
        {
            foreach (var id in registeredHotkeys)
            {
                UnregisterHotKey(IntPtr.Zero, id);
            }
            registeredHotkeys.Clear();
        }
    }

    internal class HotkeyMessageFilter : IMessageFilter
    {
        private static readonly Dictionary<int, Action> hotkeyCallbacks = [];

        public static void AddHotkeyCallback(int hotkeyId, Action callback)
        {
            hotkeyCallbacks[hotkeyId] = callback;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x0312) // WM_HOTKEY
            {
                int hotkeyId = m.WParam.ToInt32();
                if (hotkeyCallbacks.TryGetValue(hotkeyId, out var callback))
                {
                    callback.Invoke();
                }
            }

            return false;
        }
    }
}
