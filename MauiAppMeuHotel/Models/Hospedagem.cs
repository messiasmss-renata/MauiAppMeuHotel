namespace MauiAppMeuHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoEscolhido { get; set; }

        public int QtdAdultos { get; set; }

        public int QtdCriancas { get; set; }

        public DateTime DataCheckin { get; set; }
        public DateTime DataCheckout { get; set; }

        public int Estadias

        {
            get => DataCheckout.Subtract(DataCheckin).Days;

        }
        
        public double TotalHospedagem
        {
            get
            {
                Double total_adultos = QtdAdultos * QuartoEscolhido.ValorAdultos;
                Double total_criancas = QtdCriancas * QuartoEscolhido.ValorCriancas;

                return (total_adultos + total_criancas) * Estadias;

            }
        }

    }
}
