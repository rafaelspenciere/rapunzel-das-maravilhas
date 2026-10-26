
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Inimigo")]
    public GameObject prefabInimigo;

    [Header("Configuração")]
    public float intervaloSpawn = 2f;
    public int maxInimigos = 10;

    [Header("Área do mapa")]
    public Vector2 limiteMinimo = new Vector2(-15f, -8f);
    public Vector2 limiteMaximo = new Vector2(15f, 8f);

    private float proximoSpawn;

    void Update()
    {
        if (Time.time >= proximoSpawn)
        {
            CriarInimigo();
            proximoSpawn = Time.time + intervaloSpawn;
        }
    }

    void CriarInimigo()
    {
        if (prefabInimigo == null) return;

        GameObject[] inimigos =
            GameObject.FindGameObjectsWithTag("Enemy");

        if (inimigos.Length >= maxInimigos) return;

        Vector2 posicao = new Vector2(
            Random.Range(limiteMinimo.x, limiteMaximo.x),
            Random.Range(limiteMinimo.y, limiteMaximo.y)
        );

        Instantiate(prefabInimigo, posicao, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 centro = new Vector3(
            (limiteMinimo.x + limiteMaximo.x) / 2f,
            (limiteMinimo.y + limiteMaximo.y) / 2f,
            0f
        );

        Vector3 tamanho = new Vector3(
            limiteMaximo.x - limiteMinimo.x,
            limiteMaximo.y - limiteMinimo.y,
            0f
        );

        Gizmos.DrawWireCube(centro, tamanho);
    }
}
