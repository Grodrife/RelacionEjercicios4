using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 Script asociado al Game Manager del juego
 */
public class GameManager : MonoBehaviour
{
    // Elemento Text para mostrar la informacion de los botones
    [SerializeField] private Text infoText;
    // Elemento Text para mostrar el numero de enemigos eliminados
    [SerializeField] private Text enemigosEliminadosText;
    // Elemento Text para mostrar el tiempo transcurrido desde el inicio
    [SerializeField] private Text timerText;

    // Variable interna de apoyo para almacenar el estado del juego(True = corriendo)
    private bool gameRunning = false;
    // Variable interna de apoyo para almacenar el numero de enemigos eliminados durante la partida
    private int contadorEnemigos;
    // Variable interna de apoyo para almacenar el tiempo transcurrido desde el inicio
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        // Actualizacion del Text de los enemigos eliminados
        enemigosEliminadosText.text = "";
        enemigosEliminadosText.color = Color.white;
        // Actualizacion del Text del tiempo transcurrido
        timerText.text = "";
        timerText.color = Color.white;
        // Actualizacion del Text de la info de los botones
        infoText.color = Color.white;
        ActualizarInfo("Iniciar/Detener --- ESC\nMovimiento --- WASD\nDisparo --- Flechas");
    }

    // Update is called once per frame
    void Update()
    {
        // Comprobar estado del juego
        if (gameRunning)
        {
            // En caso de pulsar Escape, se reinicia el juego
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Se vuelve a cargar la escena
                SceneManager.LoadScene(0);
            }
            // Se actualiza constantemente el Timer
            ActualizarTimer();
        } else
        {
            // En caso de pulsar Escape, se inicia el juego
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Iniciar();
            }
        }
    }

    /*
     * Metodo de apoyo para iniciar el juego
     */
    private void Iniciar()
    {
        // Actualizacion del estado del juego
        gameRunning = true;
        // Recogida del tiempo al iniciar el juego
        startTime = Time.time;
        // Asignacion del contador de enemigos
        contadorEnemigos = 0;
        ActualizarContadorEnemigos();
    }

    /*
     * Metodo de apoyo para actualizar la informacion del tiempo transcurrido
     */
    private void ActualizarTimer()
    {
        // Variable del metodo para almacenar el tiemp transcurrido desde el inicio del juego
        float tiempo = Time.time - startTime;
        // Actualizacion del Text del tiempo
        timerText.text = "Tiempo: " + FormatTime(tiempo);
    }

    /*
     * Metodo de apoyo para actualizar la informacion mostrada
     */
    private void ActualizarInfo(string message)
    {
        infoText.text = message;
    }

    /*
     * Metodo de apoyo para actualizar el contador de enemigos eliminados
     */
    public void DestruirEnemigo()
    {
        // Aumento del contador
        contadorEnemigos++;
        ActualizarContadorEnemigos();
    }

    /*
     * Metodo de apoyo para actualizar el Text de los enemigos eliminados
     */
    private void ActualizarContadorEnemigos()
    {
        // Actualizacion del text de los enemigos eliminados
        enemigosEliminadosText.text = "Enemigos eliminados: " + contadorEnemigos;
    }

    /*
     * Metodo de apoyo para formatear el tiempo transcurrido
     * 
     * Return -- String
     */
    private string FormatTime(float tiempo)
    {
        // Division de los segundos entre 60 para obtener los minutos y se trunca pasando el resultado a Int
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        // Obtencion de los segundos restantes realizando el modulo de 60 a los segundos
        int segundosRestantes = Mathf.FloorToInt(tiempo % 60f);
        // Obtencion de las milesimas restantes
        int milesimas = Mathf.FloorToInt((tiempo - Mathf.Floor(tiempo)) * 100f);
        // Muestra del tiempo con el formato correcto
        return $"{minutos:D2}:{segundosRestantes:D2}.{milesimas:D2}";
    }

    /*
     * Metodo Getter de la variable gameRunning
     */
    public bool isGameRunning()
    {
        return gameRunning;
    }
}
