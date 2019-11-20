using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    private GameObject enemyObj;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyObj = other.gameObject;
            enemyObj.GetComponent<InRangeCheck>().inRange = true;
            enemyObj.GetComponentInParent<AudioSource>().Play();
        }
    }
    }
