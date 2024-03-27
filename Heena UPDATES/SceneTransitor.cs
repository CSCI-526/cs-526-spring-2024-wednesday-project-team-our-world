using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : MonoBehaviour
{
    public void NextSceneButton(int levelnum)
    {
        SceneManager.LoadScene(levelnum);
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}
