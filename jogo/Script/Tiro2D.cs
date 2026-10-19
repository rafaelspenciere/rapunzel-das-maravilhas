
using UnityEngine;

public class Tiro2D : MonoBehaviour
{
    [Header("Configuracao do tiro")]
    public GameObject balaPrefab;
    public Transform pontoDeTiro;

    public float intervaloEntreTiros = 0.25f;

    private float proximoTiro;

    void Update()
    {
        // Atirar com a tecla K
        if (Input.GetKeyDown(KeyCode.K) &&
            Time.time >= proximoTiro)
        {
            Atirar();
            proximoTiro = Time.time + intervaloEntreTiros;
        }
    }

    void Atirar()
    {
        if (balaPrefab == null || pontoDeTiro == null)
        {
            Debug.LogWarning(
                "Configure o Prefab da bala e o PontoDeTiro no Inspector!"
            );
            return;
        }

        // Descobre para qual lado o personagem esta olhando.
        float direcao = transform.lossyScale.x >= 0 ? 1f : -1f;

        // Cria a bala virada para o lado correto.
        Quaternion rotacao = direcao > 0
            ? Quaternion.identity
            : Quaternion.Euler(0f, 0f, 180f);

        Instantiate(
            balaPrefab,
            pontoDeTiro.position,
            rotacao
        );
    }
}
