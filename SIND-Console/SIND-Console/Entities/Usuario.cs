namespace SIND_Console.Entities
{
  public class Usuario
  {
    public Usuario(string nome, string senha, string email, string bloco, string apartamento)
    {
      this.Nome = nome;
      this.Senha = senha;
      this.Email = email;
      this.Bloco = bloco;
      this.Apartamento = apartamento;
    }

    public Usuario() { }

    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Bloco { get; set; }
    public string Apartamento { get; set; }
  }
}
