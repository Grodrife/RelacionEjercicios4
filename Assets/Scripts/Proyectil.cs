using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float tiempoDestruccion = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tiempoDestruccion);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
