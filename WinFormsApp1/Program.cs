using Daddysanka.UI;
using DaddysLanka.UI;


namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
           /* ApplicationConfiguration.Initialize();

            using (var loginForm = new FrmLogin())  
            {  
                // Show login form as dialog  
                if (loginForm.ShowDialog() == DialogResult.OK)  
                {  

                }  
            } */

            Application.Run(new FrmBooking()); 
        }
    }
}