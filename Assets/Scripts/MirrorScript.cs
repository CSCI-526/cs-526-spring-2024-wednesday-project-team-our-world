using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    int CurrentZRotation = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.State != GameManager.GameState.PauseGame) {
            Rotate(CurrentZRotation - 90, 0);
            // print(CurrentYRotation);
        }
        if (Input.GetKeyDown(KeyCode.Q) && GameManager.Instance.State != GameManager.GameState.PauseGame) {
            Rotate(CurrentZRotation + 90, 0);
            // print(CurrentYRotation);
        }
    }

    void Rotate(int goalAngle, int flip) {

        GameManager.Instance.State = GameManager.GameState.PauseGame;

        StartCoroutine(CreateMirror(goalAngle, flip));

/*        float yRotation = flip;
        float zRotation = goalAngle;
        CurrentZRotation = goalAngle;
        Quaternion targetRotation = Quaternion.Euler(0f, yRotation, zRotation);

        while (Quaternion.Angle(levelParent.transform.rotation, targetRotation) > 0.01f) {
            levelParent.transform.rotation = Quaternion.RotateTowards(
                levelParent.transform.rotation,
                targetRotation,
                100f * Time.deltaTime
            );
        }*/
    }

    private void OnCollisionEnter(Collision collision) {

    }

    IEnumerator CreateMirror(int goalAngle, int flip) {

        float yRotation = flip;
        float zRotation = goalAngle;
        CurrentZRotation = goalAngle;

        Quaternion targetRotation = Quaternion.Euler(0f, yRotation, zRotation);

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f) {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                100f * Time.deltaTime
            );
            yield return null;
        }

        GameManager.Instance.CurrentRotation += 90;
        if(flip == 180) GameManager.Instance.LevelIsFlipped = true;
        GameManager.Instance.State = GameManager.GameState.InitialLevel;
    }

}
