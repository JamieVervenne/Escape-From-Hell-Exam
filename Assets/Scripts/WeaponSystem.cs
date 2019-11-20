using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject pistol;
    public bool gunPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && player.GetComponent<PlayerControl>().hasSword == true && gunPickedUp == true)
        {
            player.GetComponent<PlayerControl>().hasSword = false;
            pistol.GetComponent<PistolControl>().hasGun = true;
        }
        else if (Input.GetButtonDown("Fire2") && pistol.GetComponent<PistolControl>().hasGun == true)
        {
            player.GetComponent<PlayerControl>().hasSword = true;
            pistol.GetComponent<PistolControl>().hasGun = false;
        }
    }
}
