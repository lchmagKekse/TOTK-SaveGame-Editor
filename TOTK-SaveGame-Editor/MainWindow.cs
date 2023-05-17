using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TOTK_SaveGame_Editor
{
    public partial class MainWindow : Form
    {
        private TOTK_SaveFile _SaveFile;

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

            _SaveFile = new TOTK_SaveFile(FileDialog.FileName);

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

        private void TabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    Size = new Size(351, 260);
                    break;
                case 1:
                    Size = new Size(351, 344);
                    break;
                case 2:
                    Size = new Size(351, 344);
                    break;
                case 3:
                    Size = new Size(351, 344);
                    break;
                case 4:
                    Size = new Size(351, 312);
                    break;
                case 5:
                    Size = new Size(351, 541);
                    break;
            }
        }

        private void FillComboBoxes()
        {
            GameData.Swords = GameData.Swords.OrderBy(item => item.Name).ToList();
            GameData.Bows = GameData.Bows.OrderBy(item => item.Name).ToList();
            GameData.Shields = GameData.Shields.OrderBy(item => item.Name).ToList();


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
            InputShieldPouch.Value = _SaveFile.ReadShieldPouch();

            InputArrows.Value = _SaveFile.ReadArrows();

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

            CBMap1.Checked = _SaveFile.ReadBool(_SaveFile.ELDINCANYON_MAP);
            CBMap2.Checked = _SaveFile.ReadBool(_SaveFile.GERUDOCANYON_MAP);
            CBMap3.Checked = _SaveFile.ReadBool(_SaveFile.GERUDOHIGHLANDS_MAP);
            CBMap4.Checked = _SaveFile.ReadBool(_SaveFile.HYRULEFIELD_MAP);
            CBMap5.Checked = _SaveFile.ReadBool(_SaveFile.LINDORSBROW_MAP);
            CBMap6.Checked = _SaveFile.ReadBool(_SaveFile.LOOKOUTLANDING_MAP);
            CBMap7.Checked = _SaveFile.ReadBool(_SaveFile.MOUNTLANAYRU_MAP);
            CBMap8.Checked = _SaveFile.ReadBool(_SaveFile.PIKIDASTONEGROVE_MAP);
            CBMap9.Checked = _SaveFile.ReadBool(_SaveFile.POPLAFOOTHILLS_MAP);
            CBMap10.Checked = _SaveFile.ReadBool(_SaveFile.RABELLAWETLANDS_MAP);
            CBMap11.Checked = _SaveFile.ReadBool(_SaveFile.ROSPROPASS_MAP);
            CBMap12.Checked = _SaveFile.ReadBool(_SaveFile.SAHASRASLOPE_MAP);
            CBMap13.Checked = _SaveFile.ReadBool(_SaveFile.THYPHLORUINS_MAP);
            CBMap14.Checked = _SaveFile.ReadBool(_SaveFile.ULRIMOUNTAIN_MAP);
            CBMap15.Checked = _SaveFile.ReadBool(_SaveFile.UPLANDZORANA_MAP);

            CBActivated1.Checked = _SaveFile.ReadBool(_SaveFile.ELDINCANYON_TOWER_ACTIVE);
            CBActivated2.Checked = _SaveFile.ReadBool(_SaveFile.GERUDOCANYON_TOWER_ACTIVE);
            CBActivated3.Checked = _SaveFile.ReadBool(_SaveFile.GERUDOHIGHLANDS_TOWER_ACTIVE);
            CBActivated4.Checked = _SaveFile.ReadBool(_SaveFile.HYRULEFIELD_TOWER_ACTIVE);
            CBActivated5.Checked = _SaveFile.ReadBool(_SaveFile.LINDORSBROW_TOWER_ACTIVE);
            CBActivated6.Checked = _SaveFile.ReadBool(_SaveFile.LOOKOUTLANDING_TOWER_ACTIVE);
            CBActivated7.Checked = _SaveFile.ReadBool(_SaveFile.MOUNTLANAYRU_TOWER_ACTIVE);
            CBActivated8.Checked = _SaveFile.ReadBool(_SaveFile.PIKIDASTONEGROVE_TOWER_ACTIVE);
            CBActivated9.Checked = _SaveFile.ReadBool(_SaveFile.POPLAFOOTHILLS_TOWER_ACTIVE);
            CBActivated10.Checked = _SaveFile.ReadBool(_SaveFile.RABELLAWETLANDS_TOWER_ACTIVE);
            CBActivated11.Checked = _SaveFile.ReadBool(_SaveFile.ROSPROPASS_TOWER_ACTIVE);
            CBActivated12.Checked = _SaveFile.ReadBool(_SaveFile.SAHASRASLOPE_TOWER_ACTIVE);
            CBActivated13.Checked = _SaveFile.ReadBool(_SaveFile.THYPHLORUINS_TOWER_ACTIVE);
            CBActivated14.Checked = _SaveFile.ReadBool(_SaveFile.ULRIMOUNTAIN_TOWER_ACTIVE);
            CBActivated15.Checked = _SaveFile.ReadBool(_SaveFile.UPLANDZORANA_TOWER_ACTIVE);

            CBPin1.Checked = _SaveFile.ReadBool(_SaveFile.ELDINCANYON_TOWER_PIN);
            CBPin2.Checked = _SaveFile.ReadBool(_SaveFile.GERUDOCANYON_TOWER_PIN);
            CBPin3.Checked = _SaveFile.ReadBool(_SaveFile.GERUDOHIGHLANDS_TOWER_PIN);
            CBPin4.Checked = _SaveFile.ReadBool(_SaveFile.HYRULEFIELD_TOWER_PIN);
            CBPin5.Checked = _SaveFile.ReadBool(_SaveFile.LINDORSBROW_TOWER_PIN);
            CBPin6.Checked = _SaveFile.ReadBool(_SaveFile.LOOKOUTLANDING_TOWER_PIN);
            CBPin7.Checked = _SaveFile.ReadBool(_SaveFile.MOUNTLANAYRU_TOWER_PIN);
            CBPin8.Checked = _SaveFile.ReadBool(_SaveFile.PIKIDASTONEGROVE_TOWER_PIN);
            CBPin9.Checked = _SaveFile.ReadBool(_SaveFile.POPLAFOOTHILLS_TOWER_PIN);
            CBPin10.Checked = _SaveFile.ReadBool(_SaveFile.RABELLAWETLANDS_TOWER_PIN);
            CBPin11.Checked = _SaveFile.ReadBool(_SaveFile.ROSPROPASS_TOWER_PIN);
            CBPin12.Checked = _SaveFile.ReadBool(_SaveFile.SAHASRASLOPE_TOWER_PIN);
            CBPin13.Checked = _SaveFile.ReadBool(_SaveFile.THYPHLORUINS_TOWER_PIN);
            CBPin14.Checked = _SaveFile.ReadBool(_SaveFile.ULRIMOUNTAIN_TOWER_PIN);
            CBPin15.Checked = _SaveFile.ReadBool(_SaveFile.UPLANDZORANA_TOWER_PIN);
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

            _SaveFile.WriteArrows((int)InputArrows.Value);

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

            _SaveFile.WriteBool(_SaveFile.ELDINCANYON_MAP, CBMap1.Checked);
            _SaveFile.WriteBool(_SaveFile.GERUDOCANYON_MAP, CBMap2.Checked);
            _SaveFile.WriteBool(_SaveFile.GERUDOHIGHLANDS_MAP, CBMap3.Checked);
            _SaveFile.WriteBool(_SaveFile.HYRULEFIELD_MAP, CBMap4.Checked);
            _SaveFile.WriteBool(_SaveFile.LINDORSBROW_MAP, CBMap5.Checked);
            _SaveFile.WriteBool(_SaveFile.LOOKOUTLANDING_MAP, CBMap6.Checked);
            _SaveFile.WriteBool(_SaveFile.MOUNTLANAYRU_MAP, CBMap7.Checked);
            _SaveFile.WriteBool(_SaveFile.PIKIDASTONEGROVE_MAP, CBMap8.Checked);
            _SaveFile.WriteBool(_SaveFile.POPLAFOOTHILLS_MAP, CBMap9.Checked);
            _SaveFile.WriteBool(_SaveFile.RABELLAWETLANDS_MAP, CBMap10.Checked);
            _SaveFile.WriteBool(_SaveFile.ROSPROPASS_MAP, CBMap11.Checked);
            _SaveFile.WriteBool(_SaveFile.SAHASRASLOPE_MAP, CBMap12.Checked);
            _SaveFile.WriteBool(_SaveFile.THYPHLORUINS_MAP, CBMap13.Checked);
            _SaveFile.WriteBool(_SaveFile.ULRIMOUNTAIN_MAP, CBMap14.Checked);
            _SaveFile.WriteBool(_SaveFile.UPLANDZORANA_MAP, CBMap15.Checked);

            _SaveFile.WriteBool(_SaveFile.ELDINCANYON_TOWER_ACTIVE, CBActivated1.Checked);
            _SaveFile.WriteBool(_SaveFile.GERUDOCANYON_TOWER_ACTIVE, CBActivated2.Checked);
            _SaveFile.WriteBool(_SaveFile.GERUDOHIGHLANDS_TOWER_ACTIVE, CBActivated3.Checked);
            _SaveFile.WriteBool(_SaveFile.HYRULEFIELD_TOWER_ACTIVE, CBActivated4.Checked);
            _SaveFile.WriteBool(_SaveFile.LINDORSBROW_TOWER_ACTIVE, CBActivated5.Checked);
            _SaveFile.WriteBool(_SaveFile.LOOKOUTLANDING_TOWER_ACTIVE, CBActivated6.Checked);
            _SaveFile.WriteBool(_SaveFile.MOUNTLANAYRU_TOWER_ACTIVE, CBActivated7.Checked);
            _SaveFile.WriteBool(_SaveFile.PIKIDASTONEGROVE_TOWER_ACTIVE, CBActivated8.Checked);
            _SaveFile.WriteBool(_SaveFile.POPLAFOOTHILLS_TOWER_ACTIVE, CBActivated9.Checked);
            _SaveFile.WriteBool(_SaveFile.RABELLAWETLANDS_TOWER_ACTIVE, CBActivated10.Checked);
            _SaveFile.WriteBool(_SaveFile.ROSPROPASS_TOWER_ACTIVE, CBActivated11.Checked);
            _SaveFile.WriteBool(_SaveFile.SAHASRASLOPE_TOWER_ACTIVE, CBActivated12.Checked);
            _SaveFile.WriteBool(_SaveFile.THYPHLORUINS_TOWER_ACTIVE, CBActivated13.Checked);
            _SaveFile.WriteBool(_SaveFile.ULRIMOUNTAIN_TOWER_ACTIVE, CBActivated14.Checked);
            _SaveFile.WriteBool(_SaveFile.UPLANDZORANA_TOWER_ACTIVE, CBActivated15.Checked);

            _SaveFile.WriteBool(_SaveFile.ELDINCANYON_TOWER_PIN, CBPin1.Checked);
            _SaveFile.WriteBool(_SaveFile.GERUDOCANYON_TOWER_PIN, CBPin2.Checked);
            _SaveFile.WriteBool(_SaveFile.GERUDOHIGHLANDS_TOWER_PIN, CBPin3.Checked);
            _SaveFile.WriteBool(_SaveFile.HYRULEFIELD_TOWER_PIN, CBPin4.Checked);
            _SaveFile.WriteBool(_SaveFile.LINDORSBROW_TOWER_PIN, CBPin5.Checked);
            _SaveFile.WriteBool(_SaveFile.LOOKOUTLANDING_TOWER_PIN, CBPin6.Checked);
            _SaveFile.WriteBool(_SaveFile.MOUNTLANAYRU_TOWER_PIN, CBPin7.Checked);
            _SaveFile.WriteBool(_SaveFile.PIKIDASTONEGROVE_TOWER_PIN, CBPin8.Checked);
            _SaveFile.WriteBool(_SaveFile.POPLAFOOTHILLS_TOWER_PIN, CBPin9.Checked);
            _SaveFile.WriteBool(_SaveFile.RABELLAWETLANDS_TOWER_PIN, CBPin10.Checked);
            _SaveFile.WriteBool(_SaveFile.ROSPROPASS_TOWER_PIN, CBPin11.Checked);
            _SaveFile.WriteBool(_SaveFile.SAHASRASLOPE_TOWER_PIN, CBPin12.Checked);
            _SaveFile.WriteBool(_SaveFile.THYPHLORUINS_TOWER_PIN, CBPin13.Checked);
            _SaveFile.WriteBool(_SaveFile.ULRIMOUNTAIN_TOWER_PIN, CBPin14.Checked);
            _SaveFile.WriteBool(_SaveFile.UPLANDZORANA_TOWER_PIN, CBPin15.Checked);

            _SaveFile.PatchSaveFile();

            MessageBox.Show("Successfully patched savefile!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetAllCheckboxes(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            bool value = btn.Name == "BtnCheckAll";

            CBMap1.Checked = value;
            CBMap2.Checked = value;
            CBMap3.Checked = value;
            CBMap4.Checked = value;
            CBMap5.Checked = value;
            CBMap6.Checked = value;
            CBMap7.Checked = value;
            CBMap8.Checked = value;
            CBMap9.Checked = value;
            CBMap10.Checked = value;
            CBMap11.Checked = value;
            CBMap12.Checked = value;
            CBMap13.Checked = value;
            CBMap14.Checked = value;
            CBMap15.Checked = value;
            CBActivated15.Checked = value;
            CBActivated14.Checked = value;
            CBActivated13.Checked = value;
            CBActivated12.Checked = value;
            CBActivated11.Checked = value;
            CBActivated10.Checked = value;
            CBActivated9.Checked = value;
            CBActivated8.Checked = value;
            CBActivated7.Checked = value;
            CBActivated6.Checked = value;
            CBActivated5.Checked = value;
            CBActivated4.Checked = value;
            CBActivated3.Checked = value;
            CBActivated2.Checked = value;
            CBActivated1.Checked = value;
            CBPin15.Checked = value;
            CBPin14.Checked = value;
            CBPin13.Checked = value;
            CBPin12.Checked = value;
            CBPin11.Checked = value;
            CBPin10.Checked = value;
            CBPin9.Checked = value;
            CBPin8.Checked = value;
            CBPin7.Checked = value;
            CBPin6.Checked = value;
            CBPin5.Checked = value;
            CBPin4.Checked = value;
            CBPin3.Checked = value;
            CBPin2.Checked = value;
            CBPin1.Checked = value;
        }
    }
}
