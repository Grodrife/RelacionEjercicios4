using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private float intervalo;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        if ( gameManager != null )
        {
            InvokeRepeating(nameof(GenerarEnemigos), 0f, intervalo);
        }
    }

    void GenerarEnemigos()
    {
        if ( gameManager.isGameRunning() ) 
        {
            Vector2 posicion = new Vector2(Random.Range(-5f, 5f), Random.Range(-3f, 3f));
            Instantiate(enemigoPrefab, posicion, Quaternion.identity);
        }
    }
}
