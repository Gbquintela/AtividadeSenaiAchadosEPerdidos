using System;
using System.Collections.Generic;

public class Controller
{
    public struct Objetos
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string data { get; set; }
        public string descricao { get; set; }
        public string Local { get; set; }
        public DateTime DataEncontrado { get; set; }
    }

    public static List<Objetos> ObjList = new List<Objetos>();

    public static void TelaPrincipal()
    {
        Console.WriteLine("=====================================================");
        Console.WriteLine("|                Faculdade Conhecimento             |");
        Console.WriteLine("=====================================================");
        Console.WriteLine("|          Bem vindo ao nosso Achados e Perdidos!   |");
        Console.WriteLine("|               Escolha uma opcao:                  |");
        Console.WriteLine("=====================================================");
        Console.WriteLine("|1-Cadastrar Objeto Achado:                         |");
        Console.WriteLine("|2-Consultar Objetos:                               |");
        Console.WriteLine("|3-Login Secretaria                                 |");
        Console.WriteLine("=====================================================");
    }

    public static bool cadastroObeto()
    {
        Console.WriteLine("=========================================================================");
        Console.WriteLine("|                Cadastre o Objeto achado:                              |");
        Console.WriteLine("=========================================================================");

        while (true)
        {
            Objetos newObjeto = new Objetos();
            newObjeto.id = ObjList.Count + 1;

            Console.Write("|Tipo: ");
            newObjeto.tipo = Console.ReadLine()!;
            if (string.IsNullOrEmpty(newObjeto.tipo))
            {
                Console.WriteLine("Tipo inválido. Tente novamente!");
                continue;
            }

            Console.Write("|Data (dd/MM/yyyy): ");
            string dataString = Console.ReadLine()!;
            if (DateTime.TryParseExact(dataString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataEncontrado))
            {
                newObjeto.DataEncontrado = dataEncontrado;
            }
            else
            {
                Console.WriteLine("Data inválida. A data será definida como a data atual.");
                newObjeto.DataEncontrado = DateTime.Now;
            }

            Console.Write("|Descrição do objeto: ");
            newObjeto.descricao = Console.ReadLine()!;

            Console.Write("|Local onde foi encontrado: ");
            newObjeto.Local = Console.ReadLine()!;

            ObjList.Add(newObjeto); // Adiciona o novo objeto à lista principal

            Console.WriteLine("Deseja cadastrar outro objeto? (s/n)");
            string continuar = Console.ReadLine()!.ToLower();

            // Validar a entrada do usuário
            while (continuar != "s" && continuar != "n")
            {
                Console.WriteLine("Opção inválida. Digite 's' para continuar ou 'n' para sair.");
                continuar = Console.ReadLine()!.ToLower();
            }

            if (continuar == "n")
            {
                break; 
            }
        }

        Console.WriteLine("Cadastro feito com sucesso :)");
        return true;
    }

    public static void ObjetosEncontrados()
    {
        if (ObjList.Count == 0)
        {
            Console.WriteLine("Nenhum Objeto cadastrado.");
            return;
        }

        Console.WriteLine("=========================================================================");
        Console.WriteLine("|                Objetos Achados:                                       |");
        Console.WriteLine("=========================================================================");

        foreach (var objeto in ObjList)
        {
            Console.WriteLine("| ID: {0} | Tipo: {1} | Descrição: {2} | Local: {3} | Data: {4} |",
                objeto.id, objeto.tipo, objeto.descricao, objeto.Local, objeto.DataEncontrado.ToString("dd/MM/yyyy"));

            Console.WriteLine("=========================================================================");
        }
    }

    public static void LoginSecretaria()
    {
        Console.WriteLine("===========================================================");
        Console.WriteLine("|                   ACESSO SECRETARIA                     |");
        Console.WriteLine("===========================================================");
        Console.WriteLine("|Login:                                                    ");
        Console.WriteLine("|Senha:                                                    ");
        Console.WriteLine("===========================================================");

    }


    public static void MenuSecretaria()
    {


    }
}            