using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Text[] texto;
    


    void Start()
    {
       
        Inventario.instance.onAddInventario += AddInvenarioUI;
        
    }

    private void OnDestroy()
    {
        Inventario.instance.onAddInventario -= AddInvenarioUI;
        
    }

    private void AddInvenarioUI(string id)
    {
        for (int i = 0; i < texto.Length; i++)
        {
            if (string.IsNullOrEmpty(texto[i].text))
            {
                texto[i].text = id;
                return;
            }
        }
    }

   
}
