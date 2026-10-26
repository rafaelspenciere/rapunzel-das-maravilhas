
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public int quantidade = 1;

    private bool coletado = false;

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (coletado) return;

        JogadorVida jogador = outro.GetComponentInParent<JogadorVida>();

        if (jogador == null)
            jogador = outro.GetComponentInChildren<JogadorVida>();

        if (jogador != null)
        {
            coletado = true;

            // Registra o item coletado
            ContadorColetaveis contador =
                jogador.GetComponent<ContadorColetaveis>();

            if (contador == null)
                contador = jogador.GetComponentInChildren<ContadorColetaveis>();

            if (contador != null)
            {
                contador.Adicionar(quantidade);
            }
            else
            {
                Debug.Log("Item coletado: " + quantidade);
            }

            Destroy(gameObject);
        }
    }
}
