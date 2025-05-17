using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    float speed = 10;
    float despTime = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, despTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.GetDamaged(PlayerStats.Instance.Damage);
            }
        }
        Destroy(gameObject);
    }

    void Move()
    {
        Vector3 forwardDirection = transform.up.normalized;
        Vector3 newPosition = rb.position + forwardDirection * speed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }

    void FixedUpdate()
    {
        Move();
    }
}