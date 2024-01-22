using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script asociado al generador de enemigos
 */
public class GeneradorEnemigos : MonoBehaviour
{
    // Variable para asociar el Prefab del enemigo
    [SerializeField] private GameObject enemigoPrefab;
    // Variable para almacenar el intervalo del generador
    [SerializeField] private float intervalo = 5;
    // Elemento asociado al Game Manager del juego
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        // Asociacion del elemento Game Manager
        gameManager = FindObjectOfType<GameManager>();
        // Comprobacion de Game Manager para evitar crasheos
        if ( gameManager != null )
        {
            // Llamada continua del metodo para generar enemigos
            InvokeRepeating(nameof(GenerarEnemigos), 0f, intervalo);
        }
    }

    /*
     * Metodo de apoyo para generar enemigos
     */
    void GenerarEnemigos()
    {
        // Comprobacion del estado del juego
        if ( gameManager.isGameRunning() ) 
        {
            // Generacion de una posicion aleatoria
            Vector2 posicion = new Vector2(Random.Range(-5f, 5f), Random.Range(-3f, 3f));
            // Creacion del enemigo
            Instantiate(enemigoPrefab, posicion, Quaternion.identity);
        }
    }
}
