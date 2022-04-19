using DemoApp.UI;
using System;

namespace DempApp.ConApp
{
    class Program
    {
        // Fields


        // Constructors


        // Methods
        static async Task Main(string[] args)
        {

            Uri uri = new Uri("https://localhost:7266");

            IO io = new IO(uri);

            await io.BeginAsync();



        }
    }
}