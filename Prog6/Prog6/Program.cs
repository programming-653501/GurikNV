using static System.Console;

namespace Prog6
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree();
            while (true)
            {
                WriteLine("Введите элемент дерева(0 - закончить ввод):");
                int node;
                while (!int.TryParse(ReadLine(), out node)) { WriteLine("Неверный ввод!"); }
                if (node == 0) { break; }   
                tree.Add(node);
            }
            WriteLine("Сбалансированность дерева - " + tree.IsBalanced(tree.Root));
            ReadKey();
        }
    }
}
