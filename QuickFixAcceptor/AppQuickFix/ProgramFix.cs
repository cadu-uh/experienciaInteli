using QuickFix;
using System;

namespace AppQuickFix
{
    class ProgramFix
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                SessionSettings settings = new SessionSettings(@"C:\Users\carlo\Downloads\quickfixn-v1.10.0\config\sample_acceptor.cfg");
                IApplication myApp = new MyAplicationQuickFix();
                IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
                ILogFactory logFactory = new FileLogFactory(settings);
                ThreadedSocketAcceptor acceptor = new(myApp, storeFactory, settings, logFactory);

                acceptor.Start();
                Console.WriteLine("press <enter> to quit");
                Console.Read();
                acceptor.Stop();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("==Fatal Error==");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
