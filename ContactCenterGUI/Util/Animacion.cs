using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterServices;
using Microsoft.Practices.Unity;
using ContactCenterGUI.Util;

namespace ContactCenterGUI.Util
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
                pictureBox.Image = ContactCenterGUI.Properties.Resources.loading;
                pictureBox.BackColor = System.Drawing.Color.Transparent;
                pictureBox.Location = new System.Drawing.Point(coordenadaX - loaderWidth/2, coordenadaY - loaderHeight/2);
                pictureBox.Name = "loader";
                pictureBox.Size = new System.Drawing.Size(loaderHeight, loaderHeight);
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            PictureBox pictureBox = (PictureBox)form.Controls.Find("loader", true).ElementAt(0);
            form.Controls.Remove(pictureBox);
        }
    }
}
