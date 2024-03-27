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
        checkpointText.gameObject.SetActive(false);
        // TODO: rename GameManager.GameState.MirrorLevel, MirrorLevel works as a checkpoint
        GameManager.Instance.State = GameManager.GameState.MirrorLevel; 
    }
}
