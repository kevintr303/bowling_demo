using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(float power, float tilt)
    {
        transform.parent = null;
        rb.useGravity = true;
        transform.Rotate(new Vector3(0, tilt, 0));
        rb.AddForce(transform.forward * power);
    }
}
