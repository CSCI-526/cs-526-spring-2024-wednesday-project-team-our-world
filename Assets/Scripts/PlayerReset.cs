using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float resetHeight;
    
    [SerializeField] private Transform[] respawnPoint;
    [SerializeField] private MirrorWorldScript mirrorWorldScript;

    private void Update() {
        if (player.transform.position.y < resetHeight) {
            if (GameManager.Instance.CurrentRotation == 0) {
                player.transform.position = respawnPoint[0].position;
            } else if (GameManager.Instance.CurrentRotation == 90) {
                print("Case2");
                player.transform.position = respawnPoint[1].position;
            }
            
            player.GetComponent<PlayerMovement>().Reset();
        }
            
    }

}
