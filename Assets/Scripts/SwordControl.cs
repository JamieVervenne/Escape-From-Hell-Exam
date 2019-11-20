using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    public int damage = 1;
    public float thrust;
    public Renderer rend;
    public Collider col;

    private GameObject triggerEnemy;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponentInParent<PlayerControl>().hasSword == true)
        {
            rend.enabled = true;
            col.enabled = true;
        }
        else if (this.GetComponentInParent<PlayerControl>().hasSword == false)
        {
            rend.enabled = false;
            col.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            triggerEnemy = other.gameObject;
            triggerEnemy.GetComponentInParent<MeleeEnemy>().health -= damage;
        }
    }
}
