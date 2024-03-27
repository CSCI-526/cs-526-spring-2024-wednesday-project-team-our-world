using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class platformHandler : MonoBehaviour
{
    public int levelNum;
    public GameObject parentObj;
    public Vector3 rotpoint;

    public GameObject moveInstruct;
    public GameObject jumpInstruct;
    public GameObject rotateInstruct;

    bool ismove, isjump;

    private void Start()
    {
        Time.timeScale = 0f;
        isjump = false;
        ismove = true;
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && ismove && !isjump)
        {
            ismove = false;
            isjump = true;
            Time.timeScale = 1f;
            moveInstruct.SetActive(false);
            StartCoroutine(waitSomeTime(1.5f, jumpInstruct, 0));
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isjump && !ismove)
        {
            ismove = false;
            isjump = false;
            Time.timeScale = 1f;
            jumpInstruct.SetActive(false);
            StartCoroutine(waitSomeTime(2, rotateInstruct, 0));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1f;
            rotateInstruct.SetActive(false);
            parentObj.transform.RotateAround(rotpoint, Vector3.forward, 90f);
        }
    }


    IEnumerator waitSomeTime(float timeVal, GameObject itrPanel,int val)
    {
        yield return new WaitForSeconds(timeVal);
        itrPanel.SetActive(true);
        Time.timeScale = val;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(levelNum);
        }
    }
}
