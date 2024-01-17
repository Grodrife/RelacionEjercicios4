using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField] private float velocidadMovimiento = 5f;
    private float ejeX;
    private float ejeY;

    private GameManager gameManager;
    private float alturaCamara;
    private float anchoCamara;

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        

        if ( gameManager != null )
        {
            rigidBody = GetComponent<Rigidbody2D>();
            
            InvokeRepeating(nameof(GenerarDireccion), 0f, Random.Range(1f, 5f));
        }
        
    }

    void Update()
    {
        if ( gameManager != null && gameManager.isGameRunning())
        {
            Mover();
            ComprobarPosicion();
        }
        
    }

    private void Mover()
    {
        transform.Translate(new Vector2(ejeX, ejeY).normalized * velocidadMovimiento * Time.deltaTime);
    }

    private void GenerarDireccion()
    {
        ejeX = Random.Range(-1f, 1f);
        ejeY = Random.Range(-1f, 1f);
    }

    private void ComprobarPosicion()
    {
        Vector2 posicion = transform.position;

        alturaCamara = Camera.main.orthographicSize;
        anchoCamara = alturaCamara * Screen.width / Screen.height;

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
