using System.Runtime.InteropServices;

namespace PowerWin
{
    internal class ChangeMouseAcceleration
    {
        private const uint SPI_GETMOUSE = 0x0003;
        private const uint SPI_SETMOUSE = 0x0004;
        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDCHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SystemParametersInfo(
            uint uiAction,
            uint uiParam,
            int[] pvParam,
            uint fWinIni
        );

        public static void SetMouseAcceleration(bool enable)
        {
            try
            {
                // Получить текущие настройки мыши
                int[] mouseParams = new int[3];
                if (!SystemParametersInfo(SPI_GETMOUSE, 0, mouseParams, 0))
                {
                    Console.WriteLine("Не удалось получить текущие настройки мыши.");
                    return;
                }

                // Установить параметры в зависимости от переданного значения enable
                mouseParams[0] = 0; // Speed
                mouseParams[1] = 0; // Threshold1
                mouseParams[2] = enable ? 10 : 0; // Threshold2 (включить или выключить акселерацию)

                // Применить изменения
                if (
                    !SystemParametersInfo(
                        SPI_SETMOUSE,
                        0,
                        mouseParams,
                        SPIF_UPDATEINIFILE | SPIF_SENDCHANGE
                    )
                )
                {
                    Console.WriteLine("Не удалось применить изменения ускорения мыши.");
                }
                else
                {
                    Console.WriteLine($"Ускорение мыши {(enable ? "включено" : "выключено")}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при переключении ускорения мыши: {ex.Message}");
            }
        }
    }
}
