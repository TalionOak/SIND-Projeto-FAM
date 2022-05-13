using SIND_Console.Entities;
using System;
using System.Collections.Generic;
using static System.Console;

namespace SIND_Console
{
  class Program
  {
    static void Main(string[] args)
    {
      CriarContasNoBancoDeDados();
      bool sairPrograma = false;
      Usuario userTest = new Usuario();
      userTest.Nome = "Ailton Silva e Souza";
      userTest.Senha = "senhadificil";
      userTest.Email = "ailtonsscarvalho@gmail.com";
      userTest.Bloco = "A1";
      userTest.Apartamento = "34";
      Logado(userTest);
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
            bool cadastroContinua = true;
            string cadastroMensagem = "Por favor, preencha as informações abaixo:";
            while (cadastroContinua)
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

              numeroApertado = Console.ReadKey();
              Console.Clear();
              switch (numeroApertado.KeyChar)
              {
                case 'S':
                case 's':
                  cadastroContinua = false;
                  Database.Usuarios.Add(cadastroUsuario);
                  break;
                default:
                  cadastroMensagem = "Por favor, insira as informações novamente.";
                  break;
              }
            }
            break;
          #endregion
          #region 2 - Para fazer login!  
          case '2':
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
              ConsoleCores.WriteLine(ConsoleColor.Red, "Você não está cadastrado!");
              Console.Clear();
            } else
            {
              Console.Clear();
              Logado(loginUsuario);
            }

            Console.ReadKey();
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

    private static void Logado(Usuario usuario)
    {
      bool sairPrograma = false;
      while (!sairPrograma)
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
        WriteLine("|    3 - Informações sobre contas!   |");
        WriteLine("|    4 - Deslogar!                   |");
        WriteLine("|____________________________________|");


        var numeroApertado = Console.ReadKey();
        Clear();

        switch (numeroApertado.KeyChar)
        {
          #region 1 - Contas a pagar!
          case '1':
            bool continuarContasPagar = true;
            while (continuarContasPagar)
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


              numeroApertado = Console.ReadKey();
              Clear();

              switch (numeroApertado.KeyChar)
              {
                #region 1 - Luz! 
                case '1':
                  ConsoleCores.WriteLine(ConsoleColor.Cyan, "Luz!");
                  WriteLine();
                  WriteLine();

                  List<Conta> contas = Database.Contas.FindAll(x => x.EstaPaga == false & x.Tipo == EnumTipo.Luz);

                  WriteLine();
                  WriteLine("  Digite o nº da opção desejada.");
                  WriteLine("____________________________________");
                  WriteLine("    1 - Voltar!                     ");
                  int indice = 2;
                  foreach (var conta in contas)
                  {
                    WriteLine($"    {indice} - {conta.Mes}");
                    indice++;
                  }
                  WriteLine("____________________________________");



                  break;
                #endregion
                #region 4 - Voltar!    
                case '4':
                  continuarContasPagar = false;
                  break;
                  #endregion
              }
            }
            break;
          #endregion
          #region 2 - Contas paga! 
          case '2':
            break;
          #endregion
          #region 3 - Informações sobre contas!
          case '3':
            break;
          #endregion
          #region 4 - Deslogar!
          case '4':
            return;
            #endregion
        }

      }
    }
    public static void CriarContasNoBancoDeDados()
    {
      #region Maio
      CriarConta(new Conta(EnumMes.Maio, EnumTipo.Luz, 270.34, false));
      CriarConta(new Conta(EnumMes.Maio, EnumTipo.Agua, 100.90, false));
      CriarConta(new Conta(EnumMes.Maio, EnumTipo.Condominio, 380, false));
      #endregion
    }

    public static void CriarConta(Conta conta)
     => Database.Contas.Add(conta);

  }
}
