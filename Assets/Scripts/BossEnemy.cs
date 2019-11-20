using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    public GameObject bulletSpawn;
    public GameObject Bullet;
    public Transform bulletSpawned;
    public AudioSource soundPlayer;
    public float waitTime = 2.3f;

    public ParticleSystem partSyst;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int moveSpeed;
    public float health;
    public float maxHealth = 20;
    public Slider healthSlider;
    public bool DeathEff = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        partSyst = this.GetComponent<ParticleSystem>();
        DeathEff = false;
        health = maxHealth;
        healthSlider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        healthSlider.value = CalculateHealth();

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        if (waitTime <= 0)
        {
            Shoot();
            waitTime += 0.6f;
        }

        if(health <= 0)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            waitTime += 50f;
            Death();
        }
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void Shoot()
    {
        bulletSpawned = Instantiate(Bullet.transform, bulletSpawn.transform.position, Quaternion.EulerRotation(0, 0, 0));
        bulletSpawned.rotation = bulletSpawn.transform.rotation;
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);
        Debug.Log("Loaded");
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
    
}
