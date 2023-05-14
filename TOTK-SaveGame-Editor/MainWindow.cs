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

        private void BtnCheckAll_Click(object sender, EventArgs e)
        {
            CBMap1.Checked = true;
            CBMap2.Checked = true;
            CBMap3.Checked = true;
            CBMap4.Checked = true;
            CBMap5.Checked = true;
            CBMap6.Checked = true;
            CBMap7.Checked = true;
            CBMap8.Checked = true;
            CBMap9.Checked = true;
            CBMap10.Checked = true;
            CBMap11.Checked = true;
            CBMap12.Checked = true;
            CBMap13.Checked = true;
            CBMap14.Checked = true;
            CBMap15.Checked = true;
            CBActivated15.Checked = true;
            CBActivated14.Checked = true;
            CBActivated13.Checked = true;
            CBActivated12.Checked = true;
            CBActivated11.Checked = true;
            CBActivated10.Checked = true;
            CBActivated9.Checked = true;
            CBActivated8.Checked = true;
            CBActivated7.Checked = true;
            CBActivated6.Checked = true;
            CBActivated5.Checked = true;
            CBActivated4.Checked = true;
            CBActivated3.Checked = true;
            CBActivated2.Checked = true;
            CBActivated1.Checked = true;
            CBPin15.Checked = true;
            CBPin14.Checked = true;
            CBPin13.Checked = true;
            CBPin12.Checked = true;
            CBPin11.Checked = true;
            CBPin10.Checked = true;
            CBPin9.Checked = true;
            CBPin8.Checked = true;
            CBPin7.Checked = true;
            CBPin6.Checked = true;
            CBPin5.Checked = true;
            CBPin4.Checked = true;
            CBPin3.Checked = true;
            CBPin2.Checked = true;
            CBPin1.Checked = true;
        }
        private void BtnUncheckAll_Click(object sender, EventArgs e)
        {
            CBMap1.Checked = false;
            CBMap2.Checked = false;
            CBMap3.Checked = false;
            CBMap4.Checked = false;
            CBMap5.Checked = false;
            CBMap6.Checked = false;
            CBMap7.Checked = false;
            CBMap8.Checked = false;
            CBMap9.Checked = false;
            CBMap10.Checked = false;
            CBMap11.Checked = false;
            CBMap12.Checked = false;
            CBMap13.Checked = false;
            CBMap14.Checked = false;
            CBMap15.Checked = false;
            CBActivated15.Checked = false;
            CBActivated14.Checked = false;
            CBActivated13.Checked = false;
            CBActivated12.Checked = false;
            CBActivated11.Checked = false;
            CBActivated10.Checked = false;
            CBActivated9.Checked = false;
            CBActivated8.Checked = false;
            CBActivated7.Checked = false;
            CBActivated6.Checked = false;
            CBActivated5.Checked = false;
            CBActivated4.Checked = false;
            CBActivated3.Checked = false;
            CBActivated2.Checked = false;
            CBActivated1.Checked = false;
            CBPin15.Checked = false;
            CBPin14.Checked = false;
            CBPin13.Checked = false;
            CBPin12.Checked = false;
            CBPin11.Checked = false;
            CBPin10.Checked = false;
            CBPin9.Checked = false;
            CBPin8.Checked = false;
            CBPin7.Checked = false;
            CBPin6.Checked = false;
            CBPin5.Checked = false;
            CBPin4.Checked = false;
            CBPin3.Checked = false;
            CBPin2.Checked = false;
            CBPin1.Checked = false;
        }
    }
}
