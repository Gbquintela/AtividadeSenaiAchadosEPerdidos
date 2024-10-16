using System;
using System.Globalization;
class Program
{
    static void Main()
    {


        // Inicializando chave de leitura
        ConsoleKeyInfo keyinfo;
        do
        {
            Console.Clear();
            Controller.TelaPrincipal();
            keyinfo = Console.ReadKey(true); // Melhor interação para o usuário

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
                continue;
            }

            if (keyinfo.Key == ConsoleKey.NumPad3 || keyinfo.Key == ConsoleKey.D3)
            {
                Console.Clear();
                Controller.LoginSecretaria();
                do
                {   
                    Console.Clear();
                    Controller.MenuSecretaria();
                    Console.ReadKey(true);
                    keyinfo = Console.ReadKey(true);

                    if (keyinfo.Key == ConsoleKey.NumPad1 || keyinfo.Key == ConsoleKey.D1)
                    {
                        Console.Clear();
                        Controller.Relatorio();
                        Console.ReadKey(true);
                    }

                    if (keyinfo.Key == ConsoleKey.NumPad2 || keyinfo.Key == ConsoleKey.D2)
                    {
                        Console.Clear();
                        Controller.Editar();
                            if (false){
                                return;
                            }
                        Console.ReadKey(true);
                    }

                    if (keyinfo.Key == ConsoleKey.NumPad3 || keyinfo.Key == ConsoleKey.D3)
                    {
                        Console.Clear();
                        Controller.Excluir();
                        Console.ReadKey(true);
                    }

                } while (keyinfo.Key != ConsoleKey.NumPad0 || keyinfo.Key! != ConsoleKey.D0);
            }
            continue;
        } while (keyinfo.Key != ConsoleKey.NumPad0 || keyinfo.Key != ConsoleKey.D0);
    }
}
