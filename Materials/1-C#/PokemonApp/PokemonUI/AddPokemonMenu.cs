using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonModels;
namespace PokemonUI
{
    internal class AddPokemonMenu : IMenu
    {
        private static Pokemon newPokemon = new Pokemon();
        public void Display()
        {
            Console.WriteLine("Enter Pokemon Information");
            Console.WriteLine("<7> Abilities - " + newPokemon.Abilities[0]);
            Console.WriteLine("<6> Health - " + newPokemon.Health);
            Console.WriteLine("<5> Defense - " + newPokemon.Defense);
            Console.WriteLine("<4> Attack - " + newPokemon.Attack);
            Console.WriteLine("<3> Name - " + newPokemon.Name);
            Console.WriteLine("<2> Level - " + newPokemon.Level);
            Console.WriteLine("<1> Save");
            Console.WriteLine("<0> Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    PokemonOperations.AddNewPokemon(newPokemon.Name, newPokemon.Level, newPokemon.Attack, newPokemon.Defense, newPokemon.Health);
                    Console.WriteLine(newPokemon.Name + " was saved!");
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Enter new pokemon's LEVEL: ");
                    newPokemon.Level = Convert.ToInt32(Console.ReadLine());
                    return "AddPokemon";
                case "3":
                    Console.WriteLine("Enter new pokemon's NAME: ");
                    newPokemon.Name = Console.ReadLine();
                    return "AddPokemon";
                case "4":
                    Console.WriteLine("Enter new pokemon's ATTACK: ");
                    newPokemon.Attack = Convert.ToInt32(Console.ReadLine());
                    return "AddPokemon";
                case "5":
                    Console.WriteLine("Enter new pokemon's DEFENSE: ");
                    newPokemon.Defense = Convert.ToInt32(Console.ReadLine());
                    return "AddPokemon";
                case "6":
                    Console.WriteLine("Enter new pokemon's HEALTH: ");
                    newPokemon.Health = Convert.ToInt32(Console.ReadLine());
                    return "AddPokemon";
                case "7":
                    //Console.WriteLine("Enter new pokemon's first ABILITY: ");
                    //newPokemon.Abilities = Ability Console.ReadLine();
                    return "AddPokemon";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddPokemon";
            }
        }
    }
}
