using System;
using System.Windows.Forms;
using TextEditor.BL;

namespace TextEditor
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            MessgaService service = new MessgaService();
            FileManager manager = new FileManager();

            MainPresentor presenter = new MainPresentor(form,manager,service);

            Application.Run(form);
        }
    }
}
