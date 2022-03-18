using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace Calculator.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new Calculator.App(), args);
            host.Run();
        }
    }
}
