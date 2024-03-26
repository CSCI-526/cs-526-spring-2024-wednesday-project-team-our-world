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

        if (GameManager.Instance.State != GameManager.GameState.PauseGame) {
            Vector3 movement = new Vector3(XIntent, 0f, 0f) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);

            // Jumping
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
                Jump();
        } else {
            rb.Sleep();
        }
    }

    void Jump() {
        if (!IsGrounded()) return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, raycastLen);
    }

    public void Reset() {
        rb.Sleep();
    }

}
