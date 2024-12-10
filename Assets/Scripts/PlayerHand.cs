using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{

    public Transform pivot_hand;

    private void Start()
    {
        Inventario.instance.onSelectItem += CreateItem;

    }

    private void OnDestroy()
    {
        Inventario.instance.onSelectItem -= CreateItem;
    }

    private void CreateItem(string id)
    {
        GameObject go = Items.instance.GetPrefab(id);
        if(go != null)
        {
           GameObject prefab = Instantiate(go, pivot_hand);
            prefab.transform.localPosition = Vector3.zero;
        }
        
    }

}
