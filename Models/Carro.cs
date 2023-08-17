namespace SuperCarros.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public DateTime DataDeRegistro { get; set; }
        public bool Ativo { get; set; }

        internal void Atualizar(string nome, bool ativo)
        {
            this.Nome = nome;
            this.Ativo = ativo;
        }
    }
}
