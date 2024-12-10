using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public float puntos;
    public Text textoPuntos;

    private void Update()
    {
        textoPuntos.text = "Puntos: " + puntos.ToString() + "/50";

        if(puntos < 0)
        {
            puntos = 0;
        }

    }

}
    