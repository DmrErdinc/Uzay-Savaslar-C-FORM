namespace SpaceShooter.gui
{
    public class OKButton : CustomButton
    {
        public OKButton(Control parent, float parentWidthRatio, float parentHeightRatio) : base(parent, "TAMAM", parentWidthRatio, parentHeightRatio)
        {
            Left = Parent.ClientRectangle.Width / 2 - Width / 2;
            Click += (sender, e) => ((Form)Parent).Close();
        }
    }
}
