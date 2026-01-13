using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI roundScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
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
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", 0f);
            PlayerPrefs.Save();
        }
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
        SaveScore();
        roundScoreText.text += scoreText.text;
        bestScoreText.text += PlayerPrefs.GetFloat("BestScore");
        Time.timeScale = 0;
    }

    public void Saltar()
    {
        audioSource.PlayOneShot(wing);
    }

    public void SaveScore()
    {
        float score = float.Parse(scoreText.text);

        if (score > PlayerPrefs.GetFloat("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", score);
            PlayerPrefs.Save();
        }
    }
}
