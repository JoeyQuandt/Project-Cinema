using Newtonsoft.Json;
using System;

namespace Bioscoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            data.LoadUsers();
            //Menu menu = new Menu();
            //menu.menu();
        }
    }
}
