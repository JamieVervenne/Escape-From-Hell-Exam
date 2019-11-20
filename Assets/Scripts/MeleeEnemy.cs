using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public GameObject rangeObj;
    public GameObject coin;
    public ParticleSystem partSyst;
    public Transform coinSpawned;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int moveSpeed;
    public int health = 3;
    public bool DeathEff = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        partSyst = this.GetComponent<ParticleSystem>();
        DeathEff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rangeObj.GetComponent<InRangeCheck>().inRange == true)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        if (health <= 0 && DeathEff == false)
        {
            moveSpeed = 0;
            Destroy(this.GetComponentInChildren<EnemyMeleeAttack>());
            StartCoroutine("Death");
            this.GetComponent<SpriteRenderer>().enabled = false;
            DeathEff = true;
            this.GetComponentInChildren<BoxCollider>().enabled = false;
            this.GetComponentInChildren<SpriteRenderer>().enabled = false;
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

    IEnumerator Death()
    {
        partSyst.Play();
        yield return new WaitForSeconds(1f);
        partSyst.Stop();
        coinSpawned = Instantiate(coin.transform, this.transform.position, Quaternion.EulerRotation(90, 0, 0));
        yield return new WaitForSeconds(15f);
        Destroy(this.gameObject);
    }
}
