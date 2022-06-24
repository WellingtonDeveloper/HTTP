using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
            request.Method = "GET";

            using (var resposta = request.GetResponse())
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();

                Console.WriteLine(dados.ToString());

                stream.Close();
                resposta.Close();
            }

            Console.ReadLine();
        }
    }
}
