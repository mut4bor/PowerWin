
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
            tabControl = new TabControl();
            generalSettingsTab = new TabPage();
            generalSettingsRecommendedButton = new Button();
            windowsDarkThemeCheckbox = new CheckBox();
            disableMouseAccelCheckbox = new CheckBox();
            generalSettingsApplyButton = new Button();
            resolutionHotkeyTab = new TabPage();
            ResolutionHotkeysPanel = new FlowLayoutPanel();
            bottomButtonsPanel = new FlowLayoutPanel();
            addHotkeyResolutionForm = new Button();
            resolutionHotkeyApplyButton = new Button();
            tabControl.SuspendLayout();
            generalSettingsTab.SuspendLayout();
            resolutionHotkeyTab.SuspendLayout();
            bottomButtonsPanel.SuspendLayout();
            SuspendLayout();
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
            resolutionHotkeyTab.Controls.Add(ResolutionHotkeysPanel);
            resolutionHotkeyTab.Controls.Add(bottomButtonsPanel);
            resolutionHotkeyTab.Location = new Point(4, 24);
            resolutionHotkeyTab.Name = "resolutionHotkeyTab";
            resolutionHotkeyTab.Padding = new Padding(3);
            resolutionHotkeyTab.Size = new Size(722, 485);
            resolutionHotkeyTab.TabIndex = 1;
            resolutionHotkeyTab.Text = "Resolution Hotkeys";
            resolutionHotkeyTab.UseVisualStyleBackColor = true;
            // 
            // ResolutionHotkeysPanel
            // 
            ResolutionHotkeysPanel.Dock = DockStyle.Fill;
            ResolutionHotkeysPanel.Location = new Point(3, 3);
            ResolutionHotkeysPanel.Name = "ResolutionHotkeysPanel";
            ResolutionHotkeysPanel.Size = new Size(716, 450);
            ResolutionHotkeysPanel.TabIndex = 12;
            ResolutionHotkeysPanel.AutoScroll = true;
            ResolutionHotkeysPanel.WrapContents = false;
            ResolutionHotkeysPanel.FlowDirection = FlowDirection.TopDown;
            // 
            // bottomButtonsPanel
            // 
            bottomButtonsPanel.AutoSize = true;
            bottomButtonsPanel.Controls.Add(addHotkeyResolutionForm);
            bottomButtonsPanel.Controls.Add(resolutionHotkeyApplyButton);
            bottomButtonsPanel.Dock = DockStyle.Bottom;
            bottomButtonsPanel.Location = new Point(3, 453);
            bottomButtonsPanel.Name = "bottomButtonsPanel";
            bottomButtonsPanel.Size = new Size(716, 29);
            bottomButtonsPanel.TabIndex = 11;
            // 
            // addHotkeyResolutionForm
            // 
            addHotkeyResolutionForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addHotkeyResolutionForm.Location = new Point(3, 3);
            addHotkeyResolutionForm.Name = "addHotkeyResolutionForm";
            addHotkeyResolutionForm.Size = new Size(72, 23);
            addHotkeyResolutionForm.TabIndex = 9;
            addHotkeyResolutionForm.Text = "+";
            addHotkeyResolutionForm.UseVisualStyleBackColor = true;
            addHotkeyResolutionForm.Click += AddHotkeyButton_Click;
            // 
            // resolutionHotkeyApplyButton
            // 
            resolutionHotkeyApplyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            resolutionHotkeyApplyButton.Location = new Point(81, 3);
            resolutionHotkeyApplyButton.Name = "resolutionHotkeyApplyButton";
            resolutionHotkeyApplyButton.Size = new Size(75, 23);
            resolutionHotkeyApplyButton.TabIndex = 4;
            resolutionHotkeyApplyButton.Text = "Apply";
            resolutionHotkeyApplyButton.UseVisualStyleBackColor = true;
            resolutionHotkeyApplyButton.Click += ResolutionHotkey_Apply_Button_Click;
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
            resolutionHotkeyTab.PerformLayout();
            bottomButtonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl;
        private TabPage generalSettingsTab;
        private Button generalSettingsApplyButton;
        private CheckBox windowsDarkThemeCheckbox;
        private CheckBox disableMouseAccelCheckbox;
        private Button generalSettingsRecommendedButton;
        private TabPage resolutionHotkeyTab;
        private Button addHotkeyResolutionForm;
        private Button resolutionHotkeyApplyButton;
        private FlowLayoutPanel bottomButtonsPanel;
        private FlowLayoutPanel ResolutionHotkeysPanel;
    }
}