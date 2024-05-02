using UnityEngine;

public class BowlingCamera : MonoBehaviour
{
    [SerializeField] private float moveStep = 1.0f;
    [SerializeField] private float moveDelay = 0.2f;
    [SerializeField] private Renderer bowlingBall;
    [SerializeField] private Material ballMaterial;
    [SerializeField] private Material transparentBallMaterial;
    private float nextMoveTime = 0f;

    private void Update()
    {
        if (Time.time >= nextMoveTime)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * moveStep);
                nextMoveTime = Time.time + moveDelay;
                bowlingBall.material = transparentBallMaterial;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * moveStep);
                nextMoveTime = Time.time + moveDelay;
                bowlingBall.material = transparentBallMaterial;
            }
            else
            {
                bowlingBall.material = ballMaterial;
            }
        }
    }
}
