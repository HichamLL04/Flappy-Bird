using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float fuerzaSalto = 5f;
    [SerializeField] float gravedadBajada = 3f;
    [SerializeField] GameManager gameManager;

    Rigidbody2D rb;
    bool isAlive = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (gravedadBajada - 1) * Time.deltaTime;
        }
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && isAlive)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            gameManager.Saltar();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Suelo") || collision.gameObject.layer == LayerMask.NameToLayer("Tubos"))
        {
            gameManager.Die();
            isAlive = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Punto"))
        {
            gameManager.sumarPuntuacion();
        }

    }
}