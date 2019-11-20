using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFightTrigger : MonoBehaviour
{
    public GameObject bossObj;
    public GameObject doorObj;
    public Slider bossHPSlide;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doorObj.GetComponent<MeshRenderer>().enabled = true;
            doorObj.GetComponent<BoxCollider>().enabled = true;
            bossObj.GetComponent<BossEnemy>().enabled = true;
            bossObj.GetComponent<SpriteRenderer>().enabled = true;
            bossHPSlide.GetComponentInChildren<Image>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
