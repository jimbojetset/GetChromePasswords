﻿using System;
using System.Reflection;
using System.Windows.Forms;

namespace GetChromePasswords
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            string resource = "GetChromePasswords.System.Data.SQLite.dll";
            string resource2 = "GetChromePasswords.ObjectListView.dll";
            EmbeddedAssembly.Load(resource, "System.Data.SQLite.dll");
            EmbeddedAssembly.Load(resource2, "ObjectListView.dll");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }
}