﻿namespace SpaceShooter.gui
{
    public class GamePausedPanel : Panel
    {
        private const float gameOverLabelHeightRatio = 1.5f;

        private GameForm gameForm;

        public GamePausedPanel(Control parent, GameForm gameForm, EventHandler onGameResume)
        {
            Parent = parent;
            this.gameForm = gameForm;

            Width = Parent.Width;
            Height = Parent.Height;
            BackColor = Color.FromArgb(255, 40, 40, 40);

            GameMessageLabel gamePausedLbl = new GameMessageLabel(this, "Duraklat")
            {
                ForeColor = Color.White
            };
            gamePausedLbl.Top = Parent.ClientRectangle.Height / 2 - (int)(gameOverLabelHeightRatio * gamePausedLbl.Height);

            PauseMenuButton resumeBtn = new PauseMenuButton(this, "Sürdür")
            {
                Top = gamePausedLbl.Top + gamePausedLbl.Height + 20
            };
            resumeBtn.Click += onGameResume;

            PauseMenuButton optionsBtn = new PauseMenuButton(this, "Seçenekler")
            {
                Top = resumeBtn.Top + resumeBtn.Height + 20,
            };
            optionsBtn.Click += AppManager.OnPauseMenuOptionOptionsClick;

            PauseMenuButton quitBtn = new PauseMenuButton(this, "Çıkış")
            {
                Top = optionsBtn.Top + optionsBtn.Height + 20,
            };
            quitBtn.Click += onQuitButtonClick;

            BringToFront();
            Hide();
        }

        private void onQuitButtonClick(object? sender, EventArgs e) => gameForm.Close();
    }
}
