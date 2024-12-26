namespace PowerWin
{
    public partial class Settings : Form
    {
        private int groupBoxCounter = 1;
        private Config _config;
        private HotkeyManager _hotkeyManager;

        public Settings()
        {
            InitializeComponent();
            _config = ConfigManager.LoadConfig();
            InitializeHotkeys();
        }

        private void InitializeHotkeys()
        {
            _hotkeyManager = new HotkeyManager();

            foreach (var hotkey in _config.ResolutionHotkeys)
            {
                AddResolutionHotkeyGroupBox(hotkey); // Это, скорее всего, добавляет элементы UI для отображения

                // Регистрируем горячую клавишу с соответствующим действием
                _hotkeyManager.RegisterHotkey(
                    hotkey.Hotkey,
                    () =>
                    {
                        // Парсим разрешение и частоту обновления
                        var resolutionParts = hotkey.Resolution.Split('x');
                        int width = int.Parse(resolutionParts[0].Trim());
                        int height = int.Parse(resolutionParts[1].Trim());
                        int refreshRate = int.Parse(hotkey.RefreshRate);

                        // Изменяем разрешение экрана
                        ChangeResolution.SetResolution(width, height, refreshRate);
                    }
                );
            }

            // Запускаем прослушивание горячих клавиш
            _hotkeyManager.Start();
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

        private void TextBoxHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string hotkey = "";

                if (e.Control)
                    hotkey += "Ctrl + ";
                if (e.Alt)
                    hotkey += "Alt + ";
                if (e.Shift)
                    hotkey += "Shift + ";

                hotkey += e.KeyCode;

                textBox.Text = hotkey;
                e.SuppressKeyPress = true;
            }
        }

        private void AddResolutionHotkeyGroupBox(ResolutionHotkey hotkey = null)
        {
            int padding = 10;
            int spacingBetweenElements = 10;

            GroupBox newGroupBox = new GroupBox { Text = $"Resolution {groupBoxCounter++}" };

            ComboBox resolutionComboBox = new ComboBox
            {
                Font = new Font("Arial", 14F),
                FormattingEnabled = true,
                ItemHeight = 22,
                Location = new Point(padding, padding + 7),
                Name = $"resolutionComboBox_{groupBoxCounter}",
                Size = new Size(210, 30),
                Text = hotkey?.Resolution ?? "Resolution",
            };

            ComboBox refreshRateComboBox = new ComboBox
            {
                Font = new Font("Arial", 8F),
                FormattingEnabled = true,
                Location = new Point(padding, resolutionComboBox.Bottom + spacingBetweenElements),
                Name = $"refreshRateComboBox_{groupBoxCounter}",
                Size = new Size(100, 22),
                Text = hotkey?.RefreshRate ?? "Refresh Rate",
            };

            TextBox hotkeyTextBox = new TextBox
            {
                Location = new Point(
                    refreshRateComboBox.Right + spacingBetweenElements,
                    refreshRateComboBox.Top
                ),
                Name = $"hotkeyTextBox_{groupBoxCounter}",
                Size = new Size(100, 23),
                Text = hotkey?.Hotkey ?? "Hotkey",
            };

            hotkeyTextBox.KeyDown += (sender, e) =>
            {
                if (sender is TextBox textBox)
                {
                    string key = "";

                    if (e.Control)
                        key += "Ctrl + ";
                    if (e.Alt)
                        key += "Alt + ";
                    if (e.Shift)
                        key += "Shift + ";

                    key += e.KeyCode;

                    textBox.Text = key;
                    e.SuppressKeyPress = true;

                    if (hotkey != null)
                        hotkey.Hotkey = key;
                }
            };

            ResolutionList.SetDisplayResolutions(resolutionComboBox, refreshRateComboBox);

            // Кнопка удаления
            Button deleteButton = new Button
            {
                Text = "Delete",
                Location = new Point(
                    padding,
                    hotkeyTextBox.Top + hotkeyTextBox.Height + spacingBetweenElements
                ), // позиция в правом нижнем углу
                Size = new Size(60, 25),
            };

            deleteButton.Click += (sender, e) =>
            {
                ResolutionHotkeysPanel.Controls.Remove(newGroupBox);
            };

            newGroupBox.Controls.Add(resolutionComboBox);
            newGroupBox.Controls.Add(refreshRateComboBox);
            newGroupBox.Controls.Add(hotkeyTextBox);
            newGroupBox.Controls.Add(deleteButton); // добавление кнопки в GroupBox

            int groupBoxWidth = Math.Max(resolutionComboBox.Right, hotkeyTextBox.Right) + padding;
            int groupBoxHeight =
                hotkeyTextBox.Bottom + deleteButton.Height + padding + spacingBetweenElements; // учёт кнопки удаления

            newGroupBox.Size = new Size(groupBoxWidth, groupBoxHeight);

            ResolutionHotkeysPanel.Controls.Add(newGroupBox);
        }

        private void AddHotkeyButton_Click(object sender, EventArgs e)
        {
            AddResolutionHotkeyGroupBox();
        }

        private void resolutionHotkey_Apply_Button_Click(object sender, EventArgs e)
        {
            // Сохранение текущих настроек хоткеев
            _config.ResolutionHotkeys.Clear();
            foreach (Control control in ResolutionHotkeysPanel.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    var resolutionComboBox = groupBox
                        .Controls.OfType<ComboBox>()
                        .FirstOrDefault(c => c.Name.Contains("resolutionComboBox"));
                    var refreshRateComboBox = groupBox
                        .Controls.OfType<ComboBox>()
                        .FirstOrDefault(c => c.Name.Contains("refreshRateComboBox"));
                    var hotkeyTextBox = groupBox
                        .Controls.OfType<TextBox>()
                        .FirstOrDefault(c => c.Name.Contains("hotkeyTextBox"));

                    if (
                        resolutionComboBox != null
                        && refreshRateComboBox != null
                        && hotkeyTextBox != null
                    )
                    {
                        _config.ResolutionHotkeys.Add(
                            new ResolutionHotkey
                            {
                                Resolution = resolutionComboBox.Text,
                                RefreshRate = refreshRateComboBox.Text,
                                Hotkey = hotkeyTextBox.Text,
                            }
                        );
                    }
                }
            }

            ConfigManager.SaveConfig(_config);
        }
    }
}
