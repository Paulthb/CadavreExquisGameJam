using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform hand;
    public float throwForce = 10f;
    public GameObject grenade;

   


    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject gren = Instantiate(grenadePrefab, hand.position, hand.rotation) as GameObject;
            gren.GetComponent<Rigidbody>().AddForce(hand.forward * throwForce, ForceMode.Impulse);
            grenade = gren;


        }
        if (Input.GetButtonUp("Fire1"))
        {
            Rigidbody grenadeRigid = grenade.GetComponent<Rigidbody>();
            grenadeRigid.velocity = Vector3.zero;
            grenadeRigid.angularVelocity = Vector3.zero;
            grenadeRigid.useGravity = false;
            grenadeRigid.mass = 1000f;

        }

    }
}
