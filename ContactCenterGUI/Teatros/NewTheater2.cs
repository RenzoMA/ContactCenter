﻿using System;
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
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterGUI.Util;


namespace ContactCenterGUI.Teatros
{
    public partial class NewTheater2 : MaterialForm
    {
        public int idTeatro = 1;
        public int idFuncion = 1;
        public int idObra = 1;

        public NewTheater2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void NewTheater2_Load(object sender, EventArgs e)
        {
            AsientoUtil.CruzarBotonData(null, this);
        }
    }
}
