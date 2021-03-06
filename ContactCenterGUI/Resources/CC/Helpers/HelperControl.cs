﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MaterialSkin.Controls;
using System.ComponentModel;


namespace ContactCenterGUI.CC.Helpers
{
    class HelperControl
    {
        public static void EditTextToUpper(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar.ToString().ToUpper()[0];
            e.KeyChar = letra;
        }
        public static void EditTextNumber(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
        public static void EditTextDecimal(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Contains(".") && e.KeyChar == 46)
            {
                e.Handled = true;
                return;
            }
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }
        public static void ValidEmail(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string email = txt.Text;

            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (email.ToUpper().Trim().Equals(String.Empty))
            {}
            else
            {
                if (Regex.IsMatch(email, expresion))
                {
                    if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Ingrese correo correctamente");
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese correo correctamente");
                    e.Cancel = true;
                }
            }
        }
    }
}
