﻿using BLL;
using BLL.Interfaces;
using DIApp.Util;
using Magazin;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakery
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // внедрение зависимостей
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("MagazinContext"));

            IDbCrud crudServ = kernel.Get<IDbCrud>();
            IPokypkiService otchetsServ = kernel.Get<IPokypkiService>();
            IOtchetService pokypkaServ = kernel.Get<IOtchetService>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(crudServ, otchetsServ, pokypkaServ));
        }
    }
}
