using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePlatformScript : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
{
        StartCoroutine(DisableAfterSeconds(1.5f));
}

IEnumerator DisableAfterSeconds(float seconds)
{
    yield return new WaitForSeconds(seconds);
    gameObject.SetActive(false);
}
}
