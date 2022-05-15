using SIND_Console.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace SIND_Console
{
  class Program
  {
    static void Main(string[] args)
    {
      CriarContasNoBancoDeDados();
      bool sairPrograma = false;

      while (!sairPrograma)
      {
        ConsoleCores.Write(ConsoleColor.Cyan, "    BEM VINDO AO ");
        ConsoleCores.WriteLine(ConsoleColor.Green, "SIND+");

        WriteLine();
        WriteLine("  Bem vindo ao Condominio Nogueira!");
        WriteLine();
        WriteLine("  Digite o nº da opção desejada.");
        WriteLine(" _________________________________");
        WriteLine("|    1 - Para se registrar!       |");
        WriteLine("|    2 - Para fazer login!        |");
        WriteLine("|    3 - Para sair do programa!   |");
        WriteLine("|_________________________________|");

        var numeroApertado = Console.ReadKey();
        Clear();


        switch (numeroApertado.KeyChar)
        {
          #region  1 - Para se registrar! 
          case '1':
            Registrar();
            break;
          #endregion
          #region 2 - Para fazer login!  
          case '2':
            Login();
            break;
          #endregion
          #region 3 - Para sair do programa!
          case '3':
            sairPrograma = true;
            break;
            #endregion
        }
      }

      if (sairPrograma)
        ConsoleCores.WriteLine(ConsoleColor.Red, "\n\n PROGRAMA FECHADO!!\n\n");
    }

    private static void Registrar()
    {
      string cadastroMensagem = "Por favor, preencha as informações abaixo:";
      while (true)
      {
        ConsoleCores.WriteLine(ConsoleColor.Cyan, "Você está se registrando.");
        WriteLine();
        WriteLine();

        Usuario cadastroUsuario = new Usuario();
        WriteLine(cadastroMensagem);
        WriteLine();
        ConsoleCores.Write(ConsoleColor.Green, "Nome:  ");
        cadastroUsuario.Nome = Console.ReadLine();

        ConsoleCores.Write(ConsoleColor.Green, "Senha:  ");
        cadastroUsuario.Senha = Console.ReadLine();

        ConsoleCores.Write(ConsoleColor.Green, "Email:  ");
        cadastroUsuario.Email = Console.ReadLine();

        ConsoleCores.Write(ConsoleColor.Green, "Bloco:  ");
        cadastroUsuario.Bloco = Console.ReadLine();

        ConsoleCores.Write(ConsoleColor.Green, "Apartamento:  ");
        cadastroUsuario.Apartamento = Console.ReadLine();

        WriteLine();
        ConsoleCores.Write(ConsoleColor.Magenta, "As informações acima estão corretas? S / N");

        var numeroApertado = Console.ReadKey();
        Console.Clear();
        switch (numeroApertado.KeyChar)
        {
          case 'S':
          case 's':
            Database.Usuarios.Add(cadastroUsuario);
            return;
          default:
            cadastroMensagem = "Por favor, insira as informações novamente.";
            break;
        }
      }
    }
    private static void Login()
    {
      Usuario loginUsuario = null;
      ConsoleCores.WriteLine(ConsoleColor.Cyan, "Você está efetuando login.");
      WriteLine();
      WriteLine();
      WriteLine("Por favor, preencha as informações abaixo:");

      ConsoleCores.Write(ConsoleColor.Green, "email:  ");
      var loginEmail = Console.ReadLine();

      ConsoleCores.Write(ConsoleColor.Green, "senha:  ");
      var loginSenha = Console.ReadLine();

      loginUsuario = Database.Usuarios.Find(x => x.Email == loginEmail & x.Senha == loginSenha);
      if (loginUsuario == null)
      {
        WriteLine();
        ConsoleCores.WriteLine(ConsoleColor.Red, "Você não está cadastrado!\nAperte qualquer botão para voltar.");
        Console.ReadKey();
        Console.Clear();
      } else
      {
        Console.Clear();
        Logado(loginUsuario);
      }
    }

    private static void Logado(Usuario usuario)
    {
      while (true)
      {
        ConsoleCores.WriteLine(ConsoleColor.Cyan, "Você está logado.");
        WriteLine();
        WriteLine();
        ConsoleCores.WriteLine(ConsoleColor.Blue, $"{usuario.Nome} - AP {usuario.Apartamento} - Bloco {usuario.Bloco} \n{usuario.Email} ");

        WriteLine();
        WriteLine("  Digite o nº da opção desejada.");
        WriteLine(" ____________________________________");
        WriteLine("|    1 - Contas a pagar!             |");
        WriteLine("|    2 - Contas paga!                |");
        WriteLine("|    3 - Deslogar!                   |");
        WriteLine("|____________________________________|");


        var numeroApertado = Console.ReadKey();
        Clear();

        switch (numeroApertado.KeyChar)
        {
          #region 1 - Contas a pagar!
          case '1':
            ContasAPagar();
            break;
          #endregion
          #region 2 - Contas paga! 
          case '2':
            ContasPaga();
            break;
          #endregion
          #region 3 - Deslogar!
          case '3':
            return;
            #endregion
        }

      }
    }

    private static void ContasPaga()
    {
      while (true)
      {
        ConsoleCores.WriteLine(ConsoleColor.Cyan, "Todas as contas pagas!");
        WriteLine();
        WriteLine();

        //Filtrando contas por tipo Luz e se está paga
        List<Conta> contas = Database.Contas.FindAll(x => x.EstaPaga == true);

        WriteLine();
        WriteLine("  Digite o nº da opção desejada.");
        WriteLine("_______________________________________________________");

        int indice = 1;
        foreach (var conta in contas)
        {
          WriteLine($"    {indice} - {conta.Mes} - {conta.Tipo}.");
          indice++;
        }
        WriteLine($"    {indice} - para voltar ao menu anterior.");
        WriteLine("_______________________________________________________");

        var teclaApertada = Console.ReadKey();
        var contaEscolhida = Convert.ToInt32(teclaApertada.KeyChar.ToString());
        Clear();

        try
        {
          if (contas[contaEscolhida - 1] != null)
          {
            MostrarConta(contas[contaEscolhida - 1]);
          } else
          {
            return;
          }
        } catch (Exception ex)
        {
          return;
        }
      }
    }

    public static void ContasAPagar()
    {
      while (true)
      {
        ConsoleCores.WriteLine(ConsoleColor.Cyan, "Contas a pagar!");
        WriteLine();
        WriteLine();
        WriteLine();
        WriteLine("  Digite o nº da opção desejada.");
        WriteLine(" ____________________________________");
        WriteLine("|    1 - Luz!                        |");
        WriteLine("|    2 - Agua!                       |");
        WriteLine("|    3 - Condominio!                 |");
        WriteLine("|    4 - Voltar!                     |");
        WriteLine("|____________________________________|");


        var numeroApertado = Console.ReadKey();
        Clear();

        switch (numeroApertado.KeyChar)
        {
          #region 1 - Luz! 
          case '1':
            VerContaLuz();
            break;
          #endregion
          #region 2 - Agua! 
          case '2':
            VerContaAgua();
            break;
          #endregion
          #region 3 - Condominio! 
          case '3':
            VerContaCondominio();
            break;
          #endregion
          #region 4 - Voltar!    
          case '4':
            return;
            #endregion
        }
      }
    }

    private static void VerContaCondominio()
    {
      while (true)
      {
        ConsoleCores.WriteLine(ConsoleColor.Cyan, "Condominio!");
        WriteLine();
        WriteLine();

        //Filtrando contas por tipo Luz e se está paga
        List<Conta> contas = Database.Contas.FindAll(x => x.EstaPaga == false & x.Tipo == EnumTipo.Condominio);

        WriteLine();
        WriteLine("  Digite o nº da opção desejada.");
        WriteLine("_______________________________________________________");

        int indice = 1;
        foreach (var conta in contas)
        {
          WriteLine($"    {indice} - {conta.Mes}.");
          indice++;
        }
        WriteLine($"    {indice} - para voltar ao menu anterior.");
        WriteLine("_______________________________________________________");

        var teclaApertada = Console.ReadKey();
        var contaEscolhida = Convert.ToInt32(teclaApertada.KeyChar.ToString());
        Clear();

        try
        {
          if (contas[contaEscolhida - 1] != null)
          {
            MostrarConta(contas[contaEscolhida - 1]);
          } else
          {
            return;
          }
        } catch (Exception ex)
        {
          return;
        }
      }
    }

    public static void VerContaLuz()
    {
      while (true)
      {
        ConsoleCores.WriteLine(ConsoleColor.Cyan, "Luz!");
        WriteLine();
        WriteLine();

        //Filtrando contas por tipo Luz e se está paga
        List<Conta> contas = Database.Contas.FindAll(x => x.EstaPaga == false & x.Tipo == EnumTipo.Luz);

        WriteLine();
        WriteLine("  Digite o nº da opção desejada.");
        WriteLine("_______________________________________________________");

        int indice = 1;
        foreach (var conta in contas)
        {
          WriteLine($"    {indice} - {conta.Mes}.");
          indice++;
        }
        WriteLine($"    {indice} - para voltar ao menu anterior.");
        WriteLine("_______________________________________________________");

        var teclaApertada = Console.ReadKey();
        var contaEscolhida = Convert.ToInt32(teclaApertada.KeyChar.ToString());
        Clear();

        try
        {
          if (contas[contaEscolhida - 1] != null)
          {
            MostrarConta(contas[contaEscolhida - 1]);
          } else
          {
            return;
          }
        } catch (Exception ex)
        {
          return;
        }
      }
    }

    public static void VerContaAgua()
    {
      while (true)
      {
        ConsoleCores.WriteLine(ConsoleColor.Cyan, "Agua!");
        WriteLine();
        WriteLine();

        //Filtrando contas por tipo Luz e se está paga
        List<Conta> contas = Database.Contas.FindAll(x => x.EstaPaga == false & x.Tipo == EnumTipo.Agua);
        contas = contas.OrderBy(x => (int) (x.Mes)).ToList();

        WriteLine();
        WriteLine("  Digite o nº da opção desejada.");
        WriteLine("_______________________________________________________");

        int indice = 1;
        foreach (var conta in contas)
        {
          WriteLine($"    {indice} - {conta.Mes}.");
          indice++;
        }
        WriteLine($"    {indice} - para voltar ao menu anterior.");
        WriteLine("_______________________________________________________");

        var teclaApertada = Console.ReadKey();
        var contaEscolhida = Convert.ToInt32(teclaApertada.KeyChar.ToString());
        Clear();

        try
        {
          if (contas[contaEscolhida - 1] != null)
          {
            MostrarConta(contas[contaEscolhida - 1]);
          } else
          {
            return;
          }
        } catch (Exception ex)
        {
          return;
        }
      }
    }

    public static void MostrarConta(Conta conta)
    {
      ConsoleCores.WriteLine(ConsoleColor.Cyan, $"Mostrando conta referente a {conta.Mes}!");
      WriteLine();
      WriteLine();
      WriteLine();
      WriteLine("_______________________________________________________");
      WriteLine($"  Data de vencimento: {conta.Data}");
      WriteLine($"  Valor: {conta.Valor}");
      WriteLine($"  Codigo de barras: {conta.CodigoDeBarras}");
      WriteLine("_______________________________________________________");
      ConsoleCores.WriteLine(ConsoleColor.Red, " Aperte qualquer botão para voltar.");
      Console.ReadKey();
      Console.Clear();
      return;
    }


    public static void CriarContasNoBancoDeDados()
    {
      #region Contas
      CriarConta(new Conta(EnumMes.Fevereiro, EnumTipo.Luz, 240.8, EstaPaga: true).SetData("20/02/22"));
      CriarConta(new Conta(EnumMes.Fevereiro, EnumTipo.Agua, 89.4, EstaPaga: true).SetData("20/02/22"));
      CriarConta(new Conta(EnumMes.Fevereiro, EnumTipo.Condominio, 380, EstaPaga: true).SetData("20/05/22"));

      CriarConta(new Conta(EnumMes.Marco, EnumTipo.Luz, 290.1, EstaPaga: true).SetData("20/03/22"));
      CriarConta(new Conta(EnumMes.Marco, EnumTipo.Agua, 290.1, EstaPaga: true).SetData("20/03/22"));
      CriarConta(new Conta(EnumMes.Marco, EnumTipo.Condominio, 290.1, EstaPaga: true).SetData("20/03/22"));

      CriarConta(new Conta(EnumMes.Abril, EnumTipo.Agua, 90.30, EstaPaga: false).SetData("20/04/22"));
      CriarConta(new Conta(EnumMes.Abril, EnumTipo.Luz, 236.7, EstaPaga: true).SetData("20/04/22"));
      CriarConta(new Conta(EnumMes.Abril, EnumTipo.Condominio, 380, EstaPaga: true).SetData("20/05/22"));

      CriarConta(new Conta(EnumMes.Maio, EnumTipo.Luz, 270.34, EstaPaga: false).SetData("20/05/22"));
      CriarConta(new Conta(EnumMes.Maio, EnumTipo.Agua, 100.90, EstaPaga: false).SetData("20/05/22"));
      CriarConta(new Conta(EnumMes.Maio, EnumTipo.Condominio, 380, EstaPaga: false).SetData("20/05/22"));
      #endregion
      #region Usuarios
      CriarUsuario(new Usuario("admin", "admin","admin@gmail.com", "bloco 1", "34"));
      #endregion

    }

    public static void CriarConta(Conta conta)
     => Database.Contas.Add(conta);

    public static void CriarUsuario(Usuario usuario)
      => Database.Usuarios.Add(usuario);
  }
}
