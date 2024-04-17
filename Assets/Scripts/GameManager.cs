using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public enum GameState { InitialLevel, MirrorLevel, PauseGame}

    public GameState State { get; set; }

    public string CurrentPlatform { get; set; }

    public bool checkpointUsed { get; set; }
    public int checkpointZRotation { get; set; }
    public int currentZRotation { get; set; }

    public List<GameObject> deactivatedPlatforms = new List<GameObject>();

    //metric 1: time player stay on per stationary platform
    public Dictionary<string, float> platformTimes = new Dictionary<string, float>();
    public float platformTime = 0f;

    //metric 3: Times of players use rotation on each platform
    public Dictionary<string, int> platformRotateTimes = new Dictionary<string, int>();
    public int numberOfQRotations = 0;
    public int numberOfERotations = 0;

    private void Awake() {
        
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
        Instance.CurrentPlatform = "1";
        checkpointUsed = false;
        checkpointZRotation = 0;
        currentZRotation = 0;
    }
    private void OnDestroy() {
        // Reset the instance if the object is destroyed
        if (Instance == this) {
            Instance = null;
        }
    }

}
