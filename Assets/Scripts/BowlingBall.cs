using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    private Rigidbody rb;
    private Transform player;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private bool launched = false;
    private bool grounded = false;

    private float spinAmount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = transform.parent;
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    public void Launch(float power, float tilt, float spinAmount)
    {
        transform.parent = null;
        rb.useGravity = true;
        transform.Rotate(new Vector3(0, tilt, 0));
        rb.AddForce(transform.forward * power);
        launched = true;
        this.spinAmount = spinAmount;
    }

    private void FixedUpdate() {
        if (launched && grounded)
            rb.AddForce(transform.right * spinAmount * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    public void Reset()
    {
        transform.parent = player;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;
        launched = false;
        grounded = false;
    }
}
