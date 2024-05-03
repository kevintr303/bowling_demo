using UnityEngine;

public class ForceTrigger : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude = 10f;

    [SerializeField] private Vector3 forceDirection = Vector3.up;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null)
        {
            rb.AddForce(forceDirection.normalized * forceMagnitude * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
