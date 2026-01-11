using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioClip die;
    [SerializeField] AudioClip hit;

    [SerializeField] AudioClip point;

    [SerializeField] AudioClip swoosh;

    [SerializeField] AudioClip wing;

    AudioSource audioSource;

    float puntuacion = 0;
    void Start()
    {
        scoreText.text = "0";
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void sumarPuntuacion()
    {
        audioSource.PlayOneShot(point);
        puntuacion += 1;
        scoreText.text = puntuacion.ToString();
        
    }

    public void Die()
    {
        Time.timeScale = 0;
    }

    public void Saltar()
    {
        audioSource.PlayOneShot(wing);
    }
}
