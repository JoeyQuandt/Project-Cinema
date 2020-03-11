using System;

namespace Bioscoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = menu.MainMenu();
                
            }
        }
        //Menu waarbij je 4 keuze opties hebt. Je kan een optie kiezen door te typen
    }
}
