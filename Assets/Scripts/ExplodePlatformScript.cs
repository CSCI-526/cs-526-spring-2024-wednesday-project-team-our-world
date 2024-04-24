using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePlatformScript : MonoBehaviour
{   
    private float timeToExplode = 1.5f;
    // Start is called before the first frame update
    Renderer r;
    Collider c;

    private void Start() {
        r = GetComponent<Renderer>();
        c = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (GameManager.Instance.checkpointUsed)
            GameManager.Instance.deactivatedPlatforms.Add(gameObject);
        GameManager.Instance.CurrentPlatform = name;
        StartCoroutine(ChangeColorAfterCollision());
    }

    IEnumerator ChangeColorAfterCollision()
    {
        Color originalColor = GetComponent<Renderer>().material.color;
        float elapsed = 0f;

        while (elapsed < timeToExplode)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = elapsed / timeToExplode;
            // Here Color.Lerp is used to interpolate the color
            GetComponent<Renderer>().material.color = Color.Lerp(originalColor, new Color(0, 0, 0, 0), normalizedTime);
            yield return null;
        }
        // yield return new WaitForSeconds(0);
        c.enabled = false;
    }

    public void Reset() {
        r.material.color = Color.red;
        c.enabled = true;
    }

}
