using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{

    Vector3 defaultPos;
    public float speed = 3.0f;  
    public float amplitude = 2.0f;


    private GameObject target = null;
    private Vector3 offset;

    private bool touched = false;

    public bool special = false;
    public bool startHorizontal = true;

    Transform mirrorLevelTransform;

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.State == GameManager.GameState.PauseGame) { 
            defaultPos = transform.position;
            startHorizontal = !startHorizontal;
        }
        // print($"{GameManager.Instance.CurrentRotation}");
        if (GameManager.Instance.State != GameManager.GameState.PauseGame) {
            if (startHorizontal) {
                float pingpong = Mathf.PingPong(Time.time * speed, amplitude);
                transform.position = new Vector3(defaultPos.x + pingpong, defaultPos.y, defaultPos.z);
            } else {
                float pingpong = Mathf.PingPong(Time.time * speed, amplitude);
                transform.position = new Vector3(defaultPos.x, defaultPos.y + pingpong, defaultPos.z);
            }
        }

        /*
        if (!touched && GameManager.Instance.State == GameManager.GameState.MirrorLevel && special) {
            float pingpong = Mathf.PingPong(Time.time * speed, amplitude);
            transform.position = new Vector3(defaultPos.x, defaultPos.y + pingpong, defaultPos.z);
        } else if (!touched || GameManager.Instance.State == GameManager.GameState.InitialLevel) {
            float pingpong = Mathf.PingPong(Time.time * speed, amplitude);
            transform.position = new Vector3(defaultPos.x + pingpong, defaultPos.y, defaultPos.z);
        } else if (GameManager.Instance.State == GameManager.GameState.MirrorLevel && touched) {
            transform.position = mirrorLevelTransform.position;
        }*/
    }

    private void OnCollisionEnter(Collision collision) {
        if (GameManager.Instance.State != GameManager.GameState.MirrorLevel){
            touched = true;
            mirrorLevelTransform = transform;
        }
    }

    private void OnCollisionStay(Collision collision) {
        target = collision.gameObject;
        offset = target.transform.position - transform.position;
    }

    void OnCollisionExit(Collision collision) {
        target = null;
    }

    void LateUpdate() {
        if (target != null) {
            target.transform.position = transform.position + offset;
        }

    }

    public void Reset() {
        touched = false;
    }

}
