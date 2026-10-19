using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Jogador")]
    public Transform jogador;

    [Header("Configurações")]
    public float suavidade = 5f;
    public Vector3 offset = new Vector3(0f, 1f, -10f);

    void LateUpdate()
    {
        if (jogador == null) return;

        Vector3 posicaoDesejada = jogador.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            posicaoDesejada,
            suavidade * Time.deltaTime
        );
    }
}