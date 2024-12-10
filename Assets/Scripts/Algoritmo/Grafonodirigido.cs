using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafonodirigido : MonoBehaviour
{
    //public int cost_energy;
    public Grafonodirigido[] list_nodes;


    public Grafonodirigido GetNodeRandom()
    {
        return list_nodes[Random.Range(0,list_nodes.Length)];
    }
}
