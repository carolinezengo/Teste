using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NovoTarget
{
    public class Estoque
    {
        EstoqueGeralEntidade dadosDeEstoque;
        string enderecoJson = "C:/C/NovoTarget/Estoque/EstoqueJson.json";
        List<ProdutoEntidade> listaProduto = new List<ProdutoEntidade>();

        string jsonAtualizado = "";


        public void RetornarResultadoLIsta()
        {
            RetornarEstoque();

             foreach (ProdutoEntidade produto in dadosDeEstoque.Estoque)
                       {
                        Console.WriteLine($"Codigo: {produto.CodigoProduto} , Descricao: {produto.DescricaoProduto}, Estoque: {produto.Estoque}");
                     }
               

        }


        public EstoqueGeralEntidade RetornarEstoque()
        {
            string caminhoArquivo = Path.Combine(enderecoJson);

            if (File.Exists(caminhoArquivo))
            {

                string jsonString = File.ReadAllText(caminhoArquivo);


                dadosDeEstoque = JsonConvert.DeserializeObject<EstoqueGeralEntidade>(jsonString);


            }
            return dadosDeEstoque;
        }

        public string AtualizacaoJson()
        {

            jsonAtualizado = JsonConvert.SerializeObject(dadosDeEstoque, Formatting.Indented);

            return jsonAtualizado;
        }



        public void MovimentacaoDeEstoque(MovimentacaoEstoque novaMovimentacao)
        {

            if (novaMovimentacao.Descricao == "Entrada")
            {
                dadosDeEstoque = RetornarEstoque();

                listaProduto = dadosDeEstoque.Estoque;



                ProdutoEntidade produtoExistente = listaProduto.FirstOrDefault(p => p.CodigoProduto == novaMovimentacao.CodigoProduto);

                if (produtoExistente != null)
                {

                    produtoExistente.Estoque = produtoExistente.Estoque + novaMovimentacao.Quantidade;
                    var movimento = new MovimentacaoEstoque()
                    {
                        IdMovimentacao = novaMovimentacao.IdMovimentacao,
                        Descricao = novaMovimentacao.Descricao

                    };

                    produtoExistente.MovimentacaoEstoque = movimento;

                    Console.WriteLine($"ID Movimentação: {novaMovimentacao.IdMovimentacao} | Tipo: {novaMovimentacao.Descricao} ");
                  
                

                   jsonAtualizado = AtualizacaoJson();
                   File.WriteAllText(enderecoJson, jsonAtualizado);



                    Console.WriteLine(); 
                    Console.WriteLine($"Quantidade Final do Produto {produtoExistente.DescricaoProduto}: {produtoExistente.Estoque}\n");                


                }
                else
                {
                    Console.WriteLine("Produto não existe");

                }




            }

            else if (novaMovimentacao.Descricao == "Saida")
            {


                dadosDeEstoque = RetornarEstoque();

                listaProduto = dadosDeEstoque.Estoque;



                ProdutoEntidade produtoExistente = listaProduto.FirstOrDefault(p => p.CodigoProduto == novaMovimentacao.CodigoProduto);

                if (produtoExistente != null)
                {

                    produtoExistente.Estoque = produtoExistente.Estoque - novaMovimentacao.Quantidade;
                    var movimento = new MovimentacaoEstoque()
                    {
                        IdMovimentacao = novaMovimentacao.IdMovimentacao,
                        Descricao = novaMovimentacao.Descricao

                    };

                    produtoExistente.MovimentacaoEstoque = movimento;

                    Console.WriteLine($"ID Movimentação: {novaMovimentacao.IdMovimentacao} | Tipo: {novaMovimentacao.Descricao}");
                 
                 

                   

                    jsonAtualizado = AtualizacaoJson();

                    File.WriteAllText(enderecoJson, jsonAtualizado);
                   

                    Console.WriteLine(); 
                    Console.WriteLine($"Quantidade Final do Produto {produtoExistente.DescricaoProduto}: {produtoExistente.Estoque}\n");                


               
               
                }
                else
                {
                    Console.WriteLine("Produto não existe");

                }

                  



            
            

            }
     
        }




    }
}