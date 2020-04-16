using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform hand;
    public float throwForce = 10f;
    private GameObject grenadeObject;

    private Grenade grenade;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (PlayerMovement.Instance.nbCurrentPlatform < PlayerMovement.Instance.maxPlatform)
            {
                PlayerMovement.Instance.IncreaseNbPlatform();

                GameObject gren = Instantiate(grenadePrefab, hand.position, Quaternion.identity) as GameObject;
                gren.GetComponent<Rigidbody>().AddForce(hand.forward * throwForce, ForceMode.Impulse);
                grenadeObject = gren;
                grenade = grenadeObject.GetComponent<Grenade>();
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            grenade.StartLiftime();
        }
    }
}
