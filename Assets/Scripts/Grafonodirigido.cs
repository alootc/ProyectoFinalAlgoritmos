using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafonodirigidolab : MonoBehaviour
{
    public int cost_energy;
    public Grafonodirigidolab[] list_nodos;


    public Grafonodirigidolab GetNodeRandom()
    {
        return list_nodos[Random.Range(0, list_nodos.Length)];
    }


}
