using TMPro;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI roundScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    [SerializeField] float velocidadTubos = 1f;
    [SerializeField] float velocidadSubir = 1f;


    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject score;

    [SerializeField] AudioClip die;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip point;
    [SerializeField] AudioClip swoosh;
    [SerializeField] AudioClip wing;


    AudioSource audioSource;

    float puntuacion = 0;
    float timeSinceDeath = 0f;
    float deathDelay = 1f;
    bool isAlive = true;

    
    void Start()
    {
        scoreText.text = "0";
        
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", 0f);
            PlayerPrefs.Save();
        }
        
        PlayerPrefs.SetFloat("VelocidadTubos", 2f);
        
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 0;
    }

    void Update()
    {
        if (!isAlive)
        {
            timeSinceDeath += Time.unscaledDeltaTime;
        }
    }

    public void sumarPuntuacion()
    {
        audioSource.PlayOneShot(point);
        puntuacion += 1;
        scoreText.text = puntuacion.ToString();

        if (puntuacion % 10 == 0)
        {
            float velocidadActual = PlayerPrefs.GetFloat("VelocidadTubos");
            PlayerPrefs.SetFloat("VelocidadTubos", velocidadActual + velocidadSubir);
        }
    }

    public void Die()
    {
        audioSource.PlayOneShot(hit);
        score.SetActive(false);
        gameOver.SetActive(true);
        audioSource.PlayOneShot(swoosh);
        isAlive = false;
        timeSinceDeath = 0f;
        SaveScore();
        roundScoreText.text += scoreText.text;
        bestScoreText.text += PlayerPrefs.GetFloat("BestScore");
        Time.timeScale = 0;
    }

    public void Saltar()
    {
        audioSource.PlayOneShot(wing);
    }

    void SaveScore()
    {
        float score = float.Parse(scoreText.text);

        if (score > PlayerPrefs.GetFloat("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", score);
            PlayerPrefs.Save();
        }
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && !isAlive && timeSinceDeath >= deathDelay)
        {
            SceneManager.LoadScene("MainSave");
        }
        if (value.isPressed && isAlive && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("MainSave");
    }
}