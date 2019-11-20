using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameObject pistol;
    public GameObject sword;
    public GameObject bossEnemy;
    public AudioSource soundPlayer;
    private Animation anim;
    public int health = 3;
    public int keys = 0;
    public bool invincible = false;
    public bool hasSword = true;
    public float waitTime = 0.1f;
    public int money;

    public Image hearts3;
    public Image hearts2;
    public Image hearts1;
    public Text keyText;

    Rigidbody body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 5.0f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        soundPlayer = GetComponent<AudioSource>();
        anim = sword.GetComponent<Animation>();
        health = PlayerPrefs.GetInt("PlayerCurrentLives");
        keys = PlayerPrefs.GetInt("PlayerKeys");
        money = PlayerPrefs.GetInt("PlayerScore");
    }

    void Update()
    {

        waitTime -= Time.deltaTime;

        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        keyText.text = "x" + keys;

        if (Input.GetButtonDown("Fire1") && hasSword == true && waitTime <= 0)
        {
            Stab();
            waitTime = 0.4f;
        }
        if (Input.GetButtonDown("Fire3"))
        {
            runSpeed = 10.0f;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            runSpeed = 5.0f;
        }


        if (health == 3)
        {
            hearts3.GetComponent<Image>().enabled = true;
            hearts2.GetComponent<Image>().enabled = false;
            hearts1.GetComponent<Image>().enabled = false;
        }
        if (health == 2)
        {
            hearts3.GetComponent<Image>().enabled = false;
            hearts2.GetComponent<Image>().enabled = true;
            hearts1.GetComponent<Image>().enabled = false;
        }
        if (health == 1)
        {
            hearts3.GetComponent<Image>().enabled = false;
            hearts2.GetComponent<Image>().enabled = false;
            hearts1.GetComponent<Image>().enabled = true;
        }
        if (health <= 0)
        {
            hearts1.GetComponent<Image>().enabled = false;
            SceneManager.LoadScene(5);
            Destroy(this.gameObject);
        }

        if(bossEnemy.GetComponent<BossEnemy>().health <= 0)
        {
            SceneManager.LoadScene(4);
        }

    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "PistolPickup")
        //{
        //    soundPlayer.Play();
        //    this.GetComponent<WeaponSystem>().gunPickedUp = true;
        //    Destroy(other.gameObject);
        //}
        //if (other.tag == "Key")
        //{
        //    soundPlayer.Play();
        //    keys += 1;
        //    Destroy(other.gameObject);
        //}
        if (other.tag == "Coin")
        {
            money += 100;
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("PlayerScore", money);
        }
        if (other.tag == "FatalHazard")
        {
            health -= 3;
        }
    }

    IEnumerator DamageTake()
    {
        health -= 1;
        invincible = true;
        yield return new WaitForSeconds(1.5f);
        invincible = false;
        PlayerPrefs.SetInt("PlayerCurrentLives", health);
    }


    void Stab()
    {
        anim.Play("stab");
    }
}
