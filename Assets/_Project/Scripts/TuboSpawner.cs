using UnityEngine;

public class TuboSpawner : MonoBehaviour
{
    [SerializeField] GameObject tuboPar;
    [SerializeField] float tiempoEntreSpawns = 2f;
    [SerializeField] float posicionSpawnX = 10f;
    [SerializeField] float alturaMinima = -1.05f;
    [SerializeField] float alturaMaxima = 2.30f;
    
    private float timer;
    
    void Start()
    {
        timer = tiempoEntreSpawns;
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            SpawnTubo();
            timer = tiempoEntreSpawns;
        }
    }
    
    void SpawnTubo()
    {
        Vector3 spawnPos = new Vector3(posicionSpawnX, Random.Range(alturaMinima, alturaMaxima), 0);
        Instantiate(tuboPar, spawnPos, Quaternion.identity);
    }
}