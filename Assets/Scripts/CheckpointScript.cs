using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public TextMesh checkpointText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (checkpointText != null)
            checkpointText.gameObject.SetActive(false);
    
        GameManager.Instance.checkpointUsed = true; 
        GameManager.Instance.checkpointZRotation = GameManager.Instance.currentZRotation;
        StoreDeactivatedGroundObjects();
        gameObject.SetActive(false);
    }

    void StoreDeactivatedGroundObjects()
    {
        // Get all GameObjects
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        // Loop through all GameObjects
        foreach (GameObject obj in allObjects)
        {
            
            // If the GameObject has the tag "Ground" and is deactivated
            if (obj.tag == "Ground" && !obj.activeInHierarchy)
            {
                // Add the GameObject to the list
                GameManager.Instance.deactivatedPlatforms.Add(obj);
            }
        }
        //Debug.Log("Deactivated platforms: " + GameManager.Instance.deactivatedPlatforms.Count);
    }
}
