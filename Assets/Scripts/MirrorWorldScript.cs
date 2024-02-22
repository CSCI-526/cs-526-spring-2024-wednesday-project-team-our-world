using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorWorldScript : MonoBehaviour
{

    [SerializeField] private GameObject levelParent;

    public int debugAngle = 0;

    void InitializeMirrorWorld() {
        StartCoroutine(CreateMirror(debugAngle));
    }

    private void OnCollisionEnter(Collision collision) {
        print("Entering Mirror World");
        if(GameManager.Instance.State != GameManager.GameState.MirrorLevel)
            InitializeMirrorWorld();
    }

    [Button]
    public void MirrorInitDebug() {
        InitializeMirrorWorld();
    }
    
    IEnumerator CreateMirror(int goalAngle) {
        GameManager.Instance.State = GameManager.GameState.PauseGame;
        /*do {
            angle += 100 * Time.deltaTime;
            if (angle > goalAngle) angle = goalAngle;
            levelParent.transform.rotation = Quaternion.Euler(0, 0, angle);
            yield return null;
        } while (angle < goalAngle);*/

        float yRotation = 180f;
        float zRotation = debugAngle;

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
