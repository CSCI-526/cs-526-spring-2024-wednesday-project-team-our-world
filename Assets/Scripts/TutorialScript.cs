
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{

    public GameObject UI;
    bool lockout = false;
    [SerializeField] Analytics analytics;

    private void OnCollisionEnter(Collision collision) {
        print("Entering Mirror World");

        //GameManager.Instance.State = GameManager.GameState.PauseGame;
        UI.SetActive(true);
        Time.timeScale = 0;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (!lockout) { 
            lockout = true;

            //Analytics
            //metric 2
            string metric2Data = $"{SceneManager.GetActiveScene().name}: {GameManager.Instance.CurrentPlatform}";
            //metric 4
            string metric4Data = $"{SceneManager.GetActiveScene().name}: {GameManager.Instance.checkpointUsed}";
            //metric 1
            string metric1Data = $"{SceneManager.GetActiveScene().name}:\n";
            foreach (KeyValuePair<string, float> pair in GameManager.Instance.platformTimes) {
                metric1Data += $"{pair.Key}: {pair.Value}\n";
            }
            //metric 3
            string metric3Data = $"{SceneManager.GetActiveScene().name}:\n";
            foreach (KeyValuePair<string, int> pair in GameManager.Instance.platformRotateTimes) {
                metric3Data += $"{pair.Key}: {pair.Value}\n";
            }

            analytics.AddAnalyticData(metric1Data, 0);
            analytics.AddAnalyticData(metric2Data, 1);
            analytics.AddAnalyticData(metric3Data, 2);
            analytics.AddAnalyticData(metric4Data, 3);
            if (!lockout) {
                lockout = true;
                analytics.Send();
            }

        }

    }

    public void Proceed() {
        SceneManager.LoadScene("Level 2");
    }

}
