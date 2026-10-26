
using UnityEngine;

public class ContadorColetaveis : MonoBehaviour
{
    public int totalColetado = 0;

    public void Adicionar(int quantidade)
    {
        totalColetado += quantidade;

        Debug.Log("Itens coletados: " + totalColetado);
    }
}

