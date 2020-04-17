using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Renderer rend;
    private Material actualMat;
    public Material redMat;
    public Material blackMat;
    public Material GreenMat;

    public float deathTime = 2;
    public float lifeTime = 3;
    private float matTime = 0;
    private float matDeathTime = 0;

    public bool isBlocked = false;
    public bool isDied = false;

    private Rigidbody grenadeRigid;
    private BoxCollider col;
    private IEnumerator lifTimeCoroutine;

    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<Renderer>();
        actualMat = rend.material;
        if (rend == null)
            Debug.Log("pas de renderer");

        grenadeRigid = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartLiftime()
    {
        if (!isBlocked)
        {
            lifTimeCoroutine = LifeTime();
            StartCoroutine(lifTimeCoroutine);
        }
    }

    public void StartDeathtime()
    {
        if (!isDied)
        {
            StartCoroutine(OnDestroyPlatform());
        }
    }

    public IEnumerator LifeTime()
    {
        isBlocked = true;

        gameObject.tag = "Platform";
        grenadeRigid.velocity = Vector3.zero;
        grenadeRigid.angularVelocity = Vector3.zero;
        grenadeRigid.useGravity = false;
        grenadeRigid.mass = 1000f;
        transform.localScale = new Vector3(2, 0.2f, 2);


        while (matTime < lifeTime)
        {
            matTime += Time.deltaTime;
            rend.material.Lerp(actualMat, GreenMat, (matTime / lifeTime));
            yield return new WaitForEndOfFrame();
        }
        StartDeathtime();
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.layer == 8)
    //    {
    //        StartLiftime();
    //        Debug.Log("platform Touch wall !");
    //    }
    //}

    public IEnumerator OnDestroyPlatform()
    {
        isDied = true;
        gameObject.tag = "PlatformUsed";
        col.isTrigger = true;

        PlayerMovement.Instance.DecreaseNbPlatform();

        if(lifTimeCoroutine != null)
            StopCoroutine(lifTimeCoroutine);

        while (matDeathTime < deathTime)
        {
            matDeathTime += Time.deltaTime;
            rend.material.Lerp(GreenMat, blackMat, (matDeathTime / deathTime));
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
