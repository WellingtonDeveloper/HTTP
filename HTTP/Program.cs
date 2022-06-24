using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HTTP
{
    class Program
    {
        enum Menu { ListarTudo = 1, ListarUnica, Sair}
        static void Main(string[] args)
        {
            bool escolheuSair = false;
            while (escolheuSair == false)
            {
                Console.WriteLine("Sistema de Request");
                Console.WriteLine("1 - Listar todas as tarefas\n2 - Buscar tarefa especifica\n3 - Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

                if(opInt > 0 && opInt < 4)
                {
                    Menu escolha = (Menu)opInt;
                    switch (escolha)
                    {
                        case Menu.ListarTudo:
                            ReqList();
                            break;
                        case Menu.ListarUnica:
                            ReqUnica();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    escolheuSair = true;
                }
            }
            //cadastro da requisição, retorna a lista de requisições
            static void ReqList()
            {
                //Lista requisição.
                WebRequest request = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
                request.Method = "GET";
                var resposta = request.GetResponse(); // recebe a resposta da resquisição

                using (resposta)//a a resposta da requisição dentro da estrututa Using que vai processar a resposta
                {
                    var stream = resposta.GetResponseStream();//Peguei o resultado da resposta e coloquei na vairavel stream
                    StreamReader leitor = new StreamReader(stream);//Coloquei a resposta dentro de um leitor
                    object dados = leitor.ReadToEnd();//Li a resposta e transformei em uma string e passsei para a variavel dados

                    //Console.WriteLine(dados.ToString());//Exibindo no Console
                    //Estamos recebendo um tipo List, se colocarmos apenas como uma variavel do tipo tarefas.
                    List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString());

                    foreach (Tarefa tarefa in tarefas)
                    {
                        tarefa.Exibir();
                    }
                    //Console.WriteLine(tarefas);
                    stream.Close();
                    resposta.Close();
                }
            }

            //Requisição de uma unica tarefa
            static void ReqUnica()
            {
                Console.WriteLine("Listar tarefa");
                Console.WriteLine("\nDigite o ID da tarefa que deseja localizar:");
                int idTarefa = int.Parse(Console.ReadLine());

                if (idTarefa > 0 && idTarefa <= 200)
                {

                    WebRequest request = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/" + idTarefa);//conctenação no link +id"String id Console.ReadLine();
                    request.Method = "GET";
                    var resposta = request.GetResponse(); // recebe a resposta da resquisição

                    using (resposta)//a a resposta da requisição dentro da estrututa Using que vai processar a resposta
                    {
                        var stream = resposta.GetResponseStream();//Peguei o resultado da resposta e coloquei na vairavel stream
                        StreamReader leitor = new StreamReader(stream);//Coloquei a resposta dentro de um leitor
                        object dados = leitor.ReadToEnd();//Li a resposta e transformei em uma string e passsei para a variavel dados

                        //Console.WriteLine(dados.ToString());//Exibindo no Console
                        //Estamos recebendo uma tarefa especifica.
                        Tarefa tarefa = JsonConvert.DeserializeObject<Tarefa>(dados.ToString());
                        tarefa.Exibir();

                        //Console.WriteLine(tarefa);
                        stream.Close();
                        resposta.Close();
                    }
                }
                else
                {
                    Console.WriteLine("Id existente.");
                }
            }
       }
    }
}
