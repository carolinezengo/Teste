using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;



namespace NovoTarget
{
    public class Vendas
    {
        double comissao = 0;

       

        List<VendasEntidades> listaVenda = new List<VendasEntidades>();
        List<(string nome, double comissao)> listacomissao = new List<(string, double)>();

        public double CalcularTaxaComissao(Double valorVenda)
        {

            if (valorVenda < 100)
            {
                comissao = 0;



            }
            else if (valorVenda >= 100 && valorVenda < 500)
            {
                comissao = valorVenda / 100;

            }
            else if (valorVenda >= 500)
            {
                comissao = (valorVenda * 5) / 100;

            }



            return comissao;
        }






        public void ComissaoDeCadaVendedor()
        {


          
            string tabelaDeVenda = Path.Combine("C:/C/NovoTarget/Comissao/VendasJson.json");
            string jsonString = File.ReadAllText(tabelaDeVenda);
            if (jsonString != null)
            {
                VendasGeral dados = JsonConvert.DeserializeObject<VendasGeral>(jsonString);


                listaVenda = dados.Vendas;

                foreach (var venda in listaVenda)
                {
                     bool encontrado = false;

                    for (int i = 0; i < listacomissao.Count; i++)
                    {

                        if (listacomissao[i].nome == venda.Vendedor)
                        {


                            listacomissao[i] = (venda.Vendedor, listacomissao[i].comissao + CalcularTaxaComissao(venda.Valor));
                            encontrado = true;
                            break;


                        }


                    }
                    
                    if (!encontrado)
                    {
                        var resultadoComissao = CalcularTaxaComissao(venda.Valor);
                        listacomissao.Add((venda.Vendedor,resultadoComissao));
                    }

                }

                    foreach (var vendedor in listacomissao)
                    {
                        Console.WriteLine($"O Vendedor: {vendedor.nome}, obteve de comissao: {vendedor.comissao.ToString("N2")}");

                    }





                



            }


        }
    }
}