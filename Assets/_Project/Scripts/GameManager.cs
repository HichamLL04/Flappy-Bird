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
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject score;

    [SerializeField] AudioClip die;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip point;
    [SerializeField] AudioClip swoosh;
    [SerializeField] AudioClip wing;


    AudioSource audioSource;

    float puntuacion = 0;
    bool isAlive = true;
    void Start()
    {
        scoreText.text = "0";
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetFloat("BestScore", 0f);
            PlayerPrefs.Save();
        }
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 0;
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
        score.SetActive(false);
        gameOver.SetActive(true);
        audioSource.PlayOneShot(swoosh);
        isAlive = false;
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
        if (value.isPressed && !isAlive)
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
