namespace PowerWin
{
    public partial class Settings : Form
    {
        private int groupBoxCounter = 1;
        private readonly Config _config;
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;

        public Settings()
        {
            InitializeComponent();
            _config = ConfigManager.LoadConfig();
            InitializeHotkeys();
            InitializeTray();
        }

        private void InitializeTray()
        {
            // Создание контекстного меню
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Close", null, OnTrayClose);

            string iconPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\favicon.ico"
            );

            trayIcon = new NotifyIcon
            {
                Text = "PowerWin",
                Icon = new Icon(iconPath),
                ContextMenuStrip = trayMenu,
                Visible = true,
            };

            trayIcon.DoubleClick += OnTrayDoubleClick;
        }

        private void OnTrayClose(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void OnTrayDoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            base.OnFormClosing(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void InitializeHotkeys()
        {
            var hotkeyManager = new HotkeyManager();

            foreach (var hotkey in _config.ResolutionHotkeys)
            {
                AddResolutionHotkeyGroupBox(hotkey);

                hotkeyManager.RegisterHotkey(
                    hotkey.Hotkey,
                    () =>
                        ChangeResolution.SetResolution(
                            hotkey.Width,
                            hotkey.Height,
                            hotkey.RefreshRate
                        )
                );
            }
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

        private void AddResolutionHotkeyGroupBox(ResolutionHotkey? hotkey = null)
        {
            int padding = 10;
            int spacingBetweenElements = 10;

            var newGroupBox = new GroupBox { Text = $"Resolution {groupBoxCounter++}" };

            var resolutionComboBox = new ComboBox
            {
                Font = new Font("Arial", 14F),
                FormattingEnabled = true,
                ItemHeight = 22,
                Location = new Point(padding, padding + 7),
                Name = $"resolutionComboBox_{groupBoxCounter}",
                Size = new Size(210, 30),
                Text =
                    (hotkey != null && hotkey.Width > 0 && hotkey.Height > 0)
                        ? $"{hotkey.Width} x {hotkey.Height}"
                        : "Resolution",
            };

            var refreshRateComboBox = new ComboBox
            {
                Font = new Font("Arial", 8F),
                FormattingEnabled = true,
                Location = new Point(padding, resolutionComboBox.Bottom + spacingBetweenElements),
                Name = $"refreshRateComboBox_{groupBoxCounter}",
                Size = new Size(100, 22),
                Text =
                    (hotkey != null && hotkey.RefreshRate > 0)
                        ? $"{hotkey?.RefreshRate}"
                        : "Refresh Rate",
            };

            var hotkeyTextBox = new TextBox
            {
                Location = new Point(
                    refreshRateComboBox.Right + spacingBetweenElements,
                    refreshRateComboBox.Top
                ),
                Name = $"hotkeyTextBox_{groupBoxCounter}",
                Size = new Size(100, 23),
                Text = hotkey?.Hotkey != null ? string.Join(" + ", hotkey.Hotkey) : "Hotkey",
            };

            hotkeyTextBox.KeyDown += (sender, e) =>
            {
                if (sender is TextBox textBox)
                {
                    var keys = new List<string>();

                    if (e.Control)
                        keys.Add("Ctrl");
                    if (e.Alt)
                        keys.Add("Alt");
                    if (e.Shift)
                        keys.Add("Shift");

                    keys.Add(e.KeyCode.ToString());

                    textBox.Text = string.Join(" + ", keys);
                    e.SuppressKeyPress = true;

                    if (hotkey != null)
                    {
                        hotkey.Hotkey = [.. keys];
                    }
                }
            };

            ResolutionList.SetDisplayResolutions(resolutionComboBox, refreshRateComboBox);

            var deleteButton = new Button
            {
                Text = "Delete",
                Location = new Point(
                    padding,
                    hotkeyTextBox.Top + hotkeyTextBox.Height + spacingBetweenElements
                ),
                Size = new Size(60, 25),
            };

            deleteButton.Click += (sender, e) =>
            {
                ResolutionHotkeysPanel.Controls.Remove(newGroupBox);
            };

            newGroupBox.Controls.Add(resolutionComboBox);
            newGroupBox.Controls.Add(refreshRateComboBox);
            newGroupBox.Controls.Add(hotkeyTextBox);
            newGroupBox.Controls.Add(deleteButton);

            int groupBoxWidth = Math.Max(resolutionComboBox.Right, hotkeyTextBox.Right) + padding;
            int groupBoxHeight =
                hotkeyTextBox.Bottom + deleteButton.Height + padding + spacingBetweenElements;

            newGroupBox.Size = new Size(groupBoxWidth, groupBoxHeight);

            ResolutionHotkeysPanel.Controls.Add(newGroupBox);
        }

        private void AddHotkeyButton_Click(object sender, EventArgs e)
        {
            AddResolutionHotkeyGroupBox();
        }

        private void ResolutionHotkey_Apply_Button_Click(object sender, EventArgs e)
        {
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
                        (int width, int height, bool success) = ResolutionList.ResolutionToKey(
                            resolutionComboBox.Text
                        );

                        if (success && int.TryParse(refreshRateComboBox.Text, out int refreshRate))
                        {
                            _config.ResolutionHotkeys.Add(
                                new ResolutionHotkey
                                {
                                    Width = width,
                                    Height = height,
                                    RefreshRate = refreshRate,
                                    Hotkey = hotkeyTextBox.Text.Split(
                                        [" + "],
                                        StringSplitOptions.RemoveEmptyEntries
                                    ),
                                }
                            );
                        }
                    }
                }
            }

            ConfigManager.SaveConfig(_config);
        }
    }
}
