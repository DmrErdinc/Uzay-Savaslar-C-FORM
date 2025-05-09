﻿using SpaceShooter.resources;
using SpaceShooter.utils;

namespace SpaceShooter.gui
{
    public partial class OptionsForm : CustomForm
    {
        private const float okBtnHeightRatio = 0.05f;
        private const float okBtnWidthRatio = 0.17f;
        private const float marginRatio = 0.02f;

        private readonly Dictionary<string, List<(Bitmap, Size)>> pictureBoxOptionDetails = new Dictionary<string, List<(Bitmap, Size)>>
        {
            { "Uzay Gemisi Hareketi", new List<(Bitmap, Size)>() { (Resources.img_arrow_keys, new Size(80, 50)), (Resources.img_wasd_keys, new Size(80, 50)) } },
            { "Ateşli Lazer Blaster", new List<(Bitmap, Size)>() { (Resources.img_space_key, new Size(35, 35)), (Resources.img_e_key, new Size(35, 35)) } },
            { "Oyunu Duraklat/Devam Ettir", new List<(Bitmap, Size)>() { (Resources.img_esc_key, new Size(35, 35)), (Resources.img_p_key, new Size(35, 35)) } }
        };

        private readonly List<(string, Action, Action)> audioOptionDetails = new List<(string, Action, Action)>()
        {
            ("Müzik", AudioPlayer.Player.PlayBackgroundMusic, AudioPlayer.Player.StopBackgroundMusic),
            ("Efekt", AudioPlayer.Player.ActivateOutputDevice, AudioPlayer.Player.MuteOutputDevice)
        };

        private List<PictureBoxOptionsGroup> pictureBoxOptionGroups;
        private CheckBoxOptionsGroup audioOptions;

        public OptionsForm(bool isPauseMenuInstance = false)
        {
            InitializeComponent();
            setBackgroundImage();

            if (isPauseMenuInstance)
                FormClosed -= AppManager.OnSubFormClosed;

            FormTitleLabel titleLabel = new FormTitleLabel(this, new string(' ', 5) + "OPTIONS" + new string(' ', 5));

            pictureBoxOptionGroups = new List<PictureBoxOptionsGroup>();

            foreach (var entry in pictureBoxOptionDetails)
            {
                int initY = (pictureBoxOptionGroups.Count == 0 ? titleLabel.Top + titleLabel.Height : pictureBoxOptionGroups.Last().Top + pictureBoxOptionGroups.Last().Height);
                PictureBoxOptionsGroup newPictureBoxOptionsGroup = new PictureBoxOptionsGroup(this, entry.Key, entry.Value)
                {
                    Top = initY + (int)(Height * marginRatio)
                };
                pictureBoxOptionGroups.Add(newPictureBoxOptionsGroup);
            }

            audioOptions = new CheckBoxOptionsGroup(this, "Ses", audioOptionDetails)
            {
                Top = pictureBoxOptionGroups.Last().Top + pictureBoxOptionGroups.Last().Height + (int)(Height * marginRatio),
            };

            OKButton okBtn = new OKButton(this, okBtnWidthRatio, okBtnHeightRatio)
            {
                Top = audioOptions.Top + audioOptions.Height + (int)(Height * marginRatio),
            };

            FormClosing += onFormClosing;
        }

        private void onFormClosing(object? sender, EventArgs e)
        {
            foreach (var pictureBoxOptionGroup in pictureBoxOptionGroups)
                pictureBoxOptionGroup.DisposePictureBoxes();

            Task.Run(() => storeOptions());
        }

        private void storeOptions()
        {
            Dictionary<string, bool> selected = audioOptions.getSelected();
            foreach (var option in selected)
                DatabaseManager.AddOrUpdateOptionEntry(option.Key, option.Value);
        }
    }
}
