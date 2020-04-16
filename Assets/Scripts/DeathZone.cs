using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Renderer rend;
    public Material greenMat;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.RespawnPlayer();
            gameObject.tag = "Platform";
            rend.material = greenMat;
        }
    }
}
