namespace PowerWin
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            ResolutionList.SetDisplayResolutions(resolutionCombobox, frequencyCombobox);
        }

        private void GeneralSettings_Apply_Button_Click(object sender, EventArgs e)
        {
            ChangeMouseAcceleration.SetMouseAcceleration(!disableMouseAccelCheckbox.Checked);

            ChangeWindowsTheme.SetWindowsTheme(windowsDarkThemeCheckbox.Checked);
        }

        private void Recommended_Button_Click(object sender, EventArgs e)
        {
            disableMouseAccelCheckbox.Checked = true;
            windowsDarkThemeCheckbox.Checked = true;
        }

        private void ResolutionHotkey_Apply_Button_Click(object sender, EventArgs e)
        {
            string? selectedResolution = resolutionCombobox.SelectedItem?.ToString();
            string? selectedRefreshRate = frequencyCombobox.SelectedItem?.ToString();

            if (selectedResolution == null)
            {
                MessageBox.Show("Choose resolution");
                return;
            }

            if (selectedRefreshRate == null)
            {
                MessageBox.Show("Choose refresh rate");
                return;
            }

            (int width, int height, bool success) = ResolutionList.ResolutionToKey(
                selectedResolution
            );

            bool refreshRateParsedSuccessfully = int.TryParse(
                selectedRefreshRate,
                out int refreshRate
            );

            if (!success)
            {
                MessageBox.Show($"Произошла ошибка в обработке разрешения: {selectedResolution}");
                return;
            }

            if (!refreshRateParsedSuccessfully)
            {
                MessageBox.Show($"Произошла ошибка в обработке герцовки: {selectedRefreshRate}");
                return;
            }

            ChangeResolution.SetResolution(width, height, refreshRate);
        }
    }
}
