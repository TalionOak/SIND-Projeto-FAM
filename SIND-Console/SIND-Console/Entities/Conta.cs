using System;

namespace SIND_Console.Entities
{
  public class Conta
  {
    public EnumMes Mes { get; set; }
    public EnumTipo Tipo { get; set; }
    public double Valor { get; set; }
    public bool EstaPaga { get; set; }

    public string CodigoDeBarras { get; set; }

    public Conta(EnumMes mes, EnumTipo tipo, double valor, bool EstaPaga)
    {
      this.Mes = mes;
      this.Tipo = tipo;
      this.Valor = valor;
      this.EstaPaga = EstaPaga;
      Random randNum = new Random();
      CodigoDeBarras = $"{randNum.Next()}{randNum.Next()}{randNum.Next()}";
    }
  }
}