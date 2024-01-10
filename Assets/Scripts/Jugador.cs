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

    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float velocidadProyectil = 20f;

    // Update is called once per frame
    void Update()
    {
        float horizontalProyectil;
        float verticalProyectil;
        // Recogida de los inputs del jugador
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Desplazamiento del objeto en funcion de los inputs, la velocidad y el tiempo
        transform.Translate(new Vector2(horizontalInput, verticalInput) * velocidadMovimiento * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            horizontalProyectil = 0f;
            verticalProyectil = 1f;
            GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
            proyectil.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalProyectil, verticalProyectil).normalized * velocidadProyectil;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
               {
                   horizontalProyectil = 0f;
                   verticalProyectil = -1f;
                   GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
                   proyectil.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalProyectil, verticalProyectil).normalized * velocidadProyectil;
               } else if (Input.GetKeyDown(KeyCode.LeftArrow))
                      {
                          horizontalProyectil = -1f;
                          verticalProyectil = 0f;
                          GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
                          proyectil.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalProyectil, verticalProyectil).normalized * velocidadProyectil;
                      } else if (Input.GetKeyDown(KeyCode.RightArrow))
                             {
                                 horizontalProyectil = 1f;
                                 verticalProyectil = 0f;
                                 GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
                                 proyectil.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalProyectil, verticalProyectil).normalized * velocidadProyectil;
                             }
    }
}
