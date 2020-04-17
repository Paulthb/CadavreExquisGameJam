using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOUYASECRET : MonoBehaviour
{
    public GameObject secret = null;

    public void OnTriggerEnter(Collider other)
    {
        secret.SetActive(true);
    }
}
