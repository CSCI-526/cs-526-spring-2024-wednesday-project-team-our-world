using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryPlatformScript : MonoBehaviour
{
    private bool touched = false;
    private float timeOnPlatform = 0f;
    private bool isPlayerOnPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!touched || GameManager.Instance.State == GameManager.GameState.InitialLevel) {
            
        } else if (GameManager.Instance.State == GameManager.GameState.MirrorLevel && touched) {
            gameObject.SetActive(false);
        }

        //metric 1
        if (isPlayerOnPlatform || GameManager.Instance.State != GameManager.GameState.PauseGame)
        {
            timeOnPlatform += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        GameManager.Instance.CurrentPlatform = name;
        if(GameManager.Instance.State != GameManager.GameState.MirrorLevel)
            touched = true;
            isPlayerOnPlatform = true;
    }

    public void Reset() {
        touched = false;
    }

    void OnCollisionExit(Collision collision)
    {
        isPlayerOnPlatform = false;
        // Debug.Log(gameObject.name + ": " + timeOnPlatform);
        metric1();
        timeOnPlatform = 0f;
    }

    void metric1() {
        string key = gameObject.name;
        if (GameManager.Instance.platformTimes.ContainsKey(key))
        {
            GameManager.Instance.platformTimes[key] += timeOnPlatform;
        }
        else
        {
            GameManager.Instance.platformTimes[key] = timeOnPlatform;
        }
        GameManager.Instance.platformTime = timeOnPlatform;
    }
}
