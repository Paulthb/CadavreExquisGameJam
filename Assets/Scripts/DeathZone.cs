using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Renderer rend;
    public Material greenMat;

    public bool futurPlatform = false;
    public bool isPlatform = false;

    public bool deadZonePermanent = false;
    public bool FinisheZone = false;

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
            if (!isPlatform && !deadZonePermanent)
            {
                GameManager.Instance.RespawnPlayer();
                isPlatform = true;
            }
            else if (deadZonePermanent)
                GameManager.Instance.RespawnPlayer();

            if (FinisheZone)
                GameManager.Instance.Finish();
        }
    }
}
