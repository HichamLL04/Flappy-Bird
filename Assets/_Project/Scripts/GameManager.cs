using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOver;
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
        audioSource.PlayOneShot(hit);
        gameOver.SetActive(true);
        audioSource.PlayOneShot(swoosh);
        Time.timeScale = 0;
    }

    public void Saltar()
    {
        audioSource.PlayOneShot(wing);
    }
}
