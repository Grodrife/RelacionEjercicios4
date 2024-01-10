using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private float intervalo;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(GenerarEnemigos), 0f, intervalo);
    }

    void GenerarEnemigos()
    {
        Vector2 posicion = new Vector2(Random.Range(-5f, 5f), Random.Range(-3f, 3f));
        Instantiate(enemigoPrefab, posicion, Quaternion.identity);
    }
}
