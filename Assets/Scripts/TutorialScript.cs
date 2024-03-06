using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{

    public GameObject UI;

    private void OnCollisionEnter(Collision collision) {
        print("Entering Mirror World");

        GameManager.Instance.State = GameManager.GameState.PauseGame;
        UI.SetActive(true);
    }

    public void Proceed() {
        SceneManager.LoadScene(1);
    }

}
