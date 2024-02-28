using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float resetHeight;
    
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform mirrorRespawnPoint180;
    [SerializeField] private Transform mirrorRespawnPoint90;
    [SerializeField] private Transform mirrorRespawnPoint270;
    [SerializeField] private MirrorWorldScript mirrorWorldScript;

    private void Update() {
        if (player.transform.position.y < resetHeight) {
            if (GameManager.Instance.State == GameManager.GameState.InitialLevel)
                player.transform.position = respawnPoint.position;
            else if (GameManager.Instance.State == GameManager.GameState.MirrorLevel) {
                if (mirrorWorldScript.rotatedBy == 90) {
                    player.transform.position = mirrorRespawnPoint90.position;
                } else if (mirrorWorldScript.rotatedBy == 180) {
                    player.transform.position = mirrorRespawnPoint180.position;
                } else {
                    player.transform.position = mirrorRespawnPoint270.position;
                }
            }
            
            player.GetComponent<PlayerMovement>().Reset();
        }
            
    }

}
