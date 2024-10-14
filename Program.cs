using System;
class Program
{
    static void Main()
    {
        Console.Clear();
        // Inicializando chave de leitura
        ConsoleKeyInfo keyinfo;


        Controller.TelaPrincipal();
        keyinfo = Console.ReadKey(true); // Melhor interação para o usuário

        do
        {
            if (keyinfo.Key == ConsoleKey.NumPad1 || keyinfo.Key == ConsoleKey.D1)
            {
                Console.Clear();
                bool registrationSuccess = Controller.cadastroObeto();
                if (registrationSuccess) // Check if registration was successful
                {
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
                    Console.ReadKey(true);
                    
                }
                    
            }

            if (keyinfo.Key == ConsoleKey.NumPad2 || keyinfo.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Controller.ObjetosEncontrados();
                Console.ReadKey(true);
            }

        } while (keyinfo.Key != ConsoleKey.NumPad0 || keyinfo.Key != ConsoleKey.D0);
    }
}