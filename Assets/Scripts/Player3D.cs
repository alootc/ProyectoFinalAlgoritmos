using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player3D : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int points;

    private int healthMax = 10;
    private SpriteRenderer spr;

    public static Action<float> onUpdateHealth;
    public static Action<int> onUpdatePoints;

    public static event System.Action<bool> onGameOver;


    void Start()
    {
        spr = GetComponent<SpriteRenderer>();

    }

    public void GameOver(bool result)
    {
        
        onGameOver?.Invoke(result);
    }

    public void UpdateHeath(int valor)
    {
        health = Mathf.Clamp(health + valor, 0, healthMax);
        //slider.value = (float)health / (float)healthMax;

        float value = (float)health / (float)healthMax;
        onUpdateHealth?.Invoke(value);

        if (health <= 0)
            onGameOver?.Invoke(false);
    }

    void EndGame(bool win)
    {
        
        if (onGameOver != null)
        {
            onGameOver(win);
        }
    }

    public void Updatestaygame()
    {
        onUpdatePoints?.Invoke(points);

        if (points == 100)
            onGameOver?.Invoke(true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Policia"))
        {
             UpdateHeath(-1);

        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Botiquin"))
        {
            UpdateHeath(2);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Monedas"))
        {
            points += 10;
            onUpdatePoints?.Invoke(points);
            Destroy(collision.gameObject);

            Updatestaygame();
        }
    }
}
