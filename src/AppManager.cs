﻿using SpaceShooter.gui;
using SpaceShooter.resources;
using SpaceShooter.utils;
using static SpaceShooter.utils.CustomExceptions;

namespace SpaceShooter
{
    internal static class AppManager
    {
        private static MenuForm menuForm = new MenuForm();

        public static void Start() => Application.Run(menuForm);

        public static void OnMenuOptionPlayClick(object? sender, EventArgs e) 
        {
            menuForm.Hide();
            GameManager.StartNewGame();
        }

        public static void OnMenuOptionHighscoresClick(object? sender, EventArgs e)
        {
            menuForm.Hide();
            new HighscoresForm().Show();
        }

        public static void OnMenuOptionOptionsClick(object? sender, EventArgs e)
        {
            menuForm.Hide();
            new OptionsForm().Show();
        }

        public static void OnMenuOptionAboutClick(object? sender, EventArgs e)
        {
            menuForm.Hide();
            new AboutForm().Show();
        }

        public static void OnPauseMenuOptionOptionsClick(object? sender, EventArgs e)
        {
            new OptionsForm(true).ShowDialog();
        }

        public static void OnSubFormClosed(object? sender, EventArgs e) => menuForm.Show();

        public static void InitAudioPlayer()
        {
            AudioPlayer.Player.SetBackgroundMusic(Resources.aud_background_music);

            try
            {
                if (DatabaseManager.GetOptionValue("Müzik"))
                    AudioPlayer.Player.PlayBackgroundMusic();
            }
            catch (EntryNotFoundException)
            {
                AudioPlayer.Player.PlayBackgroundMusic();
            }

            try
            {
                if (DatabaseManager.GetOptionValue("Efekt"))
                    AudioPlayer.Player.ActivateOutputDevice();
            }
            catch (EntryNotFoundException)
            {
                AudioPlayer.Player.ActivateOutputDevice();
            }
        }
    }
}
