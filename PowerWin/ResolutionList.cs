using System.Runtime.InteropServices;

namespace PowerWin
{
    internal class ResolutionList
    {
        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(
            string? deviceName,
            int modeNum,
            ref DEVMODE devMode
        );

        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        public static void SetDisplayResolutions(
            ComboBox resolutionComboBox,
            ComboBox frequencyComboBox
        )
        {
            var resolutionFrequencies = GetAvailableResolutions();

            PopulateResolutionComboBox(resolutionComboBox, resolutionFrequencies);
            AttachResolutionChangeHandler(
                resolutionComboBox,
                frequencyComboBox,
                resolutionFrequencies
            );
        }

        private static Dictionary<string, List<int>> GetAvailableResolutions()
        {
            var resolutionFrequencies = new Dictionary<string, List<int>>();
            var devMode = new DEVMODE();
            int modeIndex = 0;

            while (EnumDisplaySettings(null, modeIndex, ref devMode))
            {
                string resolution = $"{devMode.dmPelsWidth} x {devMode.dmPelsHeight}";

                if (!resolutionFrequencies.TryGetValue(resolution, out var frequencies))
                {
                    frequencies = [];
                    resolutionFrequencies[resolution] = frequencies;
                }

                if (!frequencies.Contains(devMode.dmDisplayFrequency))
                {
                    frequencies.Add(devMode.dmDisplayFrequency);
                }

                modeIndex++;
            }

            return resolutionFrequencies;
        }

        public static (int Width, int Height, bool Success) ResolutionToKey(string resolution)
        {
            if (string.IsNullOrWhiteSpace(resolution) || !resolution.Contains('x'))
            {
                return (0, 0, false);
            }

            var dimensions = resolution.Split('x');

            if (dimensions.Length != 2)
            {
                return (0, 0, false);
            }

            bool isWidthValid = int.TryParse(dimensions[0], out int width);
            bool isHeightValid = int.TryParse(dimensions[1], out int height);

            if (isWidthValid && isHeightValid)
            {
                return (width, height, true);
            }

            return (0, 0, false);
        }

        private static void PopulateResolutionComboBox(
            ComboBox resolutionComboBox,
            Dictionary<string, List<int>> resolutionFrequencies
        )
        {
            resolutionComboBox.Items.Clear();

            foreach (
                var resolution in resolutionFrequencies.Keys.OrderByDescending(ResolutionToKey)
            )
            {
                resolutionComboBox.Items.Add(resolution);
            }
        }

        private static void AttachResolutionChangeHandler(
            ComboBox resolutionComboBox,
            ComboBox frequencyComboBox,
            Dictionary<string, List<int>> resolutionFrequencies
        )
        {
            resolutionComboBox.SelectedIndexChanged += (sender, e) =>
            {
                frequencyComboBox.Items.Clear();

                if (
                    resolutionComboBox.SelectedItem is string selectedResolution
                    && resolutionFrequencies.TryGetValue(selectedResolution, out var frequencies)
                )
                {
                    foreach (var frequency in frequencies.OrderByDescending(f => f))
                    {
                        frequencyComboBox.Items.Add(frequency);
                    }

                    frequencyComboBox.SelectedItem = frequencies.Max();
                }
            };
        }
    }
}
