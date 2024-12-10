using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : Collectionable
{
    protected override void Interact()
    {
        Grab();
        Destroy(gameObject);
    }

}
