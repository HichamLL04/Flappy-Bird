using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI roundScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    [SerializeField] float velocidadTubos = 2f;
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
    
    public static bool hasStarted = false;

    void Start()
    {
        Time.timeScale = 1;
        
        scoreText.text = "0";
        
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", 0f);
            PlayerPrefs.Save();
        }
        
        PlayerPrefs.SetFloat("VelocidadTubos", velocidadTubos);
        
        audioSource = GetComponent<AudioSource>();
        hasStarted = false;
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

        if (puntuacion % 5 == 0)
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
        
        if (!hasStarted)
        {
            hasStarted = true;
        }
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

    public void ReloadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("WebSave");
    }
}