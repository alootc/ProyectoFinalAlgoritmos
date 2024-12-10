using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objecto2 : Interactable
{
    protected override void Interact()
    {
        Destroy(gameObject);

    }
}
