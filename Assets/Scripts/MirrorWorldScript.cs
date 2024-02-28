using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorWorldScript : MonoBehaviour
{

    [SerializeField] private GameObject levelParent;
    [SerializeField] private GameObject UI;

    public int debugAngle = 0;
    public int rotatedBy = 0;
    void InitializeMirrorWorld() {
        StartCoroutine(CreateMirror(debugAngle));
    }

    private void OnCollisionEnter(Collision collision) {
        print("Entering Mirror World");
        

        if (GameManager.Instance.State != GameManager.GameState.MirrorLevel) {
            GameManager.Instance.State = GameManager.GameState.PauseGame;
            UI.SetActive(true);
        }
            
    }

    [Button]
    public void MirrorInitDebug() {
        InitializeMirrorWorld();
    }
    
    public void EnterMirror(int angle) {
        rotatedBy = angle;
        UI.SetActive(false);
        if (GameManager.Instance.State != GameManager.GameState.MirrorLevel) {
            StartCoroutine(CreateMirror(angle));
        } 

    }

    IEnumerator CreateMirror(int goalAngle) {
        
        /*do {
            angle += 100 * Time.deltaTime;
            if (angle > goalAngle) angle = goalAngle;
            levelParent.transform.rotation = Quaternion.Euler(0, 0, angle);
            yield return null;
        } while (angle < goalAngle);*/

        float yRotation = 180f;
        float zRotation = goalAngle;

        Quaternion targetRotation = Quaternion.Euler(0f, yRotation, zRotation);

        while (Quaternion.Angle(levelParent.transform.rotation, targetRotation) > 0.01f) {
            levelParent.transform.rotation = Quaternion.RotateTowards(
                levelParent.transform.rotation,
                targetRotation,
                100f * Time.deltaTime
            );
            yield return null;
        }

        GameManager.Instance.State = GameManager.GameState.MirrorLevel;
    }

}
