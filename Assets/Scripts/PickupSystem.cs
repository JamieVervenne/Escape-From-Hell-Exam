using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupSystem : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject weaponControlText;

    public void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player" && this.tag == "PistolPickup")
        {
            playerObj.GetComponent<AudioSource>().Play();
            playerObj.GetComponent<WeaponSystem>().gunPickedUp = true;
            Destroy(this.gameObject);
            Destroy(weaponControlText.gameObject);
        }
        if (other.tag == "Player" && this.tag == "Key")
        {
            playerObj.GetComponent<AudioSource>().Play();
            playerObj.GetComponent<PlayerControl>().keys += 1;
            PlayerPrefs.SetInt("PlayerKeys", playerObj.GetComponent<PlayerControl>().keys);
            Destroy(this.gameObject);
        }
        //if (other.tag == "Player" && this.tag == "Coin")
        //{
        //    playerObj.GetComponent<AudioSource>().Play();
        //    playerObj.GetComponent<PlayerControl>().money += 100;
        //    Destroy(this.gameObject);
        //}
        if (other.tag == "Player" && this.tag == "Hp" && playerObj.GetComponent<PlayerControl>().health < 3)
        {
            playerObj.GetComponent<AudioSource>().Play();
            playerObj.GetComponent<PlayerControl>().health += 1;
            PlayerPrefs.SetInt("PlayerCurrentLives", playerObj.GetComponent<PlayerControl>().health);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player" && this.tag == "Finish")
        {
            SceneManager.LoadScene(4);
        }
        if (other.tag == "Player" && this.tag == "ExitLevel")
        {
            SceneManager.LoadScene(1);
        }
        if (other.tag == "Player" && this.tag == "EntranceLevel1")
        {
            SceneManager.LoadScene(2);
        }
        if (other.tag == "Player" && this.tag == "EntranceLevel2")
        {
            SceneManager.LoadScene(3);
        }
    }
    }
