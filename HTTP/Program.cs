using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            //cadastro da requisição
            WebRequest request = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
            request.Method = "GET";
            var resposta = request.GetResponse(); // recebe a resposta da resquisição

            using (resposta)//a a resposta da requisição dentro da estrututa Using que vai processar a resposta
            {
                var stream = resposta.GetResponseStream();//Peguei o resultado da resposta e coloquei na vairavel stream
                StreamReader leitor = new StreamReader(stream);//Coloquei a resposta dentro de um leitor
                object dados = leitor.ReadToEnd();//Li a resposta e transformei em uma string e passsei para a variavel dados

                Console.WriteLine(dados.ToString());//Exibindo no Console

                stream.Close();
                resposta.Close();
            }

            Console.ReadLine();
        }
    }
}
