using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : MonoBehaviour
{
    public void NextSceneButton(int levelnum)
    {
        SceneManager.LoadScene(levelnum);
    }public void NextSceneButton(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void AppQuit()
    {
        Application.Quit();
    }


}
