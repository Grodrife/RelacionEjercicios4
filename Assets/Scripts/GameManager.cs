using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text infoText;
    [SerializeField] private Text enemigosEliminadosText;
    [SerializeField] private Text timerText;

    private bool gameRunning = false;
    private int contadorEnemigos;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        enemigosEliminadosText.text = "";
        enemigosEliminadosText.color = Color.white;
        infoText.color = Color.white;
        timerText.text = "";
        timerText.color = Color.white;
        ActualizarInfo("Presiona ESPACIO para iniciar el programa.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameRunning)
        {
            Iniciar();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && gameRunning)
        {
            Parar();
        }

        if (gameRunning)
        {
            ActualizarTimer();
        }
    }

    private void Iniciar()
    {
        gameRunning = true;
        startTime = Time.time;
        contadorEnemigos = 0;

        ActualizarInfo("");
        ActualizarContadorEnemigos();
    }

    private void Parar()
    {
        gameRunning = false;
        enemigosEliminadosText.text = "";
        timerText.text = "";
        ActualizarInfo("Presiona ESPACIO para iniciar el programa.");
    }

    private void ActualizarTimer()
    {
        float tiempo = Time.time - startTime;
        timerText.text = "Tiempo: " + FormatTime(tiempo);
    }

    private void ActualizarInfo(string message)
    {
        infoText.text = message;
    }

    public void DestruirEnemigo()
    {
        contadorEnemigos++;
        ActualizarContadorEnemigos();
    }

    private void ActualizarContadorEnemigos()
    {
        enemigosEliminadosText.text = "Enemigos eliminados: " + contadorEnemigos;
    }

    private string FormatTime(float segundos)
    {
        int minutos = Mathf.FloorToInt(segundos / 60f);
        int segundosRestantes = Mathf.FloorToInt(segundos % 60f);
        int milesimas = Mathf.FloorToInt((segundos - Mathf.Floor(segundos)) * 100f);

        return $"{minutos:D2}:{segundosRestantes:D2}.{milesimas:D2}";
    }

    public bool isGameRunning()
    {
        return gameRunning;
    }
}
