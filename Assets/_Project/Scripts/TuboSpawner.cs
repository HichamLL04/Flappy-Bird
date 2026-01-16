using UnityEngine;

public class TuboSpawner : MonoBehaviour
{
    [SerializeField] GameObject tuboPar;
    [SerializeField] float distanciaEntreTubos = 6f;
    [SerializeField] float posicionSpawnX = 10f;
    [SerializeField] float alturaMinima = -1.05f;
    [SerializeField] float alturaMaxima = 2.30f;
    
    private float timer;
    
    void Start()
    {
        timer = CalcularTiempoSpawn();
    }
    
    void Update()
    {
        if (!GameManager.hasStarted) return;
        
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            SpawnTubo();
            timer = CalcularTiempoSpawn();
        }
    }
    
    float CalcularTiempoSpawn()
    {
        float velocidad = PlayerPrefs.GetFloat("VelocidadTubos", 2f);
        return distanciaEntreTubos / velocidad;
    }
    
    void SpawnTubo()
    {
        Vector3 spawnPos = new Vector3(posicionSpawnX, Random.Range(alturaMinima, alturaMaxima), 0);
        Instantiate(tuboPar, spawnPos, Quaternion.identity);
    }
}