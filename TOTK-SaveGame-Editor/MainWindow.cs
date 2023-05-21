using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TOTK_SaveGame_Editor.Data;

namespace TOTK_SaveGame_Editor
{
    public partial class MainWindow : Form
    {
        private TOTK_SaveFile _SaveFile;

        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxes();

            Size = new Size(351, 260);
            TabControlValues.Enabled = false;
        }

        private void OpenSaveFile(object sender, EventArgs e)
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

            TabControlValues.Enabled = true;

            SetValuesFromSavefile();
        }

        private void CloseSaveFile(object sender, EventArgs e)
        {
            LblPath.Text = "progress.sav";
            _SaveFile = null;

            BtnOpenSaveFile.Enabled = true;
            BtnPatchSaveFile.Enabled = false;
            BtnReset.Enabled = false;

            TabControlValues.Enabled = false;
        }

        private void SetComboIndex(ComboBox comboBox, string value)
        {
            var index = comboBox.Items.IndexOf(value);
            if (index == -1) return;

            comboBox.SelectedIndex = index;
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
                    Size = new Size(458, 341);
                    break;
                case 2:
                    Size = new Size(458, 341);
                    break;
                case 3:
                    Size = new Size(458, 341);
                    break;
                case 4:
                    Size = new Size(458, 341);
                    break;
                case 5:
                    Size = new Size(351, 541);
                    break;
            }
        }

        private void FillComboBoxes()
        {
            ComboSwords.Items.Clear();
            ComboBows.Items.Clear();
            ComboShields.Items.Clear();           
            ComboArmor.Items.Clear();

            ComboSwordModifier.Items.Clear();
            ComboBowModifier.Items.Clear();
            ComboShieldModifier.Items.Clear();

            ComboSwords.Items.AddRange(GameData.Swords.Values.ToArray());          
            ComboBows.Items.AddRange(GameData.Bows.Values.ToArray());                 
            ComboShields.Items.AddRange(GameData.Shields.Values.ToArray());                     
            ComboArmor.Items.AddRange(GameData.Armor.Values.ToArray());

            ComboSwordModifier.Items.AddRange(GameData.Modifiers.Values.ToArray());
            ComboBowModifier.Items.AddRange(GameData.Modifiers.Values.ToArray());
            ComboShieldModifier.Items.AddRange(GameData.Modifiers.Values.ToArray());
        }

        private void SetValuesFromSavefile()
        {
            InputRupees.Value = _SaveFile.Rupees;
            InputHearts.Value = _SaveFile.Hearts;
            InputStamina.Value = _SaveFile.Stamina;

            InputSwordPouch.Value = _SaveFile.PouchSizeSwords;
            InputBowPouch.Value = _SaveFile.PouchSizeBows;
            InputShieldPouch.Value = _SaveFile.PouchSizeShields;

            InputArrows.Value = _SaveFile.Arrows;

            ListBoxSwords.Items.Clear();
            ListBoxBows.Items.Clear();
            ListBoxShields.Items.Clear();
            ListBoxArmor.Items.Clear();

            ListBoxSwords.Items.AddRange(_SaveFile.Swords.Select(item => item.Name).ToArray());
            ListBoxBows.Items.AddRange(_SaveFile.Bows.Select(item => item.Name).ToArray());
            ListBoxShields.Items.AddRange(_SaveFile.Shields.Select(item => item.Name).ToArray());
            ListBoxArmor.Items.AddRange(_SaveFile.Armor.Select(item => item.Name).ToArray());

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

            foreach (CheckBox checkbox in TabSkyviewTowers.Controls.OfType<CheckBox>())
            {
                checkbox.Checked = value;
            }
        }


        #region SwordSelector

        private void OnSelectSword(object sender, EventArgs e)
        {
            if (ListBoxSwords.SelectedIndex < 0 || ListBoxSwords.SelectedIndex >= _SaveFile.Swords.Count)
            {
                return;
            }

            var selectedSword = _SaveFile.Swords[ListBoxSwords.SelectedIndex];

            SetComboIndex(ComboSwords, selectedSword.Name);
            SetComboIndex(ComboSwordModifier, selectedSword.Modifier);

            InputSwordDurability.Value = selectedSword.Durability;
        }

        private void OnSelectSwordItem(object sender, EventArgs e)
        {
            if (ListBoxSwords.SelectedIndex < 0 || ListBoxSwords.SelectedIndex >= _SaveFile.Swords.Count)
            {
                return;
            }

            _SaveFile.Swords[ListBoxSwords.SelectedIndex].Name = GameData.Swords.Values.ToArray()[ComboSwords.SelectedIndex];
            _SaveFile.Swords[ListBoxSwords.SelectedIndex].Id = GameData.Swords.Keys.ToArray()[ComboSwords.SelectedIndex];

            UpdateSwordListBox();
        }

        private void OnSelectSwordModifier(object sender, EventArgs e)
        {
            if (ListBoxSwords.SelectedIndex < 0 || ListBoxSwords.SelectedIndex >= _SaveFile.Swords.Count)
            {
                return;
            }

            _SaveFile.Swords[ListBoxSwords.SelectedIndex].Modifier = GameData.Modifiers.Values.ToArray()[ComboSwordModifier.SelectedIndex];
        }

        private void OnSelectSwordDurability(object sender, EventArgs e)
        {
            if (ListBoxSwords.SelectedIndex < 0 || ListBoxSwords.SelectedIndex >= _SaveFile.Swords.Count)
            {
                return;
            }

            _SaveFile.Swords[ListBoxSwords.SelectedIndex].Durability = (int)InputSwordDurability.Value;
        }

        private void UpdateSwordListBox()
        {
            var index = ListBoxSwords.SelectedIndex;

            ListBoxSwords.Items.Clear();
            ListBoxSwords.Items.AddRange(_SaveFile.Swords.Select(item => item.Name).ToArray());

            ListBoxSwords.SelectedIndex = index;
        }

        private void AddSword(object sender, EventArgs e)
        {
            _SaveFile.Swords.Add(new Sword("Weapon_Sword_070", 1000, 0xB6EEDE09));
            UpdateSwordListBox();
            ListBoxSwords.SelectedIndex = ListBoxSwords.Items.Count - 1;
            OnSelectSword(null, null);
        }

        private void DeleteSword(object sender, EventArgs e)
        {
            if (ListBoxSwords.SelectedIndex < 0 || ListBoxSwords.SelectedIndex >= _SaveFile.Swords.Count)
            {
                return;
            }

            _SaveFile.Swords.RemoveAt(ListBoxSwords.SelectedIndex);

            ListBoxSwords.SelectedIndex--;

            UpdateSwordListBox();
            OnSelectSword(null, null);
        }

        #endregion

        #region BowSelector

        private void OnSelectBow(object sender, EventArgs e)
        {
            if (ListBoxBows.SelectedIndex < 0 || ListBoxBows.SelectedIndex >= _SaveFile.Bows.Count)
            {
                return;
            }

            var selectedBow = _SaveFile.Bows[ListBoxBows.SelectedIndex];

            SetComboIndex(ComboBows, selectedBow.Name);
            SetComboIndex(ComboBowModifier, selectedBow.Modifier);

            InputBowDurability.Value = selectedBow.Durability;
        }

        private void OnSelectBowItem(object sender, EventArgs e)
        {
            if (ListBoxBows.SelectedIndex < 0 || ListBoxBows.SelectedIndex >= _SaveFile.Bows.Count)
            {
                return;
            }

            _SaveFile.Bows[ListBoxBows.SelectedIndex].Name = GameData.Bows.Values.ToArray()[ComboBows.SelectedIndex];
            _SaveFile.Bows[ListBoxBows.SelectedIndex].Id = GameData.Bows.Keys.ToArray()[ComboBows.SelectedIndex];

            UpdateBowListBox();
        }

        private void OnSelectBowModifier(object sender, EventArgs e)
        {
            if (ListBoxBows.SelectedIndex < 0 || ListBoxBows.SelectedIndex >= _SaveFile.Bows.Count)
            {
                return;
            }

            _SaveFile.Bows[ListBoxBows.SelectedIndex].Modifier = GameData.Modifiers.Values.ToArray()[ComboBowModifier.SelectedIndex];
        }

        private void OnSelectBowDurability(object sender, EventArgs e)
        {
            if (ListBoxBows.SelectedIndex < 0 || ListBoxBows.SelectedIndex >= _SaveFile.Bows.Count)
            {
                return;
            }

            _SaveFile.Bows[ListBoxBows.SelectedIndex].Durability = (int)InputBowDurability.Value;
        }

        private void UpdateBowListBox()
        {
            var index = ListBoxBows.SelectedIndex;

            ListBoxBows.Items.Clear();
            ListBoxBows.Items.AddRange(_SaveFile.Bows.Select(item => item.Name).ToArray());

            ListBoxBows.SelectedIndex = index;
        }

        private void AddBow(object sender, EventArgs e)
        {
            _SaveFile.Bows.Add(new Bow("Weapon_Bow_166", 1000, 0xB6EEDE09));
            UpdateBowListBox();
            ListBoxBows.SelectedIndex = ListBoxBows.Items.Count - 1;
            OnSelectBow(null, null);
        }

        private void DeleteBow(object sender, EventArgs e)
        {
            if (ListBoxBows.SelectedIndex < 0 || ListBoxBows.SelectedIndex >= _SaveFile.Bows.Count)
            {
                return;
            }

            _SaveFile.Bows.RemoveAt(ListBoxBows.SelectedIndex);

            ListBoxBows.SelectedIndex--;

            UpdateBowListBox();
            OnSelectBow(null, null);
        }

        #endregion

        #region ShieldSelector

        private void OnSelectShield(object sender, EventArgs e)
        {
            if (ListBoxShields.SelectedIndex < 0 || ListBoxShields.SelectedIndex >= _SaveFile.Shields.Count)
            {
                return;
            }

            var selectedShield = _SaveFile.Shields[ListBoxShields.SelectedIndex];

            SetComboIndex(ComboShields, selectedShield.Name);
            SetComboIndex(ComboShieldModifier, selectedShield.Modifier);

            InputShieldDurability.Value = selectedShield.Durability;
        }

        private void OnSelectShieldItem(object sender, EventArgs e)
        {
            if (ListBoxShields.SelectedIndex < 0 || ListBoxShields.SelectedIndex >= _SaveFile.Shields.Count)
            {
                return;
            }

            _SaveFile.Shields[ListBoxShields.SelectedIndex].Name = GameData.Shields.Values.ToArray()[ComboShields.SelectedIndex];
            _SaveFile.Shields[ListBoxShields.SelectedIndex].Id = GameData.Shields.Keys.ToArray()[ComboShields.SelectedIndex];

            UpdateShieldListBox();
        }

        private void OnSelectShieldModifier(object sender, EventArgs e)
        {
            if (ListBoxShields.SelectedIndex < 0 || ListBoxShields.SelectedIndex >= _SaveFile.Shields.Count)
            {
                return;
            }

            _SaveFile.Shields[ListBoxShields.SelectedIndex].Modifier = GameData.Modifiers.Values.ToArray()[ComboShieldModifier.SelectedIndex];
        }

        private void OnSelectShieldDurability(object sender, EventArgs e)
        {
            if (ListBoxShields.SelectedIndex < 0 || ListBoxShields.SelectedIndex >= _SaveFile.Shields.Count)
            {
                return;
            }

            _SaveFile.Shields[ListBoxShields.SelectedIndex].Durability = (int)InputShieldDurability.Value;
        }

        private void UpdateShieldListBox()
        {
            var index = ListBoxShields.SelectedIndex;

            ListBoxShields.Items.Clear();
            ListBoxShields.Items.AddRange(_SaveFile.Shields.Select(item => item.Name).ToArray());

            ListBoxShields.SelectedIndex = index;
        }

        private void AddShield(object sender, EventArgs e)
        {
            _SaveFile.Shields.Add(new Shield("Weapon_Shield_030", 1000, 0xB6EEDE09));
            UpdateShieldListBox();
            ListBoxShields.SelectedIndex = ListBoxShields.Items.Count - 1;
            OnSelectShield(null, null);
        }

        private void DeleteShield(object sender, EventArgs e)
        {
            if (ListBoxShields.SelectedIndex < 0 || ListBoxShields.SelectedIndex >= _SaveFile.Shields.Count)
            {
                return;
            }

            _SaveFile.Shields.RemoveAt(ListBoxShields.SelectedIndex);

            ListBoxShields.SelectedIndex--;

            UpdateShieldListBox();
            OnSelectShield(null, null);
        }

        #endregion

        #region ArmorSelector

        private void OnSelectArmor(object sender, EventArgs e)
        {
            if (ListBoxArmor.SelectedIndex < 0 || ListBoxArmor.SelectedIndex >= _SaveFile.Armor.Count)
            {
                return;
            }

            var selectedArmor = _SaveFile.Armor[ListBoxArmor.SelectedIndex];

            SetComboIndex(ComboArmor, selectedArmor.Name);
        }

        private void OnSelectArmorItem(object sender, EventArgs e)
        {
            if (ListBoxArmor.SelectedIndex < 0 || ListBoxArmor.SelectedIndex >= _SaveFile.Armor.Count)
            {
                return;
            }

            _SaveFile.Armor[ListBoxArmor.SelectedIndex].Name = GameData.Armor.Values.ToArray()[ComboArmor.SelectedIndex];
            _SaveFile.Armor[ListBoxArmor.SelectedIndex].Id = GameData.Armor.Keys.ToArray()[ComboArmor.SelectedIndex];

            UpdateArmorListBox();
        }

        private void UpdateArmorListBox()
        {
            var index = ListBoxArmor.SelectedIndex;

            ListBoxArmor.Items.Clear();
            ListBoxArmor.Items.AddRange(_SaveFile.Armor.Select(item => item.Name).ToArray());

            ListBoxArmor.SelectedIndex = index;
        }

        private void AddArmor(object sender, EventArgs e)
        {
            _SaveFile.Armor.Add(new Armor("Armor_1086_Head"));
            UpdateArmorListBox();
            ListBoxArmor.SelectedIndex = ListBoxArmor.Items.Count - 1;
            OnSelectArmor(null, null);
        }

        private void DeleteArmor(object sender, EventArgs e)
        {
            if (ListBoxArmor.SelectedIndex < 0 || ListBoxArmor.SelectedIndex >= _SaveFile.Armor.Count)
            {
                return;
            }

            _SaveFile.Armor.RemoveAt(ListBoxArmor.SelectedIndex);

            ListBoxArmor.SelectedIndex--;

            UpdateArmorListBox();
            OnSelectArmor(null, null);
        }

        #endregion

        private void OnRupeesChanged(object sender, EventArgs e)
        {
            _SaveFile.Rupees = (int)InputRupees.Value;
        }

        private void OnHeartsChanged(object sender, EventArgs e)
        {
            _SaveFile.Hearts = (int)InputHearts.Value;
        }

        private void OnStaminaChanged(object sender, EventArgs e)
        {
            _SaveFile.Stamina = (int)InputStamina.Value;
        }

        private void OnSwordPouchChanged(object sender, EventArgs e)
        {
            _SaveFile.PouchSizeSwords = (int)InputSwordPouch.Value;
        }

        private void OnBowPouchChanged(object sender, EventArgs e)
        {
            _SaveFile.PouchSizeBows = (int)InputBowPouch.Value;
        }

        private void OnShieldPouchChanged(object sender, EventArgs e)
        {
            _SaveFile.PouchSizeShields = (int)InputShieldPouch.Value;
        }

        private void OnArrowsChanged(object sender, EventArgs e)
        {
            _SaveFile.Arrows = (int)InputArrows.Value;
        }
    }
}
