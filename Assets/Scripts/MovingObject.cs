using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Vector3 point1;
    [SerializeField] private Vector3 point2;
    [SerializeField] private AnimationCurve movementCurve;

    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime * speed;
        float curveTime = movementCurve.Evaluate(timer % 1.0f);
        transform.position = Vector3.Lerp(point1, point2, curveTime);
    }
}
