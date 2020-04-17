using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Renderer rend;
    public Material greenMat;

    public bool futurPlatform = false;
    public bool isPlatform = false;

    private BoxCollider col;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(futurPlatform)
            {
                gameObject.tag = "PlatformZone";
                rend.material = greenMat;
                col.isTrigger = false;
            }
            if (!isPlatform)
            {
                GameManager.Instance.RespawnPlayer();
                isPlatform = true;
            }
        }
    }
}
