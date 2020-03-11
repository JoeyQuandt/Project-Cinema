using Newtonsoft.Json;
using System;

namespace Bioscoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            data.LoadActors();
            //Menu menu = new Menu();
            //menu.menu();
        }
    }
}
