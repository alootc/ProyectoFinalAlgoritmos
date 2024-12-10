using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cronometro;    

    private float timerElapsed = 300f;                     
    private int minutos, segundos;                        


    void Start()
    {
        
    }
    
    void Update()
    {

        timerElapsed -= Time.deltaTime;                      

        if(timerElapsed < 0)                           
        {
            timerElapsed = 0;                                
        }

        minutos = (int)(timerElapsed / 60f);              
        segundos = (int)(timerElapsed - minutos * 60f);           

        string txt_timer = string.Format("{0:00} : {1:00} ", minutos, segundos);   
        cronometro.text = txt_timer;                                              

        if (timerElapsed == 0)                                                   
        {
            SceneManager.LoadScene(4);                                              
        }
    }
}
