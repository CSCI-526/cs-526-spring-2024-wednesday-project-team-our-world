using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class PlayerReset : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float resetHeight;
    
    [SerializeField] private Transform[] respawnPoint;
    [SerializeField] private MirrorWorldScript mirrorWorldScript;
    [SerializeField] private MirrorScript mirrorScript;
    public Analytics analytics;

    private void Update() {
        if (player.transform.position.y < resetHeight) {
            
            
            // if (GameManager.Instance.CurrentRotation == 0) {
            //     player.transform.position = respawnPoint[0].position;
            // } else if (GameManager.Instance.CurrentRotation == 90) {
            //     print("Case2");
            //     player.transform.position = respawnPoint[1].position;
            // }
            
            if (GameManager.Instance.checkpoint == true) {
                // Start the RespawnPlayer coroutine
                StartCoroutine(RespawnPlayer());
                
            }
            else {
                // Reload the current scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }

            analytics.AddAnalyticData($"{SceneManager.GetActiveScene().name}: {GameManager.Instance.CurrentPlatform}", 1);
            analytics.AddAnalyticData($"-1", 0);
            
            string dictionaryString = "";
            foreach (KeyValuePair<string, int> pair in GameManager.Instance.platformRotateTimes)
            {
                dictionaryString += $"{pair.Key}: {pair.Value}\n";
            }
            Debug.Log(dictionaryString);
            analytics.AddAnalyticData(dictionaryString, 2);
            analytics.AddAnalyticData($"-1", 3);
            analytics.Send();

        }
            
    }

    IEnumerator RespawnPlayer()
    {
        // Call the Rotate function
        mirrorScript.Rotate(GameManager.Instance.checkpointZRotation);

        // Wait until the game state is not PauseGame
        yield return new WaitUntil(() => GameManager.Instance.State != GameManager.GameState.PauseGame);

        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        
        // Loop through all ground GameObjects
        foreach (GameObject obj in allObjects)
        {
            //Debug.Log(obj.name + " " + GameManager.Instance.deactivatedPlatforms.Contains(obj.name));
            // If the GameObject is not in the list
            if (obj.tag == "Ground" && !obj.activeInHierarchy && !GameManager.Instance.deactivatedPlatforms.Contains(obj))
            {
                // Activate the GameObject
                obj.SetActive(true);
                setRedColor(obj);
            }
        }

        // Then set the player's position
        player.transform.position = respawnPoint[0].position;

        // Reset the player's movement
        player.GetComponent<PlayerMovement>().Reset();
    }

    void setRedColor (GameObject obj) {
        Renderer renderer = obj.GetComponent<Renderer>();
        renderer.material.color = Color.red;
    }
}