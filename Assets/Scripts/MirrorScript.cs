using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{

    [SerializeField] private bool IsOnSide;
    private GameObject levelParent = null;
    public PlatformManager platformManager;

    // Start is called before the first frame update
    void Start()
    {
        if (!IsOnSide) { 
            transform.Rotate(0, 180, 0, Space.Self);
        }
        levelParent = transform.parent.gameObject;
    }

    private void OnCollisionEnter(Collision collision) {

        if (IsOnSide != GameManager.Instance.LevelIsFlipped) {
            // print("Flipping");
            
            GameManager.Instance.State = GameManager.GameState.PauseGame;
            
            if (!IsOnSide)
                StartCoroutine(CreateMirror(GameManager.Instance.CurrentRotation - 90, 0));
            else
                StartCoroutine(CreateMirror(GameManager.Instance.CurrentRotation - 90, 0));
        }

    }

    IEnumerator CreateMirror(int goalAngle, int flip) {

        float yRotation = flip;
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

        GameManager.Instance.CurrentRotation += 90;
        if(flip == 180) GameManager.Instance.LevelIsFlipped = true;
        platformManager.FlipPlatforms();
        GameManager.Instance.State = GameManager.GameState.InitialLevel;
    }

}
