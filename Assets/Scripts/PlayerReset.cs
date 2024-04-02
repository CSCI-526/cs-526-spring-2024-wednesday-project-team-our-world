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
                player.transform.position = respawnPoint[0].position;
                player.GetComponent<PlayerMovement>().Reset();
            }
            else {
                // Reload the current scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            analytics.AddAnalyticData($"{SceneManager.GetActiveScene().name}: {GameManager.Instance.CurrentPlatform}", 1);
            analytics.AddAnalyticData($"-1", 0);
            analytics.AddAnalyticData($"-1", 2);
            analytics.AddAnalyticData($"-1", 3);
            analytics.Send();

        }
            
    }

}
