using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script asociado al jugador
 */
public class Jugador : MonoBehaviour
{
    // Variable que representa la velocidad de desplazamiento
    [SerializeField] private float velocidadMovimiento = 5f;
    // Variables para almacenar los inputs introducidos por el jugador
    private float horizontalInput;
    private float verticalInput;
    // Elemento asociado al Game Manager del juego
    private GameManager gameManager;
    // Variable para asociar el Prefab del proyectil
    [SerializeField] private GameObject proyectilPrefab;
    // Variable para almacenar la velocidad del proyectil
    [SerializeField] private float velocidadProyectil = 20f;
    // Variable para almacenar la cadencia de disparo del proyectil
    [SerializeField] private float cadenciaDisparo = 1f;
    // Variable interna para almacenar el momento del ultimo disparo realizado
    private float tiempoUltimoDisparo;
    // Variables de apoyo para las dimensiones de la camara
    private float alturaCamara;
    private float anchoCamara;
    void Start()
    {
        // Asociacion del elemento Game Manager
        gameManager = FindObjectOfType<GameManager>();
        // Inicializacion de la variable
        tiempoUltimoDisparo = -cadenciaDisparo;
    }

    // Update is called once per frame
    void Update()
    {
        // Comprobacion del estado del juego
        if (gameManager != null && gameManager.isGameRunning())
        {
            // Recogida de los inputs del jugador
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            // Desplazamiento del objeto en funcion de los inputs, la velocidad y el tiempo
            transform.Translate(new Vector2(horizontalInput, verticalInput) * velocidadMovimiento * Time.deltaTime);

            Disparo();
            ComprobarPosicion();
        }
        
    }

    /*
     * Metodo de apoyo para el disparo de proyectiles
     */
    void Disparo()
    {
        // En funcion de la direccion de disparo, se genera el proyectil en esa direccion
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Time.time - tiempoUltimoDisparo >= cadenciaDisparo)
            {
                GenerarProyectil(0f, 1f);
                tiempoUltimoDisparo = Time.time;
            }
            
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Time.time - tiempoUltimoDisparo >= cadenciaDisparo)
            {
                GenerarProyectil(0f, -1f);
                tiempoUltimoDisparo = Time.time;
            }
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Time.time - tiempoUltimoDisparo >= cadenciaDisparo)
            {
                GenerarProyectil(-1f, 0f);
                tiempoUltimoDisparo = Time.time;
            }
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Time.time - tiempoUltimoDisparo >= cadenciaDisparo)
            {
                GenerarProyectil(1f, 0f);
                tiempoUltimoDisparo = Time.time;
            }
            
        }
    }

    /*
     * Metodo de apoyo para generar el proyectil en funcion de las direcciones
     */
    private void GenerarProyectil(float horizontalProyectil, float verticalProyectil)
    {
        // Variable interna para almacenar el objeto del proyectil
        GameObject proyectil;
        // Variable para almacenar la direccion de disparo
        float angulo = Mathf.Atan2(verticalProyectil, horizontalProyectil) * Mathf.Rad2Deg;
        // Creacion del objeto del proyectil
        proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.Euler(0,0,angulo));
        // Modificacion de la velocidad del proyectil
        proyectil.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalProyectil, verticalProyectil).normalized * velocidadProyectil;
    }

    /*
     * Metodo de apoyo para comprobar la posicion del jugador
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
        } else if (posicion.x < -anchoCamara)
        {
            posicion.x = anchoCamara;
        }

        if (posicion.y > alturaCamara)
        {
            posicion.y = -alturaCamara;
        } else if(posicion.y < -alturaCamara)
        {
            posicion.y = alturaCamara;
        }

        transform.position = posicion;    
    }
}
