using UnityEngine;

public class RandomOffset : MonoBehaviour
{
    [SerializeField] private Vector3 randomOffset = new Vector3(0.2f, 0, 0.2f);
    void Start()
    {
        foreach (Transform child in transform)
        {
                child.position = new Vector3(
                child.position.x + Random.Range(-randomOffset.x, randomOffset.x),
                child.position.y,  // Keeps the y position unchanged
                child.position.z + Random.Range(-randomOffset.z, randomOffset.z)
            );
        }
    }
}
