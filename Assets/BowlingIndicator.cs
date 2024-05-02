using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingIndicator : MonoBehaviour
{
    public Player player;
    public RectTransform indicatorTransform;

    private void Update()
    {
        indicatorTransform.localEulerAngles = new Vector3(90, 0, -player.Tilt);
    }
}
