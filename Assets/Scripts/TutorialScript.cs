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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Proceed() {
        SceneManager.LoadScene("Level 2");
    }

}
