using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

/// <summary>
/// This is an open source project created by Kumar, Ravikant <see cref="https://www.codeproject.com/Articles/56410/NET-Resource-resx-file-Translator"/>
/// This program is a .NET resource (.resx file) translator. Your language to any other language.
/// </summary>
namespace ResxTranslator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
