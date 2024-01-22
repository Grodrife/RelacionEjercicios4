using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script asociado a los enemigos generados
 */
public class Enemigo : MonoBehaviour
{
    // Variable interna asociada a la velocidad de movimiento del enemigo
    [SerializeField] private float velocidadMovimiento = 5f;
    // Variables de apoyo para la generacion de una nueva direccion
    private float ejeX;
    private float ejeY;
    // Elemento asociado al Game Manager del juego
    private GameManager gameManager;
    // Variables de apoyo para las dimensiones de la camara
    private float alturaCamara;
    private float anchoCamara;

    
    // Start is called before the first frame update
    void Start()
    {
        // Asociacion del elemento Game Manager
        gameManager = FindObjectOfType<GameManager>();

        // Comprobacion de Game Manager para evitar crasheos
        if ( gameManager != null )
        {
            // Llamada continua al metodo para generar una nueva direccion
            InvokeRepeating(nameof(GenerarDireccion), 0f, Random.Range(1f, 5f));
        }
        
    }

    void Update()
    {
        // Comprobacion del estado del juego
        if ( gameManager != null && gameManager.isGameRunning())
        {
            Mover();
            ComprobarPosicion();
        }
    }

    /*
     * Metodo de apoyo para el movimiento del enemigo
     */
    private void Mover()
    {
        // Actualizacion de la direccion del enemigo y desplazamiento
        transform.Translate(new Vector2(ejeX, ejeY).normalized * velocidadMovimiento * Time.deltaTime);
    }

    /*
     * Metodo de apoyo para generar una direccion nueva
     */
    private void GenerarDireccion()
    {
        // Direccion nueva, valores entre -1 y 1
        ejeX = Random.Range(-1f, 1f);
        ejeY = Random.Range(-1f, 1f);
    }

    /*
     * Metodo de apoyo para comprobar si se sobrepasa los limites
     */
    private void ComprobarPosicion()
    {
        // Recogida de la posicion actual del objeto
        Vector2 posicion = transform.position;
        // Recogida del tamaño de la camara en este momento
        alturaCamara = Camera.main.orthographicSize;
        anchoCamara = alturaCamara * Screen.width / Screen.height;

        // Si las posiciones sobrepasan el ancho/largo, el objeto se teletransporta a lado opuesto
        if (posicion.x > anchoCamara)
        {
            posicion.x = -anchoCamara;
        }
        else if (posicion.x < -anchoCamara)
        {
            posicion.x = anchoCamara;
        }

        if (posicion.y > alturaCamara)
        {
            posicion.y = -alturaCamara;
        }
        else if (posicion.y < -alturaCamara)
        {
            posicion.y = alturaCamara;
        }
        
        transform.position = posicion;
    }
}
