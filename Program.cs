﻿using System;
using System.Windows.Forms;

namespace GameTimeConverter
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameTimeConverterForm());
        }
    }
}
