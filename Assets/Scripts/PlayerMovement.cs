using UnityEngine;
using UnityEngine.SceneManagement;

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

    float XIntent = 0;

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
        XIntent = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        
        if (GameManager.Instance.State != GameManager.GameState.PauseGame) {
            if (GameManager.Instance.State == GameManager.GameState.MirrorLevel) {
                XIntent *= -1;
            }

            rb.AddForce(Vector3.down * jumpForce * gravityMultiplier, ForceMode.Acceleration);
            // currVelocity = rb.velocity.x;

            Vector3 targetVelocity = new Vector3(XIntent, 0, 0);

            targetVelocity *= speed;

            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);

            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = 0;
            velocityChange.y = 0;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
                Jump();

            if (XIntent == 0) { 
                
            }
        } else {
            rb.Sleep();
        }
        print(IsGrounded());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(0);
        }
    }

    void Jump() {
        if (!IsGrounded()) return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);

    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, 1);
        // return GetComponent<Rigidbody>().velocity.y == 0;
    }

    public void Reset() {
        rb.Sleep();
    }

}
