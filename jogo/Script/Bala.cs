
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bala : MonoBehaviour
{
    public float velocidade = 12f;
    public float tempoDeVida = 3f;
    public int dano = 1;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.gravityScale = 0f;
        rb.linearVelocity = transform.right * velocidade;

        Destroy(gameObject, tempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
            return;

        if (outro.CompareTag("Enemy"))
        {
            // A bala destroi o inimigo.
            // Adapte se o inimigo tiver um sistema de vida.
            Destroy(outro.gameObject);
            Destroy(gameObject);
            return;
        }

        if (!outro.isTrigger)
        {
            // Destrói a bala ao atingir uma parede.
            Destroy(gameObject);
        }
    }
}
