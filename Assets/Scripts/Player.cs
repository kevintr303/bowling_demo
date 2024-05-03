using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BowlingBall ball;
    [SerializeField] private Material ballMaterial;
    [SerializeField] private Material transparentBallMaterial;
    [SerializeField] private AudioSource tiltAudioSource;
    [SerializeField] private AudioSource moveAudioSource;
    [SerializeField] private Vector2 horizontalClamp = new Vector2(-3f, 3f);
    
    [field: SerializeField] public Vector2 spinRange { get; private set; } = new Vector2(-300, 300);
    [SerializeField] private float spinStep = 15f;
    [SerializeField] private float spinDelay = 0.1f;
    [field: SerializeField] public Vector2 powerRange { get; private set; } = new Vector2(500, 2000);
    [SerializeField] private float powerStep = 50f;
    [SerializeField] private float maxTilt = 15f;
    [SerializeField] private float tiltStep = 1f;
    [SerializeField] private float tiltDelay = 0.2f;
    [SerializeField] private float powerDelay = 0.2f;
    [SerializeField] private float moveStep = 0.2f;
    [SerializeField] private float moveDelay = 0.1f;

    private Renderer bowlingBallRenderer;
    private float nextTiltTime = 0f;
    private float nextPowerTime = 0f;
    private float nextMoveTime = 0f;
    private float nextSpinTime = 0f;

    public float Power { get; private set; } = 1000f;
    public bool BallLaunched { get; private set; } = false;
    public float Tilt { get; private set; }
    public float Spin { get; private set; }

    private void Start() 
    {
        bowlingBallRenderer = ball.gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        HandleLaunch();
        HandlePowerAdjustment();
        HandleTiltAdjustment();
        HandlePositionAdjustment();
        HandleSpin();
    }

    private void HandleSpin()
    {
        if (Time.time >= nextSpinTime) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                AdjustSpin(-spinStep);
            }
            else if (Input.GetKey(KeyCode.RightArrow)) {
                AdjustSpin(spinStep);
            }
        }
    }

    private void AdjustSpin(float adjustment) 
    {
        Spin += adjustment;
        Spin = Mathf.Clamp(Spin, spinRange.x, spinRange.y);
        nextSpinTime = Time.time + spinDelay;
    }

    private void HandleLaunch()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !BallLaunched)
        {
            ball.Launch(Power, Tilt, Spin);
            BallLaunched = true;
        }

        if (Input.GetKeyDown(KeyCode.R) && BallLaunched)
        {
            ball.Reset();
            BallLaunched = false;
        } 
    }

    private void HandlePowerAdjustment()
    {
        if (Time.time >= nextPowerTime)
        {
            if (Input.GetKey(KeyCode.W))
            {
                AdjustPower(powerStep);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                AdjustPower(-powerStep);
            }
        }
    }

    private void AdjustPower(float adjustment)
    {
        Power += adjustment;
        Power = Mathf.Clamp(Power, powerRange.x, powerRange.y);
        nextPowerTime = Time.time + powerDelay;
    }

    private void HandleTiltAdjustment()
    {
        if (Time.time >= nextTiltTime)
        {
            if (Input.GetKey(KeyCode.E))
            {
                AdjustTilt(tiltStep);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                AdjustTilt(-tiltStep);
            }
        }
    }

    private void AdjustTilt(float adjustment)
    {
        Tilt += adjustment;
        Tilt = Mathf.Clamp(Tilt, -maxTilt, maxTilt);
        nextTiltTime = Time.time + tiltDelay;
        tiltAudioSource.Play();
    }

    private void HandlePositionAdjustment()
    {
        if (Time.time >= nextMoveTime)
        {
            Vector3 newPosition = transform.position;
            bool moved = false;

            if (Input.GetKey(KeyCode.A))
            {
                newPosition += Vector3.left * moveStep;
                moved = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                newPosition += Vector3.right * moveStep;
                moved = true;
            }

            if (moved)
            {
                nextMoveTime = Time.time + moveDelay;
                bowlingBallRenderer.material = transparentBallMaterial;
                moveAudioSource.Play();
            }
            else
            {
                bowlingBallRenderer.material = ballMaterial;
            }

            newPosition.x = Mathf.Clamp(newPosition.x, horizontalClamp.x, horizontalClamp.y);
            transform.position = newPosition;
        }
    }
}
