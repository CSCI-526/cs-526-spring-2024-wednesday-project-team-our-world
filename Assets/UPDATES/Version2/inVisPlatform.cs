using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inVisPlatform : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(InvisiblePlatform());
        }
    }

    IEnumerator InvisiblePlatform()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
