using System.Drawing;
using System.Windows.Forms;


public class TransparentRichTextBox : RichTextBox
{
    public TransparentRichTextBox()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        // Do not paint the background
    }
}