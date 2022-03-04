using System;
using System.Collections.Generic;

namespace _01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Campainha campainha = new();
                campainha.OnCampainhaTocou += TocarCampainha1;
                campainha.OnCampainhaTocou += TocarCampainha2;
                campainha.Tocar("101");
                Console.WriteLine();

                campainha.OnCampainhaTocou -= TocarCampainha1;
                campainha.Tocar("202");
            }
            catch (AggregateException e)
            {
                foreach (var exception in e.InnerExceptions)
                    Console.WriteLine(exception.Message);
            }
            catch (Exception) { }
        }

        static void TocarCampainha1(object sender, CampainhaEventArgs args)
        {
            Console.WriteLine($"A campainha tocou no apartamento {args.Apartamento} (1)");
            throw new Exception("exceção no método TocarCampainha1");
        }

        static void TocarCampainha2(object sender, CampainhaEventArgs args)
        {
            Console.WriteLine($"A campainha tocou no apartamento {args.Apartamento} (2)");
            throw new Exception("exceção no método TocarCampainha2");
        }
    }

    class Campainha
    {
        public event EventHandler<CampainhaEventArgs> OnCampainhaTocou;
        private readonly List<Exception> _exceptions = new();

        public void Tocar(string apartamento)
        {
            foreach (var manipulador in OnCampainhaTocou.GetInvocationList())
            {
                try
                {
                    manipulador.DynamicInvoke(this, new CampainhaEventArgs(apartamento));
                }
                catch (Exception e)
                {
                    _exceptions.Add(e.InnerException);
                }
            }

            if (_exceptions.Count > 0)
                throw new AggregateException(_exceptions);
        }
    }

    class CampainhaEventArgs : EventArgs
    {
        public string Apartamento { get; }

        public CampainhaEventArgs(string apartamento)
        {
            Apartamento = apartamento;
        }
    }
}