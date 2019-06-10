/// 
/// <summary> 
/// Erzeugung der Subtour Elimination Constraints für angegebene Knoten in der Konsole
/// Output ist für eine untere Dreieck Matrix konzipiert
/// </summary>
/// 

using System;
using System.Linq;

namespace SubTourEliminationConstraintGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lesen der Knoten
            string input = Console.ReadLine();

            // Entfernt alles was kein Buchstabe oder Ziffer ist und Dubletten
            char[] list = System.Text.RegularExpressions.Regex.Replace(input, "[^A-Za-z0-9]", "").Distinct().ToArray();

            Console.WriteLine(Generate(list));
        }

        private static string Generate(char[] nodes)
        {
            // Array umgekehrt sortieren 
            Array.Sort(nodes);
            Array.Reverse(nodes);

            // Neuen StringBuilder mit Initialisierung
            System.Text.StringBuilder result = new System.Text.StringBuilder("cycle");
            Array.ForEach(nodes, node => result.Append("_" + node));
            result.Append(": ");

            // Erzeugung des Outputs
            Array.ForEach(nodes, node1 => Array.ForEach(nodes, node2 => result.Append((node1 > node2) ? 
                ("x" + node1 + node2 + ((node1.Equals(nodes[nodes.Length - 2])) ? " <= " + (nodes.Length - 1) : " + ")) : "")));

            return result.ToString();
        }
    }
}
