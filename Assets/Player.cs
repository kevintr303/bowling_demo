using UnityEngine;

public class Player : MonoBehaviour
{
    public float Tilt { get; private set; }
    [SerializeField] private BowlingBall ball;
    [SerializeField] private Vector2 powerRange = new Vector2(500, 2000);
    [SerializeField] private float maxTilt = 15f;
    [SerializeField] private float powerStep = 50f;
    [SerializeField] private float tiltStep = 1f;
    [SerializeField] private float tiltDelay = 0.2f;
    [SerializeField] private float powerDelay = 0.2f;
    private float nextTiltTime = 0f;
    private float nextPowerTime = 0f;
    private float power = 1000f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ball)
        {
            ball.Launch(power, Tilt);
            ball = null; // Ensure the ball can only be launched once
        }

        // Adjust power with up/down arrows
        if (Time.time >= nextPowerTime)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                power += powerStep;
                power = Mathf.Clamp(power, powerRange.x, powerRange.y);
                nextPowerTime = Time.time + powerDelay;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                power -= powerStep;
                power = Mathf.Clamp(power, powerRange.x, powerRange.y);
                nextPowerTime = Time.time + powerDelay;
            }
        }

        // Adjust tilt with left/right arrows
        if (Time.time >= nextTiltTime)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Tilt += tiltStep;
                Tilt = Mathf.Clamp(Tilt, -maxTilt, maxTilt);
                nextTiltTime = Time.time + tiltDelay;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Tilt -= tiltStep;
                Tilt = Mathf.Clamp(Tilt, -maxTilt, maxTilt);
                nextTiltTime = Time.time + tiltDelay;
            }
        }
    }
}
