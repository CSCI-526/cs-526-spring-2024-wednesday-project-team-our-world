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
    private bool special = false;
    Transform mirrorLevelTransform;

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
        target = null;
        if (tag == "MovingSpecial") {
            print("Special");
            special = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!touched && GameManager.Instance.State == GameManager.GameState.MirrorLevel && special) {
            // print($"{tag}: Special Mode");
            float pingpong = Mathf.PingPong(Time.time * 5, 4);
            transform.position = new Vector3(defaultPos.x, defaultPos.y + pingpong, defaultPos.z);
        } else if (!touched || GameManager.Instance.State == GameManager.GameState.InitialLevel) {
            float pingpong = Mathf.PingPong(Time.time * 5, 4);
            transform.position = new Vector3(defaultPos.x + pingpong, defaultPos.y, defaultPos.z);
        } else if (GameManager.Instance.State == GameManager.GameState.MirrorLevel && touched) {
            transform.position = mirrorLevelTransform.position;
        }
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
