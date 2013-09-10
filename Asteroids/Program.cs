using System;
using System.Windows.Forms;

namespace Asteroids
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

            string message = "Начать игру?";
            var canResum = MessageBox.Show(message, "Start", MessageBoxButtons.YesNo);
            if (canResum == DialogResult.Yes)
            {

                string supportMessage =
                    "Управление: движение - стрелки, стрелять - пробел, лазер - ц, смена представления - п.";
                MessageBox.Show(supportMessage, "Control");

                Asteroids newForm = new Asteroids();

                Application.Run(newForm);
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
