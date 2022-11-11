using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Axis
{
    public string Name;
    public KeyCode NegativeButton = KeyCode.None;
    public KeyCode PositiveButton = KeyCode.None;
    public KeyCode AltNegativeButton = KeyCode.None;
    public KeyCode AltPositiveButton = KeyCode.None;
    public float Gravity = 3;
    public float Sensitivity = 3;
    public bool Snap = true;

    private float currentValue = 0;
    private float targetValue = 0;
    private bool inputGiven = false;

    public void Update()
    {
        if (Input.GetKey(NegativeButton) || Input.GetKey(AltNegativeButton))
        {
            inputGiven = true;
            targetValue -= 1;
        }
        if (Input.GetKey(PositiveButton) || Input.GetKey(AltPositiveButton))
        {
            inputGiven = true;
            targetValue += 1;
        }
        if (inputGiven)
        {
            if (Snap && (currentValue > 0 && targetValue < 0 || currentValue < 0 && targetValue > 0))
            {
                currentValue = 0;
            }
            currentValue = Mathf.MoveTowards(currentValue, targetValue, Sensitivity * Time.deltaTime);
        }
        else if (currentValue != 0)
        {
            currentValue = Mathf.MoveTowards(currentValue, 0, Gravity * Time.deltaTime);
        }
        inputGiven = false;
        targetValue = 0;
    }

    /// <summary>
    /// Gets the current value of the axis.
    /// </summary>
    /// <returns>The current float value.</returns>
    public float GetCurrentValue()
    {
        return currentValue;
    }
}
