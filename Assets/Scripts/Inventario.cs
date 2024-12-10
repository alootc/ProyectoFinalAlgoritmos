using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //
    public static Inventario instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    //

    public int capacity;
    public ListaSimplemente<string> items = new();

    public event Action<string> onAddInventario;
    public event Action<string> onRemoveInventario;
    public event Action<string> onFullInventario;
    public event Action<string> onSelectItem;

    private void Start()
    {
        
        //items = new string[capacity];
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            items.PrintAllNodess();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            string elem = items[0];

            if (!string.IsNullOrEmpty(elem))
            {
                onSelectItem?.Invoke(elem);
                Debug.Log(" Item Seleccionado");
            }
        }
        
    }
    public bool AddInventario(string item)
    {
        if (items.Length == capacity)
        {
            Debug.Log("Inventario lleno");
            onFullInventario?.Invoke(item);
            return false;
        }

        items.InsertNodeEnd(item);
        onAddInventario?.Invoke(item);
        return true;

        //for(int i = 0; i < items.Length; i++)
        //{
        //    if (string.IsNullOrEmpty(items[i]))
        //    {
        //        items[i] = item;
        //        onAddInventario?.Invoke(item);
        //        return true;
        //    }
        //}

    }

    public void RemoveInventorio(string item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                items[i] = "";
                onRemoveInventario?.Invoke(item);
                return;
            }
        }
        Debug.LogWarning("Item no encontrado");
    }
    public bool GetInventario(string item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                return true;
            }
        }
        //Debug.Log($"Item not found: {item}");
        return false;
    }
}
