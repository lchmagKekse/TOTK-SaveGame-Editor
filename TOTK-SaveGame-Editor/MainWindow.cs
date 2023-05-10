using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TOTK_SaveGame_Editor
{
    public partial class MainWindow : Form
    {
        private SaveFile _SaveFile;

        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxes();
        }

        private void SetComboIndex(List<Item> items, string value, ComboBox comboBox)
        {
            comboBox.SelectedIndex = 0;

            var index = items.FindIndex(item => item.Id == value);
            if (index == -1) return;

            comboBox.SelectedIndex = index;
        }

        private void BtnOpenSaveFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog
            {
                Filter = "progress (*.sav)|*.sav"
            };

            if (FileDialog.ShowDialog() != DialogResult.OK) return;
            if (!FileDialog.CheckFileExists) return;

            _SaveFile = new SaveFile(FileDialog.FileName);

            if (!_SaveFile.IsLoaded)
            {
                MessageBox.Show("Invalid progress.sav!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LblPath.Text = FileDialog.FileName;

            BtnOpenSaveFile.Enabled = false;
            BtnPatchSaveFile.Enabled = true;
            BtnReset.Enabled = true;

            SetValuesFromSavefile();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            LblPath.Text = "progress.sav";
            _SaveFile = null;

            BtnOpenSaveFile.Enabled = true;
            BtnPatchSaveFile.Enabled = false;
            BtnReset.Enabled = false;
        }

        private void FillComboBoxes()
        {
            ComboSwordSlot0.Items.AddRange(GameData.Swords.Select(item => item.Name).ToArray());
            ComboSwordSlot1.Items.AddRange(GameData.Swords.Select(item => item.Name).ToArray());
            ComboSwordSlot2.Items.AddRange(GameData.Swords.Select(item => item.Name).ToArray());
            ComboSwordSlot3.Items.AddRange(GameData.Swords.Select(item => item.Name).ToArray());
            ComboSwordSlot4.Items.AddRange(GameData.Swords.Select(item => item.Name).ToArray());

            ComboBowSlot0.Items.AddRange(GameData.Bows.Select(item => item.Name).ToArray());
            ComboBowSlot1.Items.AddRange(GameData.Bows.Select(item => item.Name).ToArray());
            ComboBowSlot2.Items.AddRange(GameData.Bows.Select(item => item.Name).ToArray());
            ComboBowSlot3.Items.AddRange(GameData.Bows.Select(item => item.Name).ToArray());
            ComboBowSlot4.Items.AddRange(GameData.Bows.Select(item => item.Name).ToArray());

            ComboShieldSlot0.Items.AddRange(GameData.Shields.Select(item => item.Name).ToArray());
            ComboShieldSlot1.Items.AddRange(GameData.Shields.Select(item => item.Name).ToArray());
            ComboShieldSlot2.Items.AddRange(GameData.Shields.Select(item => item.Name).ToArray());
            ComboShieldSlot3.Items.AddRange(GameData.Shields.Select(item => item.Name).ToArray());
            ComboShieldSlot4.Items.AddRange(GameData.Shields.Select(item => item.Name).ToArray());

            ComboArmorSlot0.Items.AddRange(GameData.Armor.Select(item => item.Name).ToArray());
            ComboArmorSlot1.Items.AddRange(GameData.Armor.Select(item => item.Name).ToArray());
            ComboArmorSlot2.Items.AddRange(GameData.Armor.Select(item => item.Name).ToArray());
            ComboArmorSlot3.Items.AddRange(GameData.Armor.Select(item => item.Name).ToArray());
            ComboArmorSlot4.Items.AddRange(GameData.Armor.Select(item => item.Name).ToArray());
        }

        private void SetValuesFromSavefile()
        {
            InputRupees.Value = _SaveFile.ReadRupees();
            InputHearts.Value = _SaveFile.ReadHearts();
            InputStamina.Value = _SaveFile.ReadStamina();

            InputSwordPouch.Value = _SaveFile.ReadSwordPouch();
            InputBowPouch.Value = _SaveFile.ReadBowPouch();
            InputShieldPouch.Value= _SaveFile.ReadShieldPouch();

            SetComboIndex(GameData.Swords, _SaveFile.ReadSword(0), ComboSwordSlot0);
            SetComboIndex(GameData.Swords, _SaveFile.ReadSword(1), ComboSwordSlot1);
            SetComboIndex(GameData.Swords, _SaveFile.ReadSword(2), ComboSwordSlot2);
            SetComboIndex(GameData.Swords, _SaveFile.ReadSword(3), ComboSwordSlot3);
            SetComboIndex(GameData.Swords, _SaveFile.ReadSword(4), ComboSwordSlot4);

            SetComboIndex(GameData.Bows, _SaveFile.ReadBow(0), ComboBowSlot0);
            SetComboIndex(GameData.Bows, _SaveFile.ReadBow(1), ComboBowSlot1);
            SetComboIndex(GameData.Bows, _SaveFile.ReadBow(2), ComboBowSlot2);
            SetComboIndex(GameData.Bows, _SaveFile.ReadBow(3), ComboBowSlot3);
            SetComboIndex(GameData.Bows, _SaveFile.ReadBow(4), ComboBowSlot4);

            SetComboIndex(GameData.Shields, _SaveFile.ReadShield(0), ComboShieldSlot0);
            SetComboIndex(GameData.Shields, _SaveFile.ReadShield(1), ComboShieldSlot1);
            SetComboIndex(GameData.Shields, _SaveFile.ReadShield(2), ComboShieldSlot2);
            SetComboIndex(GameData.Shields, _SaveFile.ReadShield(3), ComboShieldSlot3);
            SetComboIndex(GameData.Shields, _SaveFile.ReadShield(4), ComboShieldSlot4);

            SetComboIndex(GameData.Armor, _SaveFile.ReadArmor(0), ComboArmorSlot0);
            SetComboIndex(GameData.Armor, _SaveFile.ReadArmor(1), ComboArmorSlot1);
            SetComboIndex(GameData.Armor, _SaveFile.ReadArmor(2), ComboArmorSlot2);
            SetComboIndex(GameData.Armor, _SaveFile.ReadArmor(3), ComboArmorSlot3);
            SetComboIndex(GameData.Armor, _SaveFile.ReadArmor(4), ComboArmorSlot4);
        }

        private void BtnPatchSaveFile_Click(object sender, EventArgs e)
        {
            if (_SaveFile == null || !_SaveFile.IsLoaded)
            {
                MessageBox.Show("Invalid Savefile!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _SaveFile.WriteRupees((int)InputRupees.Value);
            _SaveFile.WriteHearts((int)InputHearts.Value);
            _SaveFile.WriteStamina((int)InputStamina.Value);

            _SaveFile.WriteSwordPouch((int)InputSwordPouch.Value);
            _SaveFile.WriteBowPouch((int)InputBowPouch.Value);
            _SaveFile.WriteShieldPouch((int)InputShieldPouch.Value);

            _SaveFile.WriteSword(0, GameData.Swords[ComboSwordSlot0.SelectedIndex]);
            _SaveFile.WriteSword(1, GameData.Swords[ComboSwordSlot1.SelectedIndex]);
            _SaveFile.WriteSword(2, GameData.Swords[ComboSwordSlot2.SelectedIndex]);
            _SaveFile.WriteSword(3, GameData.Swords[ComboSwordSlot3.SelectedIndex]);
            _SaveFile.WriteSword(4, GameData.Swords[ComboSwordSlot4.SelectedIndex]);

            _SaveFile.WriteBow(0, GameData.Bows[ComboBowSlot0.SelectedIndex]);
            _SaveFile.WriteBow(1, GameData.Bows[ComboBowSlot1.SelectedIndex]);
            _SaveFile.WriteBow(2, GameData.Bows[ComboBowSlot2.SelectedIndex]);
            _SaveFile.WriteBow(3, GameData.Bows[ComboBowSlot3.SelectedIndex]);
            _SaveFile.WriteBow(4, GameData.Bows[ComboBowSlot4.SelectedIndex]);

            _SaveFile.WriteShield(0, GameData.Shields[ComboShieldSlot0.SelectedIndex]);
            _SaveFile.WriteShield(1, GameData.Shields[ComboShieldSlot1.SelectedIndex]);
            _SaveFile.WriteShield(2, GameData.Shields[ComboShieldSlot2.SelectedIndex]);
            _SaveFile.WriteShield(3, GameData.Shields[ComboShieldSlot3.SelectedIndex]);
            _SaveFile.WriteShield(4, GameData.Shields[ComboShieldSlot4.SelectedIndex]);

            _SaveFile.WriteArmor(0, GameData.Armor[ComboArmorSlot0.SelectedIndex]);
            _SaveFile.WriteArmor(1, GameData.Armor[ComboArmorSlot1.SelectedIndex]);
            _SaveFile.WriteArmor(2, GameData.Armor[ComboArmorSlot2.SelectedIndex]);
            _SaveFile.WriteArmor(3, GameData.Armor[ComboArmorSlot3.SelectedIndex]);
            _SaveFile.WriteArmor(4, GameData.Armor[ComboArmorSlot4.SelectedIndex]);

            _SaveFile.PatchSaveFile();

            MessageBox.Show("Successfully patched savefile!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
