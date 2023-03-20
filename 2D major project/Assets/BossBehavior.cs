using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float speed = 6;
    public float attackRange;
    public int bossHealth = 10;
    public bool Phase2 = false;
    public bool Phase3 = false;
    public bool isDead = false;
    Transform player;
    public bool isFlipped = false;
    PlayerManager playerManager;
    public float timer;
    public float coolDown;
    public GameObject projectile;
    public GameObject projectiles2;
    public Transform shotLocation;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }
    void Update()
    {
        if (bossHealth < 7 && bossHealth > 3)
        {
            speed = 2;
            attackRange = 6;
            Phase2 = true;
            Debug.Log("Phase2");
        }
        else if (bossHealth < 3 && bossHealth > 1)
        {
            Phase2 = false;
            speed = 2;
            attackRange = 6;
            Phase2 = true;
            Debug.Log("Phase3");
        }
        else if (bossHealth <= 0)
        {
            Phase3 = false;
            isDead = true;
            Debug.Log("isDead");
        }

        timer = Time.deltaTime;
    }

   
    public void ProjectileShoot()
    {
        if(timer > coolDown)
        {
            if (Phase2)
            {
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
            else if (Phase3)
            {
                GameObject clone = Instantiate(projectiles2, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
        }
    }

    // Update is called once per frame
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerManager.TakeDamage();
        }
    }
}
