using SIND_Console.Entities;
using System;
using static System.Console;

namespace SIND_Console
{
  class Program
  {
    static void Main(string[] args)
    {
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

            break;
          #endregion
          #region 3 - Para sair do programa!
          case '3':
            sairPrograma = true;
            break;
            #endregion
        }
      }
      ConsoleCores.WriteLine(ConsoleColor.Red, "\n\n PROGRAMA FECHADO!!\n\n");
    }
  }
}
