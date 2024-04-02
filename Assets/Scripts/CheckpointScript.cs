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
        gameObject.SetActive(false);
        if (checkpointText != null)
            checkpointText.gameObject.SetActive(false);
    
        GameManager.Instance.checkpoint = true; 
        GameManager.Instance.checkpointZRotation = GameManager.Instance.currentZRotation;
        StoreDeactivatedGroundObjects();
    }

    void StoreDeactivatedGroundObjects()
    {
        // // Find the LevelParent GameObject
        // GameObject horPlatform = GameObject.Find("Hor explode platform");

        // if (horPlatform != null)
        // {
        //     // Get the number of children
        //     int childCount = horPlatform.transform.childCount;

        //     // Loop through all children
        //     for (int i = 0; i < childCount; i++)
        //     {
        //         // Get the child GameObject
        //         GameObject child = horPlatform.transform.GetChild(i).gameObject;

        //         // Now you can do something with the child GameObject
        //         // For example, print its name
        //         Debug.Log(child.name + " " + child.activeInHierarchy);
        //     }
        // }
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
        Debug.Log("Deactivated platforms: " + GameManager.Instance.deactivatedPlatforms.Count);
    }
}
