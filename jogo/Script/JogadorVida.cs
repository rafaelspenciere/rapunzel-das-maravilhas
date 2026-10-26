
using UnityEngine;

public class JogadorVida : MonoBehaviour
{
    public int vidaMaxima = 10;
    public int vidaAtual;

    void Awake()
    {
        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(int quantidade)
    {
        vidaAtual = Mathf.Max(0, vidaAtual - quantidade);

        Debug.Log("DANO RECEBIDO! Vida atual: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Debug.Log("JOGADOR MORREU!");
            gameObject.SetActive(false);
        }
    }
}
