using System;
using System.Collections.Generic;
using System.Globalization;

public class Controller
{
    // Estrutura que representa um objeto achado
    public struct Objetos
    {
        public int id { get; set; } // ID do objeto
        public string tipo { get; set; } // Tipo do objeto
        public string data { get; set; } // Data (formato não utilizado)
        public string descricao { get; set; } // Descrição do objeto
        public string Local { get; set; } // Local onde foi encontrado
        public DateTime DataEncontrado { get; set; } // Data em que o objeto foi encontrado
        public bool achado { get; set; } // Status de se o objeto foi encontrado ou não
    }

    // Lista estática para armazenar objetos
    public static List<Objetos> ObjList = new List<Objetos>();

    // Exibe o menu principal
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
        Console.WriteLine("|0-Sair                                             |");
        Console.WriteLine("=====================================================");
    }

    // Método para cadastrar um novo objeto
    public static bool cadastroObeto()
    {
        Console.WriteLine("=========================================================================");
        Console.WriteLine("|                Cadastre o Objeto achado:                              |");
        Console.WriteLine("=========================================================================");

        while (true)
        {
            Objetos newObjeto = new Objetos(); // Cria um novo objeto
            newObjeto.id = ObjList.Count + 1; // Atribui ID baseado na contagem atual

            Console.Write("|Tipo: ");
            newObjeto.tipo = Console.ReadLine()!;
            if (string.IsNullOrEmpty(newObjeto.tipo))
            {
                Console.WriteLine("Tipo inválido. Tente novamente!"); // Valida tipo
                continue;
            }

            Console.Write("|Data (dd/MM/yyyy): ");
            string dataString = Console.ReadLine()!;
            // Tenta converter a string da data
            if (DateTime.TryParseExact(dataString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataEncontrado))
            {
                newObjeto.DataEncontrado = dataEncontrado;
            }
            else
            {
                Console.WriteLine("Data inválida. A data será definida como a data atual."); // Data padrão
                newObjeto.DataEncontrado = DateTime.Now;
            }

            Console.Write("|Descrição do objeto: ");
            newObjeto.descricao = Console.ReadLine()!; // Lê descrição

            Console.Write("|Local onde foi encontrado: ");
            newObjeto.Local = Console.ReadLine()!; // Lê local

            ObjList.Add(newObjeto); // Adiciona o novo objeto à lista principal

            Console.WriteLine("Deseja cadastrar outro objeto? (s/n)");
            string continuar = Console.ReadLine()!.ToLower();

            // Valida a entrada do usuário
            while (continuar != "s" && continuar != "n")
            {
                Console.WriteLine("Opção inválida. Digite 's' para continuar ou 'n' para sair.");
                continuar = Console.ReadLine()!.ToLower();
            }

            if (continuar == "n") // Sai do loop se o usuário não quiser continuar
            {
                break;
            }
        }

        Console.WriteLine("Cadastro feito com sucesso! ");
        return true; // Retorna verdadeiro ao finalizar o cadastro
    }

    // Exibe objetos encontrados
    public static void ObjetosEncontrados()
    {
        if (ObjList.Count == 0) // Verifica se a lista está vazia
        {
            Console.WriteLine("Nenhum Objeto cadastrado.");
            return;
        }

        Console.WriteLine("=========================================================================");
        Console.WriteLine("|                Objetos Achados:                                       |");
        Console.WriteLine("=========================================================================");

        foreach (var objeto in ObjList) // Itera sobre a lista de objetos
        {
            Console.WriteLine("| ID: {0} | Tipo: {1} | Descrição: {2} | Local: {3} | Data: {4} |",
                objeto.id, objeto.tipo, objeto.descricao, objeto.Local, objeto.DataEncontrado.ToString("dd/MM/yyyy"));

            Console.WriteLine("=========================================================================");
        }
    }

    // Realiza o login da secretaria
    public static void LoginSecretaria()
    {
        Console.WriteLine("=========================================================================");
        Console.WriteLine("|                           ACESSO SECRETARIA                           |");
        Console.WriteLine("=========================================================================");
        Console.WriteLine("|                                                                       |");
        Console.WriteLine("|                            Login: ");
        string login = Console.ReadLine()!;
        Console.WriteLine("|                            Senha: ");
        string senha = Console.ReadLine()!;

        // Verifica credenciais
        if (login == "admin" && senha == "admin123")
        {
            Console.WriteLine("                  BEM VINDO AO MENU DA SECRETARIA                            ");
            Thread.Sleep(3000); // Pausa para visualização
            Console.Clear(); // Limpa a tela
            MenuSecretaria(); // Chama o menu da secretaria
        }
    }

    // Exibe o menu da secretaria
    public static void MenuSecretaria()
    {
        Console.WriteLine("======================================================");
        Console.WriteLine("|                   SECRETARIA                       |");
        Console.WriteLine("=====================================================|");
        Console.WriteLine("|1-Relatorio                                         |");
        Console.WriteLine("|2-Editar Achados e perdidos                         |");
        Console.WriteLine("|3-Excluir objeto cadastrado                         |");
        Console.WriteLine("|0-Sair                                              |");
        Console.WriteLine("======================================================");
    }

    // Gera relatório de objetos
    public static void Relatorio()
    {
        Console.WriteLine("======================================================");
        Console.WriteLine("|                   Relatorio                        |");
        Console.WriteLine("=====================================================|");
        foreach (var objeto in ObjList) // Itera sobre os objetos
        {
            Console.WriteLine("| ID: {0} | Tipo: {1} | Descrição: {2} | Local: {3} | Data: {4} | Situação: {5} |",
                objeto.id, objeto.tipo, objeto.descricao, objeto.Local, objeto.DataEncontrado.ToString("dd/MM/yyyy"), objeto.achado);

            Console.WriteLine("=========================================================================");
        }
    }

    // Edita um objeto existente
    public static void Editar()
    {
        Console.WriteLine("======================================================");
        Console.WriteLine("|             Editar Achados e Perdidos              |");
        Console.WriteLine("=====================================================|");

        if (ObjList.Count == 0) // Verifica se há objetos para editar
        {
            Console.WriteLine("Não há objetos cadastrados para editar.");
            return;
        }

        Console.WriteLine("Objetos cadastrados:");
        foreach (var objeto in ObjList) // Exibe objetos cadastrados
        {
            Console.WriteLine("| ID: {0} | Tipo: {1} | Descrição: {2} | Local: {3} | Data: {4} | Situação: {5} |",
                objeto.id, objeto.tipo, objeto.descricao, objeto.Local, objeto.DataEncontrado.ToString("dd/MM/yyyy"), objeto.achado);
            Console.WriteLine("=========================================================================");
        }

        Console.Write("Digite o ID do objeto que deseja editar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var objetoEditar = ObjList.FirstOrDefault(o => o.id == id); // Busca objeto por ID
            if (ReferenceEquals(objetoEditar, null))
            {
                Console.WriteLine("Objeto não encontrado."); // Verifica se o objeto existe
                return;
            }

            while (true)
            {
                Console.WriteLine("Digite o número do campo que deseja editar (ou 0 para sair):");
                Console.WriteLine("1 - Tipo");
                Console.WriteLine("2 - Data");
                Console.WriteLine("3 - Descrição");
                Console.WriteLine("4 - Local");
                Console.WriteLine("5 - Situação (Encontrado/Não encontrado)");
                Console.Write("Opção: ");

                if (int.TryParse(Console.ReadLine(), out int opcao)) // Lê a opção do usuário
                {
                    switch (opcao)
                    {
                        case 0:
                            Console.WriteLine("Edição cancelada."); // Cancela a edição
                            return;
                        case 1:
                            Console.Write("Novo tipo: ");
                            objetoEditar.tipo = Console.ReadLine()!; // Atualiza tipo
                            break;
                        case 2:
                            Console.Write("Nova data (dd/MM/yyyy): ");
                            // Tenta atualizar a data
                            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime novaData))
                            {
                                objetoEditar.DataEncontrado = novaData;
                            }
                            else
                            {
                                Console.WriteLine("Data inválida."); // Valida data
                            }
                            break;
                        case 3:
                            Console.Write("Nova descrição: ");
                            objetoEditar.descricao = Console.ReadLine()!; // Atualiza descrição
                            break;
                        case 4:
                            Console.Write("Novo local: ");
                            objetoEditar.Local = Console.ReadLine()!; // Atualiza local
                            break;
                        case 5:
                            Console.WriteLine("Deseja marcar o objeto como encontrado? (s/n)");
                            objetoEditar.achado = Console.ReadLine()!.ToLower() == "s"; // Atualiza situação
                            break;
                        default:
                            Console.WriteLine("Opção inválida."); // Trata opção inválida
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida."); // Trata entrada inválida
                }

                Console.Write("Deseja editar outro campo? (s/n): ");
                if (Console.ReadLine()!.ToLower() != "s")
                {
                    continue; // Sai do loop se o usuário não quiser continuar editando
                }
            }
        }
        else
        {
            Console.WriteLine("ID inválido."); // Valida ID
        }
    }

    // Exclui um objeto da lista
    public static void Excluir()
    {
        Console.WriteLine("======================================================");
        Console.WriteLine("|             Excluir Objeto Cadastrado              |");
        Console.WriteLine("=====================================================|");

        if (ObjList.Count == 0) // Verifica se há objetos para excluir
        {
            Console.WriteLine("Não há objetos cadastrados para excluir.");
            return;
        }

        Console.WriteLine("Objetos cadastrados:");
        foreach (var objeto in ObjList) // Exibe objetos cadastrados
        {
            Console.WriteLine("| ID: {0} | Tipo: {1} | Descrição: {2} | Local: {3} | Data: {4} | Situação: {5} |",
                objeto.id, objeto.tipo, objeto.descricao, objeto.Local, objeto.DataEncontrado.ToString("dd/MM/yyyy"), objeto.achado);
            Console.WriteLine("=========================================================================");
        }

        Console.Write("Digite o ID do objeto que deseja excluir: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var objetoExcluir = ObjList.FirstOrDefault(o => o.id == id); // Busca objeto por ID

            if (ReferenceEquals(objetoExcluir, null))
            {
                Console.WriteLine("Objeto não encontrado."); // Verifica se o objeto existe
            }
            else
            {
                ObjList.Remove(objetoExcluir); // Remove objeto da lista
                Console.WriteLine("Objeto excluído com sucesso!"); // Confirmação de exclusão
            }
        }
        else
        {
            Console.WriteLine("ID inválido."); // Valida ID
        }
    }
}
