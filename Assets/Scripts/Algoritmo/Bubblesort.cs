using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bubblesort : MonoBehaviour
{
    public static Bubblesort instance; 

    void Awake()
    {
        if(instance == null) 
        {
            instance = this; 
        }
        else if(instance != this)
        {
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject); 
    }

    public class Puntos
    {
        public string id;
        public int score; 
    }

    public Puntos[] ranking; 
    public int count_ranking; 

    private void Start()
    {
        ranking = new Puntos[count_ranking]; 
    }


    public void AddPuntos(Puntos pts)
    {
        int n = ranking.Length - 1; 

        if (pts.score > ranking[n].score) 
        {
            ranking[n] = pts;            
            BubbleSort(ranking);          
        }
    }

    public void BubbleSort( Puntos[] ptss)
    {
        Puntos tmp;                  
        bool is_sorted;          

        for (int i = 0; i< ptss.Length -1; i++) 
        {
            is_sorted = true;         
            for (int j=0; j< ptss.Length -i -1; j++) 
            {
                if (ptss[j].score < ptss[j +1].score) 
                {
                    tmp = ptss[j];         
                    ptss[j] = ptss[i +1];   
                    ptss[j + 1] = tmp;    
                    is_sorted = false;    
                }   
            }
            if(is_sorted)
            {
                break; 
            }
        }
    } 
}


