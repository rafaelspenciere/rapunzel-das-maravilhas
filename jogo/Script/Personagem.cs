
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;

    [Header("Pulo")]
    public float forcaPulo = 12f;
    public int pulosMaximos = 2;

    [Header("Dash")]
    public float velocidadeDash = 15f;
    public float duracaoDash = 0.2f;
    public float tempoRecargaDash = 0.5f;

    private Rigidbody2D rb;
    private int pulosRestantes;
    private float direcao;
    private bool podeDash = true;
    private bool fazendoDash;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pulosRestantes = pulosMaximos;
    }

    void Update()
    {
        direcao = Input.GetAxisRaw("Horizontal");

        // Movimento horizontal
        if (!fazendoDash)
        {
            rb.linearVelocity = new Vector2(
                direcao * velocidade,
                rb.linearVelocity.y
            );
        }

        // Pulo duplo
        if (Input.GetButtonDown("Jump") && pulosRestantes > 0
            && !fazendoDash)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x, 0f
            );

            rb.AddForce(
                Vector2.up * forcaPulo,
                ForceMode2D.Impulse
            );

            pulosRestantes--;
        }

        // Dash com Shift
        if (Input.GetKeyDown(KeyCode.LeftShift) && podeDash)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        podeDash = false;
        fazendoDash = true;

        // Se não estiver apertando direção, usa a direção do personagem
        float direcaoDash = direcao;

        if (direcaoDash == 0)
        {
            direcaoDash = transform.localScale.x >= 0 ? 1 : -1;
        }

        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(
            direcaoDash * velocidadeDash, 0f
        );

        yield return new WaitForSeconds(duracaoDash);

        rb.gravityScale = 3f;
        fazendoDash = false;

        yield return new WaitForSeconds(tempoRecargaDash);
        podeDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            pulosRestantes = pulosMaximos;
        }
    }
}
