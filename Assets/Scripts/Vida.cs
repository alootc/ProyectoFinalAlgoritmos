using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI puntos;
    public int health = 100;
    

    void Start()
    {
        
        Player3D.onUpdateHealth += UpdateSliderHealth;
        Player3D.onUpdatePoints += UpdateTextPoints;

        slider.maxValue = health;
        slider.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        slider.value = health;
        

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(4);
        }

    }
    public void Heal(int amount)
    {
        health += amount;
        if (health > health)
        {
            health = health; 
        }
        slider.value = health; 
    }

    private void OnDestroy()
    {
        
        Player3D.onUpdateHealth -= UpdateSliderHealth;
        Player3D.onUpdatePoints -= UpdateTextPoints;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Perro"))
        {
            TakeDamage(10);
        }
        else if (other.CompareTag("Policia")) // Policía ataca al jugador
        {
            TakeDamage(20); // Policía inflige 20 de daño
            
        }
        else if (other.CompareTag("Botiquin"))
        {
            Heal(20); 
            Destroy(other.gameObject); 
        }
    }

    private void UpdateSliderHealth(float value)
    {
        slider.value = value;
    }

    private void UpdateTextPoints(int points)
    {
        puntos.text = $"Puntos: {points}";
    }
}
