
using UnityEngine;

public class SpawnerColetaveis : MonoBehaviour
{
    [Header("Prefab do item")]
    public GameObject prefabColetavel;

    [Header("Configuração")]
    public float intervaloSpawn = 3f;
    public int maxColetaveis = 10;

    [Header("Área de spawn")]
    public Vector2 limiteMinimo = new Vector2(-15f, -8f);
    public Vector2 limiteMaximo = new Vector2(15f, 8f);

    private float proximoSpawn;

    void Update()
    {
        if (Time.time >= proximoSpawn)
        {
            CriarColetavel();
            proximoSpawn = Time.time + intervaloSpawn;
        }
    }

    void CriarColetavel()
    {
        if (prefabColetavel == null) return;

        GameObject[] itens =
            GameObject.FindGameObjectsWithTag("Coletavel");

        if (itens.Length >= maxColetaveis) return;

        Vector2 posicao = new Vector2(
            Random.Range(limiteMinimo.x, limiteMaximo.x),
            Random.Range(limiteMinimo.y, limiteMaximo.y)
        );

        Instantiate(prefabColetavel, posicao, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

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

