using DormitoryManagementSystem.GUI.Forms;
using System;
using System.Windows.Forms;

namespace DormitoryManagementSystem.GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}
