﻿namespace SpaceShooter.gui
{
    public class StatsBar : Panel
    {
        private const int labelMargin = 10;
        private const float scoreLabelMarginRatio = 0.05f;

        public StatsLabel WaveLabel { get; private init; }
        public StatsLabel ScoreLabel { get; private init; }
        public StatsLabel ElapsedTimeLabel { get; private init; }

        public StatsBar(Control parent, int width, int height) 
        {
            Parent = parent;
            Width = width;
            Height = height;

            BackColor = Color.FromArgb(255, 40, 40, 40);

            WaveLabel = new StatsLabel(this, "Süre");
            ScoreLabel = new StatsLabel(this, "Skor");
            ElapsedTimeLabel = new StatsLabel(this, "Geçen Süre", "00:00:00");

            WaveLabel.Location = new Point(labelMargin, Height / 2 - WaveLabel.Height / 2);
            ScoreLabel.Location = new Point(WaveLabel.Left + WaveLabel.Width + (int)(scoreLabelMarginRatio * Width), Height / 2 - ScoreLabel.Height / 2);
            ElapsedTimeLabel.Location = new Point(Width - ElapsedTimeLabel.Width - labelMargin, Height / 2 - ScoreLabel.Height / 2);
        }
    }
}
