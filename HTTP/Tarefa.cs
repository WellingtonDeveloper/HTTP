using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP
{
    class Tarefa
    {
        //Para que a conversão seja realizada os tipos de dados tem que ser os mesmos e os nomes dos campos também tem que ser o mesmo.
        //Tradução dos nomes JSON para C#
        public int userID;
        public int id;
        public string title;
        public bool completed;

        public void Exibir()
        {
            Console.WriteLine("");
            Console.WriteLine("Objeto tarefa");
            Console.WriteLine($"User id: {userID}");
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Finalizou? {completed}");
            Console.WriteLine("");
            Console.WriteLine("============================================");
        }
    }
}
