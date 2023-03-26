using System;
using Kakao.Settings;

namespace Kakao
{
    internal class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            _ = new App()
                .AddInversionModule<ViewModuels>()
                .AddInversionModule<DirectModules>()
                .AddWireDataContext<WireDataContext>()
                .Run();
        }
    }
}
