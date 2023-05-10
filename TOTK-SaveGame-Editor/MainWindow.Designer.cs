namespace TOTK_SaveGame_Editor
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.BtnOpenSaveFile = new System.Windows.Forms.Button();
            this.TabControlValues = new System.Windows.Forms.TabControl();
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.InputStamina = new System.Windows.Forms.NumericUpDown();
            this.InputHearts = new System.Windows.Forms.NumericUpDown();
            this.InputRupees = new System.Windows.Forms.NumericUpDown();
            this.LblStamina = new System.Windows.Forms.Label();
            this.LblHearts = new System.Windows.Forms.Label();
            this.LblRupees = new System.Windows.Forms.Label();
            this.TabSwords = new System.Windows.Forms.TabPage();
            this.LblSwordSlot4 = new System.Windows.Forms.Label();
            this.LblSwordSlot3 = new System.Windows.Forms.Label();
            this.ComboSwordSlot4 = new System.Windows.Forms.ComboBox();
            this.ComboSwordSlot3 = new System.Windows.Forms.ComboBox();
            this.ComboSwordSlot2 = new System.Windows.Forms.ComboBox();
            this.ComboSwordSlot1 = new System.Windows.Forms.ComboBox();
            this.ComboSwordSlot0 = new System.Windows.Forms.ComboBox();
            this.LblSwordSlot2 = new System.Windows.Forms.Label();
            this.LblSwordSlot1 = new System.Windows.Forms.Label();
            this.LblSwordSlot0 = new System.Windows.Forms.Label();
            this.TabBows = new System.Windows.Forms.TabPage();
            this.LblBowSlot4 = new System.Windows.Forms.Label();
            this.LblBowSlot3 = new System.Windows.Forms.Label();
            this.ComboBowSlot4 = new System.Windows.Forms.ComboBox();
            this.ComboBowSlot3 = new System.Windows.Forms.ComboBox();
            this.ComboBowSlot2 = new System.Windows.Forms.ComboBox();
            this.ComboBowSlot1 = new System.Windows.Forms.ComboBox();
            this.ComboBowSlot0 = new System.Windows.Forms.ComboBox();
            this.LblBowSlot2 = new System.Windows.Forms.Label();
            this.LblBowSlot1 = new System.Windows.Forms.Label();
            this.LblBowSlot0 = new System.Windows.Forms.Label();
            this.TabShields = new System.Windows.Forms.TabPage();
            this.LblShieldSlot4 = new System.Windows.Forms.Label();
            this.LblShieldSlot3 = new System.Windows.Forms.Label();
            this.ComboShieldSlot4 = new System.Windows.Forms.ComboBox();
            this.ComboShieldSlot3 = new System.Windows.Forms.ComboBox();
            this.ComboShieldSlot2 = new System.Windows.Forms.ComboBox();
            this.ComboShieldSlot1 = new System.Windows.Forms.ComboBox();
            this.ComboShieldSlot0 = new System.Windows.Forms.ComboBox();
            this.LblShieldSlot2 = new System.Windows.Forms.Label();
            this.LblShieldSlot1 = new System.Windows.Forms.Label();
            this.LblShieldSlot0 = new System.Windows.Forms.Label();
            this.TabArmor = new System.Windows.Forms.TabPage();
            this.LblArmorSlot4 = new System.Windows.Forms.Label();
            this.LblArmorSlot3 = new System.Windows.Forms.Label();
            this.ComboArmorSlot4 = new System.Windows.Forms.ComboBox();
            this.ComboArmorSlot3 = new System.Windows.Forms.ComboBox();
            this.ComboArmorSlot2 = new System.Windows.Forms.ComboBox();
            this.ComboArmorSlot1 = new System.Windows.Forms.ComboBox();
            this.ComboArmorSlot0 = new System.Windows.Forms.ComboBox();
            this.LblArmorSlot2 = new System.Windows.Forms.Label();
            this.LblArmorSlot1 = new System.Windows.Forms.Label();
            this.LblArmorSlot0 = new System.Windows.Forms.Label();
            this.BtnPatchSaveFile = new System.Windows.Forms.Button();
            this.LblPath = new System.Windows.Forms.Label();
            this.PanelPath = new System.Windows.Forms.Panel();
            this.BtnReset = new System.Windows.Forms.Button();
            this.LblSwordPouch = new System.Windows.Forms.Label();
            this.InputSwordPouch = new System.Windows.Forms.NumericUpDown();
            this.InputBowPouch = new System.Windows.Forms.NumericUpDown();
            this.LblBowPouch = new System.Windows.Forms.Label();
            this.InputShieldPouch = new System.Windows.Forms.NumericUpDown();
            this.LblShieldPouch = new System.Windows.Forms.Label();
            this.TabControlValues.SuspendLayout();
            this.TabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputStamina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputHearts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputRupees)).BeginInit();
            this.TabSwords.SuspendLayout();
            this.TabBows.SuspendLayout();
            this.TabShields.SuspendLayout();
            this.TabArmor.SuspendLayout();
            this.PanelPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputSwordPouch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputBowPouch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputShieldPouch)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOpenSaveFile
            // 
            this.BtnOpenSaveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOpenSaveFile.Location = new System.Drawing.Point(8, 10);
            this.BtnOpenSaveFile.Name = "BtnOpenSaveFile";
            this.BtnOpenSaveFile.Size = new System.Drawing.Size(90, 30);
            this.BtnOpenSaveFile.TabIndex = 0;
            this.BtnOpenSaveFile.Text = "Open Savefile";
            this.BtnOpenSaveFile.UseVisualStyleBackColor = true;
            this.BtnOpenSaveFile.Click += new System.EventHandler(this.BtnOpenSaveFile_Click);
            // 
            // TabControlValues
            // 
            this.TabControlValues.Controls.Add(this.TabGeneral);
            this.TabControlValues.Controls.Add(this.TabSwords);
            this.TabControlValues.Controls.Add(this.TabBows);
            this.TabControlValues.Controls.Add(this.TabShields);
            this.TabControlValues.Controls.Add(this.TabArmor);
            this.TabControlValues.HotTrack = true;
            this.TabControlValues.Location = new System.Drawing.Point(8, 46);
            this.TabControlValues.Name = "TabControlValues";
            this.TabControlValues.SelectedIndex = 0;
            this.TabControlValues.Size = new System.Drawing.Size(320, 209);
            this.TabControlValues.TabIndex = 2;
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.InputStamina);
            this.TabGeneral.Controls.Add(this.InputHearts);
            this.TabGeneral.Controls.Add(this.InputRupees);
            this.TabGeneral.Controls.Add(this.LblStamina);
            this.TabGeneral.Controls.Add(this.LblHearts);
            this.TabGeneral.Controls.Add(this.LblRupees);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneral.Size = new System.Drawing.Size(312, 183);
            this.TabGeneral.TabIndex = 0;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // InputStamina
            // 
            this.InputStamina.Increment = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.InputStamina.Location = new System.Drawing.Point(60, 68);
            this.InputStamina.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.InputStamina.Name = "InputStamina";
            this.InputStamina.Size = new System.Drawing.Size(131, 20);
            this.InputStamina.TabIndex = 5;
            // 
            // InputHearts
            // 
            this.InputHearts.Location = new System.Drawing.Point(60, 42);
            this.InputHearts.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.InputHearts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InputHearts.Name = "InputHearts";
            this.InputHearts.Size = new System.Drawing.Size(131, 20);
            this.InputHearts.TabIndex = 4;
            this.InputHearts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // InputRupees
            // 
            this.InputRupees.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.InputRupees.Location = new System.Drawing.Point(60, 15);
            this.InputRupees.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.InputRupees.Name = "InputRupees";
            this.InputRupees.Size = new System.Drawing.Size(131, 20);
            this.InputRupees.TabIndex = 3;
            // 
            // LblStamina
            // 
            this.LblStamina.AutoSize = true;
            this.LblStamina.Location = new System.Drawing.Point(9, 70);
            this.LblStamina.Name = "LblStamina";
            this.LblStamina.Size = new System.Drawing.Size(45, 13);
            this.LblStamina.TabIndex = 2;
            this.LblStamina.Text = "Stamina";
            // 
            // LblHearts
            // 
            this.LblHearts.AutoSize = true;
            this.LblHearts.Location = new System.Drawing.Point(9, 44);
            this.LblHearts.Name = "LblHearts";
            this.LblHearts.Size = new System.Drawing.Size(38, 13);
            this.LblHearts.TabIndex = 1;
            this.LblHearts.Text = "Hearts";
            // 
            // LblRupees
            // 
            this.LblRupees.AutoSize = true;
            this.LblRupees.Location = new System.Drawing.Point(9, 17);
            this.LblRupees.Name = "LblRupees";
            this.LblRupees.Size = new System.Drawing.Size(44, 13);
            this.LblRupees.TabIndex = 0;
            this.LblRupees.Text = "Rupees";
            // 
            // TabSwords
            // 
            this.TabSwords.Controls.Add(this.InputSwordPouch);
            this.TabSwords.Controls.Add(this.LblSwordPouch);
            this.TabSwords.Controls.Add(this.LblSwordSlot4);
            this.TabSwords.Controls.Add(this.LblSwordSlot3);
            this.TabSwords.Controls.Add(this.ComboSwordSlot4);
            this.TabSwords.Controls.Add(this.ComboSwordSlot3);
            this.TabSwords.Controls.Add(this.ComboSwordSlot2);
            this.TabSwords.Controls.Add(this.ComboSwordSlot1);
            this.TabSwords.Controls.Add(this.ComboSwordSlot0);
            this.TabSwords.Controls.Add(this.LblSwordSlot2);
            this.TabSwords.Controls.Add(this.LblSwordSlot1);
            this.TabSwords.Controls.Add(this.LblSwordSlot0);
            this.TabSwords.Location = new System.Drawing.Point(4, 22);
            this.TabSwords.Name = "TabSwords";
            this.TabSwords.Padding = new System.Windows.Forms.Padding(3);
            this.TabSwords.Size = new System.Drawing.Size(312, 183);
            this.TabSwords.TabIndex = 1;
            this.TabSwords.Text = "Swords";
            this.TabSwords.UseVisualStyleBackColor = true;
            // 
            // LblSwordSlot4
            // 
            this.LblSwordSlot4.AutoSize = true;
            this.LblSwordSlot4.Location = new System.Drawing.Point(11, 124);
            this.LblSwordSlot4.Name = "LblSwordSlot4";
            this.LblSwordSlot4.Size = new System.Drawing.Size(34, 13);
            this.LblSwordSlot4.TabIndex = 10;
            this.LblSwordSlot4.Text = "Slot 5";
            // 
            // LblSwordSlot3
            // 
            this.LblSwordSlot3.AutoSize = true;
            this.LblSwordSlot3.Location = new System.Drawing.Point(11, 97);
            this.LblSwordSlot3.Name = "LblSwordSlot3";
            this.LblSwordSlot3.Size = new System.Drawing.Size(34, 13);
            this.LblSwordSlot3.TabIndex = 9;
            this.LblSwordSlot3.Text = "Slot 4";
            // 
            // ComboSwordSlot4
            // 
            this.ComboSwordSlot4.FormattingEnabled = true;
            this.ComboSwordSlot4.Location = new System.Drawing.Point(51, 121);
            this.ComboSwordSlot4.Name = "ComboSwordSlot4";
            this.ComboSwordSlot4.Size = new System.Drawing.Size(250, 21);
            this.ComboSwordSlot4.TabIndex = 8;
            // 
            // ComboSwordSlot3
            // 
            this.ComboSwordSlot3.FormattingEnabled = true;
            this.ComboSwordSlot3.Location = new System.Drawing.Point(51, 94);
            this.ComboSwordSlot3.Name = "ComboSwordSlot3";
            this.ComboSwordSlot3.Size = new System.Drawing.Size(250, 21);
            this.ComboSwordSlot3.TabIndex = 7;
            // 
            // ComboSwordSlot2
            // 
            this.ComboSwordSlot2.FormattingEnabled = true;
            this.ComboSwordSlot2.Location = new System.Drawing.Point(51, 67);
            this.ComboSwordSlot2.Name = "ComboSwordSlot2";
            this.ComboSwordSlot2.Size = new System.Drawing.Size(250, 21);
            this.ComboSwordSlot2.TabIndex = 6;
            // 
            // ComboSwordSlot1
            // 
            this.ComboSwordSlot1.FormattingEnabled = true;
            this.ComboSwordSlot1.Location = new System.Drawing.Point(51, 40);
            this.ComboSwordSlot1.Name = "ComboSwordSlot1";
            this.ComboSwordSlot1.Size = new System.Drawing.Size(250, 21);
            this.ComboSwordSlot1.TabIndex = 5;
            // 
            // ComboSwordSlot0
            // 
            this.ComboSwordSlot0.FormattingEnabled = true;
            this.ComboSwordSlot0.Location = new System.Drawing.Point(51, 13);
            this.ComboSwordSlot0.Name = "ComboSwordSlot0";
            this.ComboSwordSlot0.Size = new System.Drawing.Size(250, 21);
            this.ComboSwordSlot0.TabIndex = 4;
            // 
            // LblSwordSlot2
            // 
            this.LblSwordSlot2.AutoSize = true;
            this.LblSwordSlot2.Location = new System.Drawing.Point(11, 70);
            this.LblSwordSlot2.Name = "LblSwordSlot2";
            this.LblSwordSlot2.Size = new System.Drawing.Size(34, 13);
            this.LblSwordSlot2.TabIndex = 3;
            this.LblSwordSlot2.Text = "Slot 3";
            // 
            // LblSwordSlot1
            // 
            this.LblSwordSlot1.AutoSize = true;
            this.LblSwordSlot1.Location = new System.Drawing.Point(11, 43);
            this.LblSwordSlot1.Name = "LblSwordSlot1";
            this.LblSwordSlot1.Size = new System.Drawing.Size(34, 13);
            this.LblSwordSlot1.TabIndex = 2;
            this.LblSwordSlot1.Text = "Slot 2";
            // 
            // LblSwordSlot0
            // 
            this.LblSwordSlot0.AutoSize = true;
            this.LblSwordSlot0.Location = new System.Drawing.Point(11, 16);
            this.LblSwordSlot0.Name = "LblSwordSlot0";
            this.LblSwordSlot0.Size = new System.Drawing.Size(34, 13);
            this.LblSwordSlot0.TabIndex = 1;
            this.LblSwordSlot0.Text = "Slot 1";
            // 
            // TabBows
            // 
            this.TabBows.Controls.Add(this.InputBowPouch);
            this.TabBows.Controls.Add(this.LblBowPouch);
            this.TabBows.Controls.Add(this.LblBowSlot4);
            this.TabBows.Controls.Add(this.LblBowSlot3);
            this.TabBows.Controls.Add(this.ComboBowSlot4);
            this.TabBows.Controls.Add(this.ComboBowSlot3);
            this.TabBows.Controls.Add(this.ComboBowSlot2);
            this.TabBows.Controls.Add(this.ComboBowSlot1);
            this.TabBows.Controls.Add(this.ComboBowSlot0);
            this.TabBows.Controls.Add(this.LblBowSlot2);
            this.TabBows.Controls.Add(this.LblBowSlot1);
            this.TabBows.Controls.Add(this.LblBowSlot0);
            this.TabBows.Location = new System.Drawing.Point(4, 22);
            this.TabBows.Name = "TabBows";
            this.TabBows.Size = new System.Drawing.Size(312, 183);
            this.TabBows.TabIndex = 2;
            this.TabBows.Text = "Bows";
            this.TabBows.UseVisualStyleBackColor = true;
            // 
            // LblBowSlot4
            // 
            this.LblBowSlot4.AutoSize = true;
            this.LblBowSlot4.Location = new System.Drawing.Point(11, 124);
            this.LblBowSlot4.Name = "LblBowSlot4";
            this.LblBowSlot4.Size = new System.Drawing.Size(34, 13);
            this.LblBowSlot4.TabIndex = 20;
            this.LblBowSlot4.Text = "Slot 5";
            // 
            // LblBowSlot3
            // 
            this.LblBowSlot3.AutoSize = true;
            this.LblBowSlot3.Location = new System.Drawing.Point(11, 97);
            this.LblBowSlot3.Name = "LblBowSlot3";
            this.LblBowSlot3.Size = new System.Drawing.Size(34, 13);
            this.LblBowSlot3.TabIndex = 19;
            this.LblBowSlot3.Text = "Slot 4";
            // 
            // ComboBowSlot4
            // 
            this.ComboBowSlot4.FormattingEnabled = true;
            this.ComboBowSlot4.Location = new System.Drawing.Point(51, 121);
            this.ComboBowSlot4.Name = "ComboBowSlot4";
            this.ComboBowSlot4.Size = new System.Drawing.Size(250, 21);
            this.ComboBowSlot4.TabIndex = 18;
            // 
            // ComboBowSlot3
            // 
            this.ComboBowSlot3.FormattingEnabled = true;
            this.ComboBowSlot3.Location = new System.Drawing.Point(51, 94);
            this.ComboBowSlot3.Name = "ComboBowSlot3";
            this.ComboBowSlot3.Size = new System.Drawing.Size(250, 21);
            this.ComboBowSlot3.TabIndex = 17;
            // 
            // ComboBowSlot2
            // 
            this.ComboBowSlot2.FormattingEnabled = true;
            this.ComboBowSlot2.Location = new System.Drawing.Point(51, 67);
            this.ComboBowSlot2.Name = "ComboBowSlot2";
            this.ComboBowSlot2.Size = new System.Drawing.Size(250, 21);
            this.ComboBowSlot2.TabIndex = 16;
            // 
            // ComboBowSlot1
            // 
            this.ComboBowSlot1.FormattingEnabled = true;
            this.ComboBowSlot1.Location = new System.Drawing.Point(51, 40);
            this.ComboBowSlot1.Name = "ComboBowSlot1";
            this.ComboBowSlot1.Size = new System.Drawing.Size(250, 21);
            this.ComboBowSlot1.TabIndex = 15;
            // 
            // ComboBowSlot0
            // 
            this.ComboBowSlot0.FormattingEnabled = true;
            this.ComboBowSlot0.Location = new System.Drawing.Point(51, 13);
            this.ComboBowSlot0.Name = "ComboBowSlot0";
            this.ComboBowSlot0.Size = new System.Drawing.Size(250, 21);
            this.ComboBowSlot0.TabIndex = 14;
            // 
            // LblBowSlot2
            // 
            this.LblBowSlot2.AutoSize = true;
            this.LblBowSlot2.Location = new System.Drawing.Point(11, 70);
            this.LblBowSlot2.Name = "LblBowSlot2";
            this.LblBowSlot2.Size = new System.Drawing.Size(34, 13);
            this.LblBowSlot2.TabIndex = 13;
            this.LblBowSlot2.Text = "Slot 3";
            // 
            // LblBowSlot1
            // 
            this.LblBowSlot1.AutoSize = true;
            this.LblBowSlot1.Location = new System.Drawing.Point(11, 43);
            this.LblBowSlot1.Name = "LblBowSlot1";
            this.LblBowSlot1.Size = new System.Drawing.Size(34, 13);
            this.LblBowSlot1.TabIndex = 12;
            this.LblBowSlot1.Text = "Slot 2";
            // 
            // LblBowSlot0
            // 
            this.LblBowSlot0.AutoSize = true;
            this.LblBowSlot0.Location = new System.Drawing.Point(11, 16);
            this.LblBowSlot0.Name = "LblBowSlot0";
            this.LblBowSlot0.Size = new System.Drawing.Size(34, 13);
            this.LblBowSlot0.TabIndex = 11;
            this.LblBowSlot0.Text = "Slot 1";
            // 
            // TabShields
            // 
            this.TabShields.Controls.Add(this.InputShieldPouch);
            this.TabShields.Controls.Add(this.LblShieldPouch);
            this.TabShields.Controls.Add(this.LblShieldSlot4);
            this.TabShields.Controls.Add(this.LblShieldSlot3);
            this.TabShields.Controls.Add(this.ComboShieldSlot4);
            this.TabShields.Controls.Add(this.ComboShieldSlot3);
            this.TabShields.Controls.Add(this.ComboShieldSlot2);
            this.TabShields.Controls.Add(this.ComboShieldSlot1);
            this.TabShields.Controls.Add(this.ComboShieldSlot0);
            this.TabShields.Controls.Add(this.LblShieldSlot2);
            this.TabShields.Controls.Add(this.LblShieldSlot1);
            this.TabShields.Controls.Add(this.LblShieldSlot0);
            this.TabShields.Location = new System.Drawing.Point(4, 22);
            this.TabShields.Name = "TabShields";
            this.TabShields.Size = new System.Drawing.Size(312, 183);
            this.TabShields.TabIndex = 3;
            this.TabShields.Text = "Shields";
            this.TabShields.UseVisualStyleBackColor = true;
            // 
            // LblShieldSlot4
            // 
            this.LblShieldSlot4.AutoSize = true;
            this.LblShieldSlot4.Location = new System.Drawing.Point(11, 124);
            this.LblShieldSlot4.Name = "LblShieldSlot4";
            this.LblShieldSlot4.Size = new System.Drawing.Size(34, 13);
            this.LblShieldSlot4.TabIndex = 30;
            this.LblShieldSlot4.Text = "Slot 5";
            // 
            // LblShieldSlot3
            // 
            this.LblShieldSlot3.AutoSize = true;
            this.LblShieldSlot3.Location = new System.Drawing.Point(11, 97);
            this.LblShieldSlot3.Name = "LblShieldSlot3";
            this.LblShieldSlot3.Size = new System.Drawing.Size(34, 13);
            this.LblShieldSlot3.TabIndex = 29;
            this.LblShieldSlot3.Text = "Slot 4";
            // 
            // ComboShieldSlot4
            // 
            this.ComboShieldSlot4.FormattingEnabled = true;
            this.ComboShieldSlot4.Location = new System.Drawing.Point(51, 121);
            this.ComboShieldSlot4.Name = "ComboShieldSlot4";
            this.ComboShieldSlot4.Size = new System.Drawing.Size(250, 21);
            this.ComboShieldSlot4.TabIndex = 28;
            // 
            // ComboShieldSlot3
            // 
            this.ComboShieldSlot3.FormattingEnabled = true;
            this.ComboShieldSlot3.Location = new System.Drawing.Point(51, 94);
            this.ComboShieldSlot3.Name = "ComboShieldSlot3";
            this.ComboShieldSlot3.Size = new System.Drawing.Size(250, 21);
            this.ComboShieldSlot3.TabIndex = 27;
            // 
            // ComboShieldSlot2
            // 
            this.ComboShieldSlot2.FormattingEnabled = true;
            this.ComboShieldSlot2.Location = new System.Drawing.Point(51, 67);
            this.ComboShieldSlot2.Name = "ComboShieldSlot2";
            this.ComboShieldSlot2.Size = new System.Drawing.Size(250, 21);
            this.ComboShieldSlot2.TabIndex = 26;
            // 
            // ComboShieldSlot1
            // 
            this.ComboShieldSlot1.FormattingEnabled = true;
            this.ComboShieldSlot1.Location = new System.Drawing.Point(51, 40);
            this.ComboShieldSlot1.Name = "ComboShieldSlot1";
            this.ComboShieldSlot1.Size = new System.Drawing.Size(250, 21);
            this.ComboShieldSlot1.TabIndex = 25;
            // 
            // ComboShieldSlot0
            // 
            this.ComboShieldSlot0.FormattingEnabled = true;
            this.ComboShieldSlot0.Location = new System.Drawing.Point(51, 13);
            this.ComboShieldSlot0.Name = "ComboShieldSlot0";
            this.ComboShieldSlot0.Size = new System.Drawing.Size(250, 21);
            this.ComboShieldSlot0.TabIndex = 24;
            // 
            // LblShieldSlot2
            // 
            this.LblShieldSlot2.AutoSize = true;
            this.LblShieldSlot2.Location = new System.Drawing.Point(11, 70);
            this.LblShieldSlot2.Name = "LblShieldSlot2";
            this.LblShieldSlot2.Size = new System.Drawing.Size(34, 13);
            this.LblShieldSlot2.TabIndex = 23;
            this.LblShieldSlot2.Text = "Slot 3";
            // 
            // LblShieldSlot1
            // 
            this.LblShieldSlot1.AutoSize = true;
            this.LblShieldSlot1.Location = new System.Drawing.Point(11, 43);
            this.LblShieldSlot1.Name = "LblShieldSlot1";
            this.LblShieldSlot1.Size = new System.Drawing.Size(34, 13);
            this.LblShieldSlot1.TabIndex = 22;
            this.LblShieldSlot1.Text = "Slot 2";
            // 
            // LblShieldSlot0
            // 
            this.LblShieldSlot0.AutoSize = true;
            this.LblShieldSlot0.Location = new System.Drawing.Point(11, 16);
            this.LblShieldSlot0.Name = "LblShieldSlot0";
            this.LblShieldSlot0.Size = new System.Drawing.Size(34, 13);
            this.LblShieldSlot0.TabIndex = 21;
            this.LblShieldSlot0.Text = "Slot 1";
            // 
            // TabArmor
            // 
            this.TabArmor.Controls.Add(this.LblArmorSlot4);
            this.TabArmor.Controls.Add(this.LblArmorSlot3);
            this.TabArmor.Controls.Add(this.ComboArmorSlot4);
            this.TabArmor.Controls.Add(this.ComboArmorSlot3);
            this.TabArmor.Controls.Add(this.ComboArmorSlot2);
            this.TabArmor.Controls.Add(this.ComboArmorSlot1);
            this.TabArmor.Controls.Add(this.ComboArmorSlot0);
            this.TabArmor.Controls.Add(this.LblArmorSlot2);
            this.TabArmor.Controls.Add(this.LblArmorSlot1);
            this.TabArmor.Controls.Add(this.LblArmorSlot0);
            this.TabArmor.Location = new System.Drawing.Point(4, 22);
            this.TabArmor.Name = "TabArmor";
            this.TabArmor.Size = new System.Drawing.Size(312, 183);
            this.TabArmor.TabIndex = 4;
            this.TabArmor.Text = "Armor";
            this.TabArmor.UseVisualStyleBackColor = true;
            // 
            // LblArmorSlot4
            // 
            this.LblArmorSlot4.AutoSize = true;
            this.LblArmorSlot4.Location = new System.Drawing.Point(11, 124);
            this.LblArmorSlot4.Name = "LblArmorSlot4";
            this.LblArmorSlot4.Size = new System.Drawing.Size(34, 13);
            this.LblArmorSlot4.TabIndex = 30;
            this.LblArmorSlot4.Text = "Slot 5";
            // 
            // LblArmorSlot3
            // 
            this.LblArmorSlot3.AutoSize = true;
            this.LblArmorSlot3.Location = new System.Drawing.Point(11, 97);
            this.LblArmorSlot3.Name = "LblArmorSlot3";
            this.LblArmorSlot3.Size = new System.Drawing.Size(34, 13);
            this.LblArmorSlot3.TabIndex = 29;
            this.LblArmorSlot3.Text = "Slot 4";
            // 
            // ComboArmorSlot4
            // 
            this.ComboArmorSlot4.FormattingEnabled = true;
            this.ComboArmorSlot4.Location = new System.Drawing.Point(51, 121);
            this.ComboArmorSlot4.Name = "ComboArmorSlot4";
            this.ComboArmorSlot4.Size = new System.Drawing.Size(250, 21);
            this.ComboArmorSlot4.TabIndex = 28;
            // 
            // ComboArmorSlot3
            // 
            this.ComboArmorSlot3.FormattingEnabled = true;
            this.ComboArmorSlot3.Location = new System.Drawing.Point(51, 94);
            this.ComboArmorSlot3.Name = "ComboArmorSlot3";
            this.ComboArmorSlot3.Size = new System.Drawing.Size(250, 21);
            this.ComboArmorSlot3.TabIndex = 27;
            // 
            // ComboArmorSlot2
            // 
            this.ComboArmorSlot2.FormattingEnabled = true;
            this.ComboArmorSlot2.Location = new System.Drawing.Point(51, 67);
            this.ComboArmorSlot2.Name = "ComboArmorSlot2";
            this.ComboArmorSlot2.Size = new System.Drawing.Size(250, 21);
            this.ComboArmorSlot2.TabIndex = 26;
            // 
            // ComboArmorSlot1
            // 
            this.ComboArmorSlot1.FormattingEnabled = true;
            this.ComboArmorSlot1.Location = new System.Drawing.Point(51, 40);
            this.ComboArmorSlot1.Name = "ComboArmorSlot1";
            this.ComboArmorSlot1.Size = new System.Drawing.Size(250, 21);
            this.ComboArmorSlot1.TabIndex = 25;
            // 
            // ComboArmorSlot0
            // 
            this.ComboArmorSlot0.FormattingEnabled = true;
            this.ComboArmorSlot0.Location = new System.Drawing.Point(51, 13);
            this.ComboArmorSlot0.Name = "ComboArmorSlot0";
            this.ComboArmorSlot0.Size = new System.Drawing.Size(250, 21);
            this.ComboArmorSlot0.TabIndex = 24;
            // 
            // LblArmorSlot2
            // 
            this.LblArmorSlot2.AutoSize = true;
            this.LblArmorSlot2.Location = new System.Drawing.Point(11, 70);
            this.LblArmorSlot2.Name = "LblArmorSlot2";
            this.LblArmorSlot2.Size = new System.Drawing.Size(34, 13);
            this.LblArmorSlot2.TabIndex = 23;
            this.LblArmorSlot2.Text = "Slot 3";
            // 
            // LblArmorSlot1
            // 
            this.LblArmorSlot1.AutoSize = true;
            this.LblArmorSlot1.Location = new System.Drawing.Point(11, 43);
            this.LblArmorSlot1.Name = "LblArmorSlot1";
            this.LblArmorSlot1.Size = new System.Drawing.Size(34, 13);
            this.LblArmorSlot1.TabIndex = 22;
            this.LblArmorSlot1.Text = "Slot 2";
            // 
            // LblArmorSlot0
            // 
            this.LblArmorSlot0.AutoSize = true;
            this.LblArmorSlot0.Location = new System.Drawing.Point(11, 16);
            this.LblArmorSlot0.Name = "LblArmorSlot0";
            this.LblArmorSlot0.Size = new System.Drawing.Size(34, 13);
            this.LblArmorSlot0.TabIndex = 21;
            this.LblArmorSlot0.Text = "Slot 1";
            // 
            // BtnPatchSaveFile
            // 
            this.BtnPatchSaveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPatchSaveFile.Enabled = false;
            this.BtnPatchSaveFile.Location = new System.Drawing.Point(104, 261);
            this.BtnPatchSaveFile.Name = "BtnPatchSaveFile";
            this.BtnPatchSaveFile.Size = new System.Drawing.Size(90, 30);
            this.BtnPatchSaveFile.TabIndex = 3;
            this.BtnPatchSaveFile.Text = "Patch Savefile";
            this.BtnPatchSaveFile.UseVisualStyleBackColor = true;
            this.BtnPatchSaveFile.Click += new System.EventHandler(this.BtnPatchSaveFile_Click);
            // 
            // LblPath
            // 
            this.LblPath.AutoSize = true;
            this.LblPath.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPath.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LblPath.Location = new System.Drawing.Point(-1, 6);
            this.LblPath.Name = "LblPath";
            this.LblPath.Size = new System.Drawing.Size(75, 13);
            this.LblPath.TabIndex = 5;
            this.LblPath.Text = "progress.sav";
            // 
            // PanelPath
            // 
            this.PanelPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelPath.Controls.Add(this.LblPath);
            this.PanelPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PanelPath.Location = new System.Drawing.Point(104, 12);
            this.PanelPath.Name = "PanelPath";
            this.PanelPath.Size = new System.Drawing.Size(220, 26);
            this.PanelPath.TabIndex = 6;
            // 
            // BtnReset
            // 
            this.BtnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReset.Enabled = false;
            this.BtnReset.Location = new System.Drawing.Point(8, 261);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(90, 30);
            this.BtnReset.TabIndex = 7;
            this.BtnReset.Text = "Unload Savefile";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // LblSwordPouch
            // 
            this.LblSwordPouch.AutoSize = true;
            this.LblSwordPouch.Location = new System.Drawing.Point(11, 155);
            this.LblSwordPouch.Name = "LblSwordPouch";
            this.LblSwordPouch.Size = new System.Drawing.Size(64, 13);
            this.LblSwordPouch.TabIndex = 11;
            this.LblSwordPouch.Text = "Pouch Size:";
            // 
            // InputSwordPouch
            // 
            this.InputSwordPouch.Location = new System.Drawing.Point(81, 153);
            this.InputSwordPouch.Name = "InputSwordPouch";
            this.InputSwordPouch.Size = new System.Drawing.Size(71, 20);
            this.InputSwordPouch.TabIndex = 12;
            // 
            // InputBowPouch
            // 
            this.InputBowPouch.Location = new System.Drawing.Point(81, 153);
            this.InputBowPouch.Name = "InputBowPouch";
            this.InputBowPouch.Size = new System.Drawing.Size(71, 20);
            this.InputBowPouch.TabIndex = 22;
            // 
            // LblBowPouch
            // 
            this.LblBowPouch.AutoSize = true;
            this.LblBowPouch.Location = new System.Drawing.Point(11, 155);
            this.LblBowPouch.Name = "LblBowPouch";
            this.LblBowPouch.Size = new System.Drawing.Size(64, 13);
            this.LblBowPouch.TabIndex = 21;
            this.LblBowPouch.Text = "Pouch Size:";
            // 
            // InputShieldPouch
            // 
            this.InputShieldPouch.Location = new System.Drawing.Point(81, 153);
            this.InputShieldPouch.Name = "InputShieldPouch";
            this.InputShieldPouch.Size = new System.Drawing.Size(71, 20);
            this.InputShieldPouch.TabIndex = 32;
            // 
            // LblShieldPouch
            // 
            this.LblShieldPouch.AutoSize = true;
            this.LblShieldPouch.Location = new System.Drawing.Point(11, 155);
            this.LblShieldPouch.Name = "LblShieldPouch";
            this.LblShieldPouch.Size = new System.Drawing.Size(64, 13);
            this.LblShieldPouch.TabIndex = 31;
            this.LblShieldPouch.Text = "Pouch Size:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(333, 301);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.PanelPath);
            this.Controls.Add(this.BtnPatchSaveFile);
            this.Controls.Add(this.TabControlValues);
            this.Controls.Add(this.BtnOpenSaveFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "TOTK | SaveGame Editor";
            this.TabControlValues.ResumeLayout(false);
            this.TabGeneral.ResumeLayout(false);
            this.TabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputStamina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputHearts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputRupees)).EndInit();
            this.TabSwords.ResumeLayout(false);
            this.TabSwords.PerformLayout();
            this.TabBows.ResumeLayout(false);
            this.TabBows.PerformLayout();
            this.TabShields.ResumeLayout(false);
            this.TabShields.PerformLayout();
            this.TabArmor.ResumeLayout(false);
            this.TabArmor.PerformLayout();
            this.PanelPath.ResumeLayout(false);
            this.PanelPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputSwordPouch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputBowPouch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputShieldPouch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOpenSaveFile;
        private System.Windows.Forms.TabControl TabControlValues;
        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.TabPage TabSwords;
        private System.Windows.Forms.TabPage TabBows;
        private System.Windows.Forms.TabPage TabShields;
        private System.Windows.Forms.NumericUpDown InputStamina;
        private System.Windows.Forms.NumericUpDown InputHearts;
        private System.Windows.Forms.NumericUpDown InputRupees;
        private System.Windows.Forms.Label LblStamina;
        private System.Windows.Forms.Label LblHearts;
        private System.Windows.Forms.Label LblRupees;
        private System.Windows.Forms.ComboBox ComboSwordSlot0;
        private System.Windows.Forms.Label LblSwordSlot2;
        private System.Windows.Forms.Label LblSwordSlot1;
        private System.Windows.Forms.Label LblSwordSlot0;
        private System.Windows.Forms.ComboBox ComboSwordSlot4;
        private System.Windows.Forms.ComboBox ComboSwordSlot3;
        private System.Windows.Forms.ComboBox ComboSwordSlot2;
        private System.Windows.Forms.ComboBox ComboSwordSlot1;
        private System.Windows.Forms.Label LblSwordSlot4;
        private System.Windows.Forms.Label LblSwordSlot3;
        private System.Windows.Forms.Label LblBowSlot4;
        private System.Windows.Forms.Label LblBowSlot3;
        private System.Windows.Forms.ComboBox ComboBowSlot4;
        private System.Windows.Forms.ComboBox ComboBowSlot3;
        private System.Windows.Forms.ComboBox ComboBowSlot2;
        private System.Windows.Forms.ComboBox ComboBowSlot1;
        private System.Windows.Forms.ComboBox ComboBowSlot0;
        private System.Windows.Forms.Label LblBowSlot2;
        private System.Windows.Forms.Label LblBowSlot1;
        private System.Windows.Forms.Label LblBowSlot0;
        private System.Windows.Forms.Button BtnPatchSaveFile;
        private System.Windows.Forms.Label LblShieldSlot4;
        private System.Windows.Forms.Label LblShieldSlot3;
        private System.Windows.Forms.ComboBox ComboShieldSlot4;
        private System.Windows.Forms.ComboBox ComboShieldSlot3;
        private System.Windows.Forms.ComboBox ComboShieldSlot2;
        private System.Windows.Forms.ComboBox ComboShieldSlot1;
        private System.Windows.Forms.ComboBox ComboShieldSlot0;
        private System.Windows.Forms.Label LblShieldSlot2;
        private System.Windows.Forms.Label LblShieldSlot1;
        private System.Windows.Forms.Label LblShieldSlot0;
        private System.Windows.Forms.TabPage TabArmor;
        private System.Windows.Forms.Label LblArmorSlot4;
        private System.Windows.Forms.Label LblArmorSlot3;
        private System.Windows.Forms.ComboBox ComboArmorSlot4;
        private System.Windows.Forms.ComboBox ComboArmorSlot3;
        private System.Windows.Forms.ComboBox ComboArmorSlot2;
        private System.Windows.Forms.ComboBox ComboArmorSlot1;
        private System.Windows.Forms.ComboBox ComboArmorSlot0;
        private System.Windows.Forms.Label LblArmorSlot2;
        private System.Windows.Forms.Label LblArmorSlot1;
        private System.Windows.Forms.Label LblArmorSlot0;
        private System.Windows.Forms.Label LblPath;
        private System.Windows.Forms.Panel PanelPath;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.NumericUpDown InputSwordPouch;
        private System.Windows.Forms.Label LblSwordPouch;
        private System.Windows.Forms.NumericUpDown InputBowPouch;
        private System.Windows.Forms.Label LblBowPouch;
        private System.Windows.Forms.NumericUpDown InputShieldPouch;
        private System.Windows.Forms.Label LblShieldPouch;
    }
}

