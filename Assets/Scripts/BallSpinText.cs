using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallSpinText : MonoBehaviour
{
    private TMP_Text text;
    [SerializeField] private Player player;

    private float minSpin;
    private float maxSpin;
    private float currentSpin;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        minSpin = player.spinRange.x;
        maxSpin = player.spinRange.y;
        currentSpin = player.Spin;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpin = player.Spin;
        float newMin = -3f;
        float newMax = 3f;
        float normalizedSpin = (newMax - newMin) * (currentSpin - minSpin) / (maxSpin - minSpin) + newMin;
        text.text = "Ball Spin: " + (normalizedSpin >= 0 ? "+" : "") + normalizedSpin.ToString("0.00");
    }
}
