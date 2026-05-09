using System;

namespace cadastro.Shared.Models
{
    public class NotificacaoState
{
    public int Contador { get; set; }
    public event Action? OnChange;
    
    // Lista para guardar os IDs que o usuário já "limpou" visualmente
    public List<int> IdsLidos { get; set; } = new List<int>();

    public void Zerar()
    {
        Contador = 0;
        NotifyStateChanged();
    }

    public void SetContador(int valor)
    {
        Contador = valor;
        NotifyStateChanged();
    }

    public void NovoAlerta()
    {
         Contador++;
         NotifyStateChanged();
    }



        private void NotifyStateChanged() => OnChange?.Invoke();
}
}