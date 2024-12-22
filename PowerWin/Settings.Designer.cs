namespace PowerWin
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            resolutionCombobox = new ComboBox();
            tabControl = new TabControl();
            generalSettingsTab = new TabPage();
            generalSettingsRecommendedButton = new Button();
            windowsDarkThemeCheckbox = new CheckBox();
            disableMouseAccelCheckbox = new CheckBox();
            generalSettingsApplyButton = new Button();
            resolutionHotkeyTab = new TabPage();
            resolutionHotkeyApplyButton = new Button();
            frequencyCombobox = new ComboBox();
            tabControl.SuspendLayout();
            generalSettingsTab.SuspendLayout();
            resolutionHotkeyTab.SuspendLayout();
            SuspendLayout();
            // 
            // resolutionCombobox
            // 
            resolutionCombobox.FormattingEnabled = true;
            resolutionCombobox.Location = new Point(6, 6);
            resolutionCombobox.Name = "resolutionCombobox";
            resolutionCombobox.Size = new Size(121, 23);
            resolutionCombobox.TabIndex = 2;
            resolutionCombobox.Text = "Resolution";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(generalSettingsTab);
            tabControl.Controls.Add(resolutionHotkeyTab);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(730, 513);
            tabControl.TabIndex = 4;
            // 
            // generalSettingsTab
            // 
            generalSettingsTab.BackColor = Color.White;
            generalSettingsTab.Controls.Add(generalSettingsRecommendedButton);
            generalSettingsTab.Controls.Add(windowsDarkThemeCheckbox);
            generalSettingsTab.Controls.Add(disableMouseAccelCheckbox);
            generalSettingsTab.Controls.Add(generalSettingsApplyButton);
            generalSettingsTab.Location = new Point(4, 24);
            generalSettingsTab.Name = "generalSettingsTab";
            generalSettingsTab.Padding = new Padding(3);
            generalSettingsTab.Size = new Size(722, 485);
            generalSettingsTab.TabIndex = 0;
            generalSettingsTab.Text = "General settings";
            // 
            // generalSettingsRecommendedButton
            // 
            generalSettingsRecommendedButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            generalSettingsRecommendedButton.Location = new Point(8, 454);
            generalSettingsRecommendedButton.Name = "generalSettingsRecommendedButton";
            generalSettingsRecommendedButton.Size = new Size(155, 23);
            generalSettingsRecommendedButton.TabIndex = 8;
            generalSettingsRecommendedButton.Text = "Recommended settings";
            generalSettingsRecommendedButton.UseVisualStyleBackColor = true;
            generalSettingsRecommendedButton.Click += Recommended_Button_Click;
            // 
            // windowsDarkThemeCheckbox
            // 
            windowsDarkThemeCheckbox.AutoSize = true;
            windowsDarkThemeCheckbox.Location = new Point(6, 31);
            windowsDarkThemeCheckbox.Name = "windowsDarkThemeCheckbox";
            windowsDarkThemeCheckbox.Size = new Size(138, 19);
            windowsDarkThemeCheckbox.TabIndex = 7;
            windowsDarkThemeCheckbox.Text = "Windows dark theme";
            windowsDarkThemeCheckbox.UseVisualStyleBackColor = true;
            // 
            // disableMouseAccelCheckbox
            // 
            disableMouseAccelCheckbox.AutoSize = true;
            disableMouseAccelCheckbox.Location = new Point(6, 6);
            disableMouseAccelCheckbox.Name = "disableMouseAccelCheckbox";
            disableMouseAccelCheckbox.Size = new Size(133, 19);
            disableMouseAccelCheckbox.TabIndex = 6;
            disableMouseAccelCheckbox.Text = "Disable mouse accel";
            disableMouseAccelCheckbox.UseMnemonic = false;
            disableMouseAccelCheckbox.UseVisualStyleBackColor = true;
            // 
            // generalSettingsApplyButton
            // 
            generalSettingsApplyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            generalSettingsApplyButton.Cursor = Cursors.Hand;
            generalSettingsApplyButton.Location = new Point(639, 454);
            generalSettingsApplyButton.Name = "generalSettingsApplyButton";
            generalSettingsApplyButton.Size = new Size(75, 23);
            generalSettingsApplyButton.TabIndex = 5;
            generalSettingsApplyButton.Text = "Apply";
            generalSettingsApplyButton.UseVisualStyleBackColor = true;
            generalSettingsApplyButton.Click += GeneralSettings_Apply_Button_Click;
            // 
            // resolutionHotkeyTab
            // 
            resolutionHotkeyTab.Controls.Add(resolutionHotkeyApplyButton);
            resolutionHotkeyTab.Controls.Add(frequencyCombobox);
            resolutionHotkeyTab.Controls.Add(resolutionCombobox);
            resolutionHotkeyTab.Location = new Point(4, 24);
            resolutionHotkeyTab.Name = "resolutionHotkeyTab";
            resolutionHotkeyTab.Padding = new Padding(3);
            resolutionHotkeyTab.Size = new Size(722, 485);
            resolutionHotkeyTab.TabIndex = 1;
            resolutionHotkeyTab.Text = "Resolution Hotkeys";
            resolutionHotkeyTab.UseVisualStyleBackColor = true;
            // 
            // resolutionHotkeyApplyButton
            // 
            resolutionHotkeyApplyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            resolutionHotkeyApplyButton.Location = new Point(639, 454);
            resolutionHotkeyApplyButton.Name = "resolutionHotkeyApplyButton";
            resolutionHotkeyApplyButton.Size = new Size(75, 23);
            resolutionHotkeyApplyButton.TabIndex = 4;
            resolutionHotkeyApplyButton.Text = "Apply";
            resolutionHotkeyApplyButton.UseVisualStyleBackColor = true;
            resolutionHotkeyApplyButton.Click += ResolutionHotkey_Apply_Button_Click;
            // 
            // frequencyCombobox
            // 
            frequencyCombobox.FormattingEnabled = true;
            frequencyCombobox.Location = new Point(133, 6);
            frequencyCombobox.Name = "frequencyCombobox";
            frequencyCombobox.Size = new Size(121, 23);
            frequencyCombobox.TabIndex = 3;
            frequencyCombobox.Text = "Frequency";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 513);
            Controls.Add(tabControl);
            Name = "Settings";
            Text = "Settings";
            tabControl.ResumeLayout(false);
            generalSettingsTab.ResumeLayout(false);
            generalSettingsTab.PerformLayout();
            resolutionHotkeyTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ComboBox resolutionCombobox;
        private TabControl tabControl;
        private TabPage generalSettingsTab;
        private TabPage resolutionHotkeyTab;
        private Button generalSettingsApplyButton;
        private CheckBox windowsDarkThemeCheckbox;
        private CheckBox disableMouseAccelCheckbox;
        private Button generalSettingsRecommendedButton;
        private ComboBox frequencyCombobox;
        private Button resolutionHotkeyApplyButton;
    }
}