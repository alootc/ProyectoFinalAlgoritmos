using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moneda : MonoBehaviour
{
    public GameObject ObjPuntos;
    public float puntosQueDa;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Puntos puntosComponent = ObjPuntos.GetComponent<Puntos>();
            if (puntosComponent != null)
            {
                puntosComponent.puntos += puntosQueDa;
                Destroy(gameObject);

                if(puntosComponent.puntos >= 50)
                {
                    SceneManager.LoadScene(5);
                }
            }
        }
    }
}
