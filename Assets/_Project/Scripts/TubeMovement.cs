using UnityEngine;

public class TubeMovement : MonoBehaviour
{
    [SerializeField] float velocidad = 3f;
    [SerializeField] float limiteDestruccion = 20;

    float timer;

    void Start()
    {
        timer = limiteDestruccion;
    }

    void Update()
    {
        MoverTubo();
        
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void MoverTubo()
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
}