using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3D : MonoBehaviour
{
    public float health_max = 100;
    public float health = 100;

    public static Action<float> onUpdateHealth;

    public void UpdateHealth(float value)
    {
        health = Mathf.Clamp(health +    value, 0, health_max);

        float v = health / health_max;
        onUpdateHealth?.Invoke(v);
    }
}
