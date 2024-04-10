using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float maxVelocityChange = 10.0f;

    [SerializeField] private float jumpForce;

    public float raycastLen;

    float XIntent = 0;

    public float moveSpeed = 5f; // Speed of horizontal movement

    private bool isGrounded;

    private bool lockout = false;
    private bool jumpLockout = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        XIntent = 0;
        XIntent = Input.GetAxisRaw("Horizontal");
       
    }

    private void FixedUpdate() {
        fixPlayerZ();
        if (GameManager.Instance.State != GameManager.GameState.PauseGame) {

            if (lockout) { 
                lockout = false;
                rb.WakeUp();
                jumpLockout = true;
                Invoke("unlockJump", 0.05f);
            }

            Move();
            // Jumping
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && !jumpLockout)
                Jump();
        } else {
            lockout = true;
            rb.Sleep();
        }
    }

    void Move() {
        Vector3 movement = new Vector3(XIntent, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void Jump() {
        if (!IsGrounded()) return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpLockout = true;
        Invoke("unlockJump", 0.05f);
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, raycastLen);
    }

    void unlockJump() {
        jumpLockout = false;
    }

    public void Reset() {
        rb.Sleep();
    }

    void fixPlayerZ() {
        if (transform.position.z != 0) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

}
