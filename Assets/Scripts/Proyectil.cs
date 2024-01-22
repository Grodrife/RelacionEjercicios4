using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script asociado a los proyectiles disparados
 */
public class Proyectil : MonoBehaviour
{
    // Variable interna para almacenar el tiempo que debe transcurrir para destruir el proyectil
    [SerializeField] private float tiempoDestruccion = 2f;
    // Elemento asociado al Game Manager del juego
    private GameManager gameManager;
    // Variables de apoyo para las dimensiones de la camara
    private float alturaCamara;
    private float anchoCamara;

    // Start is called before the first frame update
    void Start()
    {
        // Destruccion del proyectil cuando pase el tiempo requerido
        Destroy(gameObject, tiempoDestruccion);
        // Asociacion del elemento Game Manager
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        ComprobarPosicion();
        // Modificacion de la escala
        transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // En caso de colisionar con un enemigo, destruye ambos y actualiza el valor
        if (other.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.DestruirEnemigo();
        }
    }

    /*
     * Metodo para comprobar si esta fuera de camara
     */
    private void ComprobarPosicion()
    {
        // Variable de apoyo del metodo para almacenar si el objeto debe ser destruido
        bool destruir = false;
        // Recogida de la posicion actual del objeto
        Vector2 posicion = transform.position;
        // Recogida del tamaño de la camara en este momento
        alturaCamara = Camera.main.orthographicSize;
        anchoCamara = alturaCamara * Screen.width / Screen.height;

        // Si las posiciones sobrepasan el ancho/largo, el objeto se destruye
        if (posicion.x > anchoCamara)
        {
            destruir = true;
        }
        else if (posicion.x < -anchoCamara)
        {
            destruir = true;
        }

        if (posicion.y > alturaCamara)
        {
            destruir = true;
        }
        else if (posicion.y < -alturaCamara)
        {
            destruir = true;
        }

        if (destruir) {
            Destroy(gameObject);
        }
    }
}
