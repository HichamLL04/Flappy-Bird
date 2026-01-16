using UnityEngine;

public class TubeMovement : MonoBehaviour
{
    [SerializeField] float limiteDestruccion = 20;

    float timer;

    void Start()
    {
        timer = limiteDestruccion;
        
        if (!PlayerPrefs.HasKey("VelocidadTubos"))
        {
            PlayerPrefs.SetFloat("VelocidadTubos", 2f);
        }
    }

    void Update()
    {
        if (!GameManager.hasStarted) return;
        
        MoverTubo();
        
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void MoverTubo()
    {
        float velocidad = PlayerPrefs.GetFloat("VelocidadTubos");
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
}