using UnityEngine;

public class TubeMovement : MonoBehaviour
{
    [SerializeField] float velocidad = 1f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        MoverTubo();
    }

    void MoverTubo()
    {
        Vector2 rbPosition = rb.position;
        rbPosition.x -= velocidad * Time.deltaTime;
        rb.position = rbPosition;
    }
}
