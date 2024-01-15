using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    // Variable que representa la velocidad de desplazamiento
    [SerializeField] private float velocidadMovimiento = 5f;
    // Variables para almacenar los inputs introducidos por el jugador
    private float horizontalInput;
    private float verticalInput;

    private GameManager gameManager;

    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float velocidadProyectil = 20f;
    [SerializeField] private float cadenciaDisparo = 0.5f;

    private float tiempoUltimoDisparo;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        tiempoUltimoDisparo = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager != null && gameManager.isGameRunning())
        {
            // Recogida de los inputs del jugador
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            // Desplazamiento del objeto en funcion de los inputs, la velocidad y el tiempo
            transform.Translate(new Vector2(horizontalInput, verticalInput) * velocidadMovimiento * Time.deltaTime);

            Disparo();
        }
        
    }

    void Disparo()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Time.time - tiempoUltimoDisparo >= cadenciaDisparo)
            {
                GenerarProyectil(0f, 1f);
                tiempoUltimoDisparo = Time.time;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Time.time - tiempoUltimoDisparo >= cadenciaDisparo)
            {
                GenerarProyectil(0f, -1f);
                tiempoUltimoDisparo = Time.time;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Time.time - tiempoUltimoDisparo >= cadenciaDisparo)
            {
                GenerarProyectil(-1f, 0f);
                tiempoUltimoDisparo = Time.time;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Time.time - tiempoUltimoDisparo >= cadenciaDisparo)
            {
                GenerarProyectil(1f, 0f);
                tiempoUltimoDisparo = Time.time;
            }
            
        }
    }

    private void GenerarProyectil(float horizontalProyectil, float verticalProyectil)
    {
        GameObject proyectil;
        float angulo = Mathf.Atan2(verticalProyectil, horizontalProyectil) * Mathf.Rad2Deg;
        proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.Euler(0,0,angulo));
        proyectil.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalProyectil, verticalProyectil).normalized * velocidadProyectil;
    }
}
