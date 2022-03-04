using System;

namespace _01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Campainha campainha = new();
            campainha.OnCampainhaTocou += TocarCampainha1;
            campainha.OnCampainhaTocou += TocarCampainha2;
            campainha.Tocar("101");
            Console.WriteLine();

            campainha.OnCampainhaTocou -= TocarCampainha1;
            campainha.Tocar("202");
        }

        static void TocarCampainha1(object sender, CampainhaEventArgs args)
        {
            Console.WriteLine($"A campainha tocou no apartamento {args.Apartamento} (1)");
        }

        static void TocarCampainha2(object sender, CampainhaEventArgs args)
        {
            Console.WriteLine($"A campainha tocou no apartamento {args.Apartamento} (2)");
        }
    }

    class Campainha
    {
        public event EventHandler<CampainhaEventArgs> OnCampainhaTocou;

        public void Tocar(string apartamento)
        {
            if (OnCampainhaTocou != null)
                OnCampainhaTocou(this, new CampainhaEventArgs(apartamento));
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