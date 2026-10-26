
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Movimentação")]
    public float velocidade = 3f;

    private Transform jogador;
    private Rigidbody2D rb;

    [Header("Vida do Inimigo")]
    public int vidaMaxima = 3;
    private int vidaAtual;

    [Header("Dano ao Jogador")]
    public int dano = 1;
    public float intervaloDano = 1f;

    private float proximoDano;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        vidaAtual = vidaMaxima;
    }

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            jogador = player.transform;
        }
        else
        {
            Debug.LogError("ERRO: nenhum objeto com a Tag Player!");
        }
    }

    // PERSEGUIR O JOGADOR
    void FixedUpdate()
    {
        if (jogador == null || rb == null)
            return;

        Vector2 direcao =
            ((Vector2)jogador.position - rb.position).normalized;

        rb.MovePosition(
            rb.position + direcao * velocidade * Time.fixedDeltaTime
        );
    }

    // DETECTAR COLISAO NORMAL
    void OnCollisionEnter2D(Collision2D colisao)
    {
        VerificarContato(colisao.gameObject);
    }

    void OnCollisionStay2D(Collision2D colisao)
    {
        VerificarContato(colisao.gameObject);
    }

    // DETECTAR TRIGGER
    void OnTriggerEnter2D(Collider2D outro)
    {
        VerificarContato(outro.gameObject);
    }

    void OnTriggerStay2D(Collider2D outro)
    {
        VerificarContato(outro.gameObject);
    }

    // VERIFICAR SE O OBJETO E O JOGADOR
    void VerificarContato(GameObject objeto)
    {
        JogadorVida vida = objeto.GetComponentInParent<JogadorVida>();

        if (vida == null)
            vida = objeto.GetComponentInChildren<JogadorVida>();

        if (vida == null)
            return;

        if (Time.time < proximoDano)
            return;

        proximoDano = Time.time + intervaloDano;

        Debug.Log("CONTATO DETECTADO! Aplicando dano ao jogador.");

        vida.ReceberDano(dano);
    }

    // RECEBER DANO DOS PROJETEIS
    public void ReceberDano(int quantidade)
    {
        vidaAtual -= quantidade;
        vidaAtual = Mathf.Max(vidaAtual, 0);

        Debug.Log("Vida do inimigo: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Destroy(gameObject);
        }
    }
}
