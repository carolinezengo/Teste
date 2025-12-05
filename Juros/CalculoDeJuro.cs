using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NovoTarget
{
    public class CalculoDeJuro
    {
        DateTime dataAtual = DateTime.Today;
        double valorDoJuros = 0;


        public void JurosPorDataDeVencimento(double valor, DateTime dataVencimento)
        {
           

            TimeSpan  quantidadeDia = new TimeSpan();
            quantidadeDia = dataAtual- dataVencimento;
            int dias = quantidadeDia.Days;

            if (dias > 0)
            {
                for (int i = 0; i < dias; i++)
                {

                    valorDoJuros = 2.5 / 100;
                    valor = valor + (valor * valorDoJuros);

                }

                Console.WriteLine($"Valor á ser pago após a data de vencimento é:  {valor.ToString("N2")}");

            }
            else
            {
                Console.WriteLine($"Valor á ser pago até o dia {dataVencimento.Day} é:  {valor.ToString("N2")}");
            }

         

          
          

          



            
            
        }
    }
}