using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraficoContoller : MonoBehaviour
{
    public Grafonodirigidolab nodo;
    public float speed;
    public int energy;

    private Rigidbody rb;
    private Vector3 dir;
    public bool isdescansar;
    private float tiempo;

    [Header("Field Vision")]
    public Transform target;
    public float view_radius;
    [Range(-45, 90)] public float view_angle = 75;
    public float rotation_speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = nodo.transform.position - transform.position;
        energy -= nodo.cost_energy;
    }

    private void Update()
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(Vector3.forward * angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotation_speed * Time.deltaTime);

        if (IsTargetInsideFOV())
        {
            dir = target.position - transform.position;
            return;
        }
        else
        {
            dir = nodo.transform.position - transform.position;
        }

        if (isdescansar)
        {
            tiempo += Time.deltaTime;
            if (tiempo >= 1)
            {
                energy++;
                tiempo = 0;
                if (energy == 10)
                {
                    isdescansar = false;
                    CheckNodo();
                }
            }
            return;
        }

        if (Vector2.Distance(nodo.transform.position, transform.position) < 0.1f)
        {
            CheckNodo();
        }
    }

    private void CheckNodo()
    {
        Grafonodirigidolab node_tmp = nodo.GetNodeRandom();
        if (energy >= node_tmp.cost_energy)
        {
            nodo = node_tmp;
            energy -= nodo.cost_energy;
            dir = nodo.transform.position - transform.position;
        }
        else
        {
            isdescansar = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isdescansar)
            rb.velocity = dir.normalized * speed;
        else
            rb.velocity = Vector2.zero;
    }

    private bool IsTargetInsideFOV()
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

        if (angleToTarget < view_angle / 2)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            return distance < view_radius;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, view_radius);

        Gizmos.color = IsTargetInsideFOV() ? Color.green : Color.red;

        Vector3 forward = transform.forward;
        Vector3 viewAngleA = Quaternion.Euler(0, view_angle / 2, 0) * forward;
        Vector3 viewAngleB = Quaternion.Euler(0, -view_angle / 2, 0) * forward;

        Gizmos.DrawLine(transform.position, transform.position + viewAngleA * view_radius);
        Gizmos.DrawLine(transform.position, transform.position + viewAngleB * view_radius);
    }

    private Vector3 DirFromAngle(float angle)
    {
        return Quaternion.Euler(0, angle, 0) * transform.forward;
    }
}
