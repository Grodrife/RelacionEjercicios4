using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float tiempoDestruccion = 2f;
    private GameManager gameManager;

    private float alturaCamara;
    private float anchoCamara;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tiempoDestruccion);
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        ComprobarPosicion();
        transform.localScale -= new Vector3(1f, 1f, 1f) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.DestruirEnemigo();
        }
    }

    private void ComprobarPosicion()
    {
        bool destruir = false;
        Vector2 posicion = transform.position;

        alturaCamara = Camera.main.orthographicSize;
        anchoCamara = alturaCamara * Screen.width / Screen.height;

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
