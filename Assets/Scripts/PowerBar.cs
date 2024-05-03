using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private Player player;

    private float maxPower;
    private float minPower;
    private float currentPower;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        maxPower = player.powerRange.y;
        minPower = player.powerRange.x;
        currentPower = player.Power;
    }

    // Update is called once per frame
    void Update()
    {
        currentPower = player.Power;

        slider.value = (currentPower - minPower) / (maxPower - minPower);
    }
}
