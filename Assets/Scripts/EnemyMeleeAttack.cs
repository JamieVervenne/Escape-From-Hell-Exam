using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public GameObject playerObj;
    public int damage = 1;
    public SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && playerObj.GetComponent<PlayerControl>().invincible == false)
        {
            StartCoroutine("Attacking");
            playerObj.GetComponent<PlayerControl>().StartCoroutine("DamageTake");
        }
    }

    IEnumerator Attacking()
    {
        rend.enabled = true;
        yield return new WaitForSeconds(0.2f);
        rend.enabled = false;
    }
}
