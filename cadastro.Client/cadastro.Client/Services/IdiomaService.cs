namespace cadastro.Client.Services
{
    public class IdiomaService
    {
        public string IdiomaAtual { get; private set; } = "PORTUGUÊS";

        public event Action OnChange;

        public void MudarIdioma(string novoIdioma)
        {
            IdiomaAtual = novoIdioma;
            OnChange?.Invoke(); // avisa os componentes que o idioma mudou
        }
    }
}
