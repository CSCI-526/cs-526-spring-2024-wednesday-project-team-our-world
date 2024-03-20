using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float maxVelocityChange = 10.0f;

    [SerializeField] private float jumpForce;

    [SerializeField] private float gravityMultiplier;

    [SerializeField] private float velocityThreshold;
    // private float currVelocity = 0f;
    public float raycastLen;

    float XIntent = 0;
    public GameObject levelParent;
    private int CurrentYRotation = 0;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        XIntent = 0;
        XIntent = Input.GetAxisRaw("Horizontal");
       if (Input.GetKeyDown(KeyCode.E)) {
                Rotate(CurrentYRotation - 90, 0);
                print(CurrentYRotation);
            }
        if (Input.GetKeyDown(KeyCode.Q)) {
            Rotate(CurrentYRotation + 90, 0);
            print(CurrentYRotation);
        }
    }

    private void FixedUpdate() {
        
        if (GameManager.Instance.State != GameManager.GameState.PauseGame) {
            if (GameManager.Instance.State == GameManager.GameState.MirrorLevel) {
                XIntent *= -1;
            }
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
                Jump();
            
            rb.AddForce(Vector3.down * jumpForce * gravityMultiplier, ForceMode.Acceleration);
            // currVelocity = rb.velocity.x;

            Vector3 targetVelocity = new Vector3(XIntent, 0, 0) * speed;

            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);

            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = 0;
            velocityChange.y = 0;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);

            if (XIntent == 0) { 
                
            }
        } else {
            rb.Sleep();
        }
        // print(IsGrounsded());
    }

    void Jump() {
        if (!IsGrounded()) return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
    }

    void Rotate(int goalAngle, int flip) 
    {
        float yRotation = flip;
        float zRotation = goalAngle;
        CurrentYRotation = goalAngle;
        Quaternion targetRotation = Quaternion.Euler(0f, yRotation, zRotation);

        while (Quaternion.Angle(levelParent.transform.rotation, targetRotation) > 0.01f) 
        {
            levelParent.transform.rotation = Quaternion.RotateTowards(
                levelParent.transform.rotation,
                targetRotation,
                100f * Time.deltaTime
            );
        }
    }
    bool IsGrounded() {
        // Perform the raycast
        bool grounded = Physics.Raycast(transform.position, Vector3.down, raycastLen);
        // print(grounded);
/*
        if (grounded) {
            Debug.DrawRay(transform.position, Vector3.down * raycastLen, Color.green);
        } else {
            Debug.DrawRay(transform.position, Vector3.down * raycastLen, Color.red);
        }*/

        return grounded;
    }

    public void Reset() {
        rb.Sleep();
    }

}
