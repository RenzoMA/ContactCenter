using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ContactCenterGUI.CC.Helpers
{
    class HelperForm
    {
        public static void changeForm(string formName, string aplicacion, bool hide,Form form, object parametro = null)
        {
            Type CAType = Type.GetType("ContactCenterGUI." + formName);
            if (CAType != null)
            {
                if (hide) form.Hide();
                Form nextForm2 = (Form)Activator.CreateInstance(CAType);
                nextForm2.Tag = parametro;
                nextForm2.ShowDialog();
                if (hide) form.Show();
            }
            else
            {
                MessageBox.Show("Formulario no encontrado");
            }
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
