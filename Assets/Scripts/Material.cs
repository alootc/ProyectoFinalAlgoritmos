using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomMaterial", menuName = "Materials/CustomMaterial")]
public class Material : ScriptableObject
{
    private Material material;
    public Color[] emissionColors;

    //public void ChangeEmissionColor(MaterialChange state)
    //{
    //    switch (state)
    //    {
    //        case MaterialChange.OnLaunch:
    //            material.SetColor("_emissionColor", emissionColors[0]);
    //            break;

    //        case MaterialChange.OnOnlyVertical:
    //            material.SetColor("_emissionColor", emissionColors[1]);
    //            break;

    //        case MaterialChange.OnOnlyHorizontal:
    //            material.SetColor("_emissionColor", emissionColors[2]);
    //            break;

    //        case MaterialChange.OnLosseGravity:
    //            material.SetColor("_emissionColor", emissionColors[3]);
    //            break;

    //        default:
    //            material.SetColor("_emissionColor", emissionColors[4]);
    //            break;
    //    }
    //}
}

public enum MaterialState { Normal, OnLaunch, OnOnlyVertical, OnOnlyHorizontal, OnLooseGravity }
