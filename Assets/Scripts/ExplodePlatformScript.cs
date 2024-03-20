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
    StartCoroutine(ChangeColorAfterCollision());
    StartCoroutine(DisableAfterSeconds(1.5f));
}

IEnumerator ChangeColorAfterCollision()
{
    Renderer renderer = GetComponent<Renderer>();
    Color originalColor = renderer.material.color;
    float duration = 1.5f; // duration of the color change
    float elapsed = 0f;

    while (elapsed < duration)
    {
        elapsed += Time.deltaTime;
        float normalizedTime = elapsed / duration;
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
