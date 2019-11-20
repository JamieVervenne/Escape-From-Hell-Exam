using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBullet : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
