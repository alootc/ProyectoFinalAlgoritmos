using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaSimplemente<T>
{
    private class Node
    {
        public T value { get; set; }      // 1 ASIGNACIÓN = 1

        public Node Next{ get; set; }       // 1 ASIGNACIÓN = 1

        public Node(T t)
        {
            value = t;                 // 1 ASIGNACIÓN = 1
            Next = null;              // 1 ASIGNACIÓN = 1
        }
    }
    private Node head;                     // 1 DECLARACIÓN = 1
    public int length = 0;                // 1 DECLARACIÓN = 1
    public int Length { get { return length; } }       // 1 ACCESO = 1

    public void InsertNodeStart(T value)      // 1 CREACIÓN + 1 ASIGNACIÓN = 2
    {
        Node new_node = new Node(value);   // 1 CREACIÓN + 1 ASIGNACIÓN = 2
        if (head == null)                  // 2 + MAX(interna IF)
        {
            head = new_node;              // 1 ASIGNACIÓN = 1
        }
        else
        {
            new_node.Next = head;          // ASIGNACIÓN = 1
            head = new_node;               // 1 ASIGNACIÓN = 1
        }
        length = length + 1;               // 1 ASIGNACIÓN + 1 OPERACION = 2
    }

    public void InsertNodeEnd(T value)
    {
        Node new_node = new Node(value);   // 1 CREACIÓN + 1 ASIGNACIÓN = 2

        if (head == null)                    // 2 + MAX(interna IF)
        {
            head = new_node;               // 1 ASIGNACIÓN = 1
        }
        else
        {
            Node tmp = head;                // 1 ASIGNACIÓN = 1

            while (tmp.Next != null)        // 2 + N(MAX(interna))
            {
                tmp = tmp.Next;            // 1 ASIGNACIÓN = 1
            }
            tmp.Next = new_node;          // 1 ASIGNACIÓN = 1
        }
        length++;                           // 1 ASIGNACIÓN + 1 OPERACION = 2
    }

    //public bool Contains(T value)
    //{
    //    Node tmp = head;
    //    while (tmp != null)
    //    {
    //        if (tmp.value.Equals(value))
    //        {
    //            return true;
    //        }
    //        tmp = tmp.Next;
    //    }
    //    return false;
    //}

    public void PrintAllNodess()
    {
        Node tmp = head;                      // 1 CREACIÓN + 1 ASIGNACIÓN = 2
        while (tmp != null)                   // 2 + N(MAX(interna))
        {
            Debug.Log(tmp.value + " ");     // 1 ESCRITURA + 2 OPERACION = 3
            tmp = tmp.Next;                 // 1 ASIGNACIÓN = 1
        }
        Debug.Log("");                        // 1 ESCRITURA = 1
    }

    public T this[int index]
    {
        get
        {
            Node current = head;                 // 1 ASIGNACIÓN = 1
            for (int i = 0; i < index; i++)       // 1 + IN(1 + interna + 2)
            {
                if (current == null)              // 2 + MAX(interna IF)
                {
                    return default(T);               // 1 OPERACION = 1
                }
                current = current.Next;           // 1 ASIGNACIÓN = 1
            }
            return current != null ? current.value : default(T);      // 1 OPERACION + 2 OPERACION = 3
        }
        set
        {
            Node current = head;                  // 1 ASIGNACIÓN = 1
            for (int i = 0; i < index; i++)          // 1 + In(1 + interna + 2)
            {
                if (current == null)               // 2 + MAX(interna IF)
                {
                    return;                         // 1 OPERACION = 1
                } 
                current = current.Next;           // 1 ASIGNACIÓN = 1
            }
            if (current != null)                  // 2 + MAX(interna IF)
            {
                current.value = value;            // 1 ASIGNACIÓN = 1  
            }
        }
    }
}

// DETALLADO 51+14N
// ASINTOTICO: O(n)
