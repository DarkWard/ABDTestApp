namespace ABDTestApp
{
    partial class MainForm
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
            SearchButton = new Button();
            KillBackgroundAppsButton = new Button();
            SearchInput = new TextBox();
            Search = new Button();
            ResponsesList = new ListBox();
            SuspendLayout();
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(250, 50);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(150, 150);
            SearchButton.TabIndex = 1;
            SearchButton.Text = "Open Chrome";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += OpenChromeButton_Click;
            // 
            // KillBackgroundAppsButton
            // 
            KillBackgroundAppsButton.Location = new Point(50, 50);
            KillBackgroundAppsButton.Name = "KillBackgroundAppsButton";
            KillBackgroundAppsButton.Size = new Size(150, 150);
            KillBackgroundAppsButton.TabIndex = 2;
            KillBackgroundAppsButton.Text = "Kill Apps";
            KillBackgroundAppsButton.UseVisualStyleBackColor = true;
            KillBackgroundAppsButton.Click += KillBackgroundAppsButton_Click;
            // 
            // SearchInput
            // 
            SearchInput.Location = new Point(50, 224);
            SearchInput.Name = "SearchInput";
            SearchInput.Size = new Size(350, 23);
            SearchInput.TabIndex = 3;
            SearchInput.TextChanged += SearchInput_TextChanged;
            // 
            // Search
            // 
            Search.Location = new Point(178, 274);
            Search.Name = "Search";
            Search.Size = new Size(90, 46);
            Search.TabIndex = 4;
            Search.Text = "Search";
            Search.UseVisualStyleBackColor = true;
            Search.Click += SearchButton_Click;
            // 
            // ResponsesList
            // 
            ResponsesList.FormattingEnabled = true;
            ResponsesList.ItemHeight = 15;
            ResponsesList.Location = new Point(50, 349);
            ResponsesList.Name = "ResponsesList";
            ResponsesList.Size = new Size(350, 124);
            ResponsesList.TabIndex = 5;
            ResponsesList.SelectedIndexChanged += ResponsesList_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 493);
            Controls.Add(ResponsesList);
            Controls.Add(Search);
            Controls.Add(SearchInput);
            Controls.Add(KillBackgroundAppsButton);
            Controls.Add(SearchButton);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SearchButton;
        private Button KillBackgroundAppsButton;
        private TextBox SearchInput;
        private Button Search;
        private ListBox ResponsesList;
    }
}