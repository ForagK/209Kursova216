using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance { get; private set; }

    GameObject bullet;
    float attackTimer = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
    }
    public void Attack()
    {
        if (attackTimer >= PlayerStats.Instance.ShootRate)
        {
            attackTimer = 0;
            SoundManager.Instance.PlayPlayerShootSound();
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(90, transform.eulerAngles.y, transform.eulerAngles.z));
        }     
    }
    void Update()
    {
        attackTimer += Time.deltaTime;
    }
}