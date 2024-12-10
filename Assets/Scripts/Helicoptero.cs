using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicoptero : MonoBehaviour
{
    public float velocidadAscenso = 5f; 
    public float velocidadHorizontal = 3f; 

    private void FixedUpdate()
    {
        
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 movimientoVertical = Vector3.up * inputVertical * velocidadAscenso * Time.fixedDeltaTime;
        transform.position += movimientoVertical;

        
        float inputHorizontal = Input.GetAxis("Horizontal");
        Vector3 movimientoHorizontal = Vector3.right * inputHorizontal * velocidadHorizontal * Time.fixedDeltaTime;
        transform.position += movimientoHorizontal;

        
        float inputRotacion = Input.GetAxis("Horizontal");
        float velocidadRotacion = 100f; 
        transform.Rotate(Vector3.right * inputRotacion * velocidadRotacion * Time.fixedDeltaTime);
    }
}
