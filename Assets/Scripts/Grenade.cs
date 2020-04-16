using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Material redMat;
    public float lifeTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        


        StartCoroutine(LifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Debug.Log("grenade destroy !");
        Destroy(this.gameObject);
    }
}
