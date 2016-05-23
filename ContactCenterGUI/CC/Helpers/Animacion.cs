using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace ContactCenterGUI.CC.Helpers
{
    class Animacion
    {
        private static int loaderHeight = 80;
        private static int loaderWidth = 72;


        public static void ShowLoader(Form form)
        {
            PictureBox pictureBox = (PictureBox)form.Controls.Find("loader", true).ElementAtOrDefault(0);
            if (pictureBox == null)
            {
                int coordenadaX = form.Width / 2;
                int coordenadaY = form.Height / 2;

                pictureBox = new PictureBox();
                pictureBox.Image = Properties.Resources.loading;
                pictureBox.BackColor = Color.Transparent;
                pictureBox.Location = new Point(coordenadaX - loaderWidth/2, coordenadaY - loaderHeight/2);
                pictureBox.Name = "loader";
                pictureBox.Size = new Size(loaderHeight, loaderHeight);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                form.Controls.Add(pictureBox);
                pictureBox.BringToFront();
            }
            else
            {
                pictureBox.Show();
            }

        }
        public static void HideLoader(Form form)
        {
            PictureBox pictureBox = (PictureBox)form.Controls.Find("loader", true).ElementAtOrDefault(0);
            form.Controls.Remove(pictureBox);
        }
    }
}
