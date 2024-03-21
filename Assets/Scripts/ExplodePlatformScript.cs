using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePlatformScript : MonoBehaviour
{   
    private float timeToExplode = 1.0f;
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
    StartCoroutine(ChangeColorAfterCollision());
    StartCoroutine(DisableAfterSeconds(timeToExplode));
}

IEnumerator ChangeColorAfterCollision()
{
    Renderer renderer = GetComponent<Renderer>();
    Color originalColor = renderer.material.color;
    float elapsed = 0f;

    while (elapsed < timeToExplode)
    {
        elapsed += Time.deltaTime;
        float normalizedTime = elapsed / timeToExplode;
        // Here Color.Lerp is used to interpolate the color
        renderer.material.color = Color.Lerp(originalColor, Color.black, normalizedTime);
        yield return null;
    }
}
IEnumerator DisableAfterSeconds(float seconds)
{
    yield return new WaitForSeconds(seconds);
    gameObject.SetActive(false);
}
}
