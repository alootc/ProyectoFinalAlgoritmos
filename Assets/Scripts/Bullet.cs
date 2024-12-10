using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float time_life;


    private string enemy;
    private Vector3 direction;
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Destroy(gameObject, time_life);
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    
    public void SetBullet(string enemy, Vector3 direction)
    {
        this.enemy = enemy;
        this.direction = direction;
    }

    public void SetBullet(string enemy, Vector3 direction, float speed)
    {
        this.enemy = enemy;
        this.direction = direction;
        this.speed = speed;
    }
}
