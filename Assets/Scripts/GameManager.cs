using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public enum GameState { InitialLevel, MirrorLevel, PauseGame}

    public GameState State { get; set; }

    public string CurrentPlatform { get; set; }

    public bool checkpoint = false;
    public int checkpointZRotation = 0;
    public int currentZRotation = 0;

    public List<GameObject> deactivatedPlatforms = new List<GameObject>();

    //metric 1: time player stay on per stationary platform
    public Dictionary<string, float> platformTimes = new Dictionary<string, float>();

    //metric 3: Times of players use rotation on each platform
    public Dictionary<string, int> platformRotateTimes = new Dictionary<string, int>();
    private void Awake() {
        
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
        Instance.CurrentPlatform = "1";
    }
    private void OnDestroy() {
        // Reset the instance if the object is destroyed
        if (Instance == this) {
            Instance = null;
        }
    }
}
