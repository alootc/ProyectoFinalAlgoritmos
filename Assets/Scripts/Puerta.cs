using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Puerta : Interactable
{

    public Transform left_door;
    public Transform right_door;

    public float duration_rotate;

    protected override void Interact()
    {
        if (Inventario.instance.GetInventario("Llave"))
        {

            left_door.DOLocalRotate(new Vector3(0, -90f, 0), duration_rotate, RotateMode.LocalAxisAdd);
            right_door.DOLocalRotate(new Vector3(0, 90f, 0), duration_rotate, RotateMode.LocalAxisAdd);

            Debug.Log("Se abre la puerta");
        }
        else
        {
            Debug.Log("No tienes la llave");
        }
    }
}
