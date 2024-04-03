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
            Rotate(CurrentZRotation - 90);
        }
        if (Input.GetKeyDown(KeyCode.Q) && GameManager.Instance.State != GameManager.GameState.PauseGame) {
            Rotate(CurrentZRotation + 90);
        }
    }

    public void Rotate(int goalAngle) {
        GameManager.Instance.State = GameManager.GameState.PauseGame;
        StartCoroutine(CreateMirror(goalAngle));
        metric3(GameManager.Instance.CurrentPlatform);
    }

    private void OnCollisionEnter(Collision collision) {

    }

    IEnumerator CreateMirror(int goalAngle) {

        float zRotation = goalAngle;

        Quaternion targetRotation = Quaternion.Euler(0f, 0, zRotation);

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f) {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                100f * Time.deltaTime
            );
            yield return null;
        }

        CurrentZRotation = goalAngle;
        GameManager.Instance.currentZRotation = CurrentZRotation;
        GameManager.Instance.State = GameManager.GameState.InitialLevel;
    }

    void metric3(string platformName) {
        Debug.Log(platformName);
        // Check if platformRotateTimes contains the current platform
        if (GameManager.Instance.platformRotateTimes.ContainsKey(GameManager.Instance.CurrentPlatform))
        {
            // If it does, increment the value
            GameManager.Instance.platformRotateTimes[GameManager.Instance.CurrentPlatform] += 1;
        }
        else
        {
            // If it doesn't, set the value to 1
            GameManager.Instance.platformRotateTimes[GameManager.Instance.CurrentPlatform] = 1;
        }
    }
}
