using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

    [SerializeField] private GameObject LevelParent;

    private List<GameObject> Platforms;

    // Start is called before the first frame update
    void Start() {

        Platforms = new List<GameObject>();

        if (LevelParent != null) {
            AddScriptToChildren(LevelParent);
        }
    }

    void AddScriptToChildren(GameObject parent) {
        foreach (Transform child in parent.transform) {
            // Check the tag of each child
            if (child.CompareTag("Stationary")) {
                child.gameObject.AddComponent<StationaryPlatformScript>();
                Platforms.Add(child.gameObject);
            } else if (child.CompareTag("Moving")) {
                child.gameObject.AddComponent<MovingPlatformScript>();
                Platforms.Add(child.gameObject);
            }
        }
    }

    void ResetPlatforms() {
        foreach (GameObject platform in Platforms) {
            // Check the tag of each child
            if (platform.CompareTag("Stationary")) {
                platform.GetComponent<StationaryPlatformScript>().Reset();
            } else if (platform.CompareTag("Moving")) {
                platform.GetComponent <MovingPlatformScript>().Reset();
            }
        }
    }


}
