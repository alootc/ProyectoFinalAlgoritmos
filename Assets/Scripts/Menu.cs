using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Opciones(string opciones)
    {
        SceneManager.LoadScene(opciones);
    }

    public void Volver(string nombreDeLaEscena)
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }

    public void Salir()
    {
        Debug.Log("Saliste");
        Application.Quit();
    }
}
