using System;
using System.Collections.Generic;
using System.Text;

namespace SIND_Console
{
  public static class ConsoleCores
  {
    public static void Write(ConsoleColor cor, string mensagem)
    {
      Console.ForegroundColor = cor;
      Console.Write(mensagem);
      Console.ResetColor();
    }

    public static void WriteLine(ConsoleColor cor, string mensagem)
    {
      Console.ForegroundColor = cor;
      Console.WriteLine(mensagem);
      Console.ResetColor();
    }
  }
}
