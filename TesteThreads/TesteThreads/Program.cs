using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace UsandoThreads_3
{
    class Program
    {
        bool ok;

        static void Main(string[] args)
        {
            // Cria uma instância comum
            Program tt = new Program();
            //inicia a execução da rotina na nova instância
            new Thread(tt.NovaThread).Start();
            Console.WriteLine("---ok----");
            //executa a rotina na mesma instãncia
            tt.NovaThread();
            Console.ReadKey();
        }

        // Note que NovaThread é agora um método de instãncia
        void NovaThread()
        {
            if (!ok)
            {
                ok = true;
                for (int i = 0; i < 500000; i++)
                {
                    Console.Write("6");
                } 
            }
        }
    }
}
