using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp
{
    class Program
    {
        static Program()
        {

        }
        static void Main(string[] args)
        {
            Pokemon[] Pokemons = {
                new Pokemon(1, "Bulbasaur", 1, 30),
                new Pokemon(4, "Charmander", 1, 30),
                new Pokemon(7, "Squirtle", 1, 30)
            };

            Console.WriteLine("Hello World...");
            Console.ReadKey(true);
            //var Bulbasaur = GetPokemon("http://pokeapi.co/api/v2/pokemon/1");
            foreach(Pokemon Pokemon in Pokemons)
            {
                Console.WriteLine("Name: {0}, Index No.: {1}", Pokemon.Name, Pokemon.Id);
            }
            //Console.WriteLine(Bulbasaur.Name);
            //Console.WriteLine(Bulbasaur.Types[0].Slot);
            //Console.WriteLine(Bulbasaur.Base_Experience);
            //Console.WriteLine(Bulbasaur.Moves[0]);
            Console.ReadKey(true);
        }

        public static Pokemon GetPokemon(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/json";
            //webrequest.Headers.Add("Username", "xyz");
            //webrequest.Headers.Add("Password", "abc");
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            Pokemon objectResult = JsonConvert.DeserializeObject<Pokemon>(result);
            return objectResult;
        }
    }
}
