using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Renderer rend;
    private Material actualMat;
    public Material redMat;

    public float lifeTime = 5;
    private float matTime = 0;

    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<Renderer>();
        actualMat = rend.material;
        if (rend == null)
            Debug.Log("pas de renderer");

        StartCoroutine(LifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        //matTime += Time.deltaTime / lifeTime;
        //rend.material.Lerp(actualMat, redMat, matTime);
    }

    public IEnumerator LifeTime()
    {
        while (matTime < lifeTime)
        {
            Debug.Log(matTime / lifeTime);
            matTime += Time.deltaTime;
            rend.material.Lerp(actualMat, redMat, (matTime / lifeTime));
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("grenade destroy !");
        Destroy(this.gameObject);
    }
}
