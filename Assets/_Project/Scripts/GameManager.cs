using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject textMeshProUGUI;
    TextMeshProUGUI scoreText;
    float puntuacion = 0; 
    void Start()
    {
     scoreText = textMeshProUGUI.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    public void sumarPuntuacion()
    {
        puntuacion += 1;
        scoreText.text = puntuacion.ToString();
    }
}
