using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject door;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && this.tag == "Door")
        {
            playerObj = other.gameObject;
            if(playerObj.GetComponent<PlayerControl>().keys >= 1)
            {
                playerObj.GetComponent<PlayerControl>().keys -= 1;
                PlayerPrefs.SetInt("PlayerKeys", playerObj.GetComponent<PlayerControl>().keys);
                Destroy(door.gameObject);
            }
        }
        if (other.tag == "Player" && this.tag == "TriggerDoor")
            {
                playerObj = other.gameObject;
                if (playerObj.GetComponent<PlayerControl>().keys >= 1)
                {
                    playerObj.GetComponent<PlayerControl>().keys -= 1;
                    PlayerPrefs.SetInt("PlayerKeys", playerObj.GetComponent<PlayerControl>().keys);
                    door.GetComponent<BoxCollider>().enabled = false;
                    door.GetComponent<MeshRenderer>().enabled = false;
                }
            }
    }
}
