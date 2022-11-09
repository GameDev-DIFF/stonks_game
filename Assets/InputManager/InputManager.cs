using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }
    [SerializeField]
    private KeyBoundAction[] KeyBoundActions;
    private Dictionary<string, KeyBoundAction> _keyBoundActions = new Dictionary<string, KeyBoundAction>();
    private Dictionary<string, KeyBoundAction> _defaultKeyBoundActionValues = new Dictionary<string, KeyBoundAction>();
    [SerializeField]
    private Axis[] Axes;
    private Dictionary<string, Axis> _axes = new Dictionary<string, Axis>();
    private Dictionary<string, Axis> _defaultAxisValues = new Dictionary<string, Axis>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        InitKeyBindings(); // Initialize KeyBindings
        SetDefault(); // Set KeyBinding Values to Default
    }

    private void Update()
    {
        foreach (Axis axis in _axes.Values)
        {
            axis.Update();
        }
    }

    /// <summary>
    /// Initializes the KeyBindings
    /// </summary>
    private void InitKeyBindings()
    {
        foreach (KeyBoundAction keyBoundAction in KeyBoundActions)
        {
            _defaultKeyBoundActionValues.Add(keyBoundAction.Name, keyBoundAction);
        }
        Array.Clear(KeyBoundActions, 0, KeyBoundActions.Length);
        foreach (Axis axis in Axes)
        {
            _defaultAxisValues.Add(axis.Name, axis);
        }
        Array.Clear(Axes, 0, Axes.Length);
    }

    /// <summary>
    /// Sets all KeyBindings to their default value.
    /// </summary>
    public void SetDefault()
    {
        _keyBoundActions = _defaultKeyBoundActionValues;
        _axes = _defaultAxisValues;
    }

    /// <summary>
    /// Gets the currenly set values for a KeyBoundAction.
    /// </summary>
    /// <param name="actionName">The name of the action you want the values from.</param>
    /// <returns>The current KeyBoundAction values</returns>
    public KeyBoundAction GetKeyBoundActionValues(string actionName)
    {
        if (_keyBoundActions.ContainsKey(actionName))
        {
            return _keyBoundActions[actionName];
        }
        else
        {
            throw new KeyNotFoundException("Could find " + '"' + actionName + '"' + " action!");
        }
    }

    /// <summary>
    /// Sets a new values to an KeyBoundAction.
    /// </summary>
    /// <param name="newActionValues">The set of values to assign to a KeyBoundAction.</param>
    public void SetKeyBoundActionValues(KeyBoundAction newActionValues)
    {
        if (_keyBoundActions.ContainsKey(newActionValues.Name))
        {
            _keyBoundActions.Add(newActionValues.Name, newActionValues);
        }
        else
        {
            throw new KeyNotFoundException("Could find " + '"' + newActionValues.Name + '"' + " action!");
        }
    }

    /// <summary>
    /// Gets the currenly set values for a Axis.
    /// </summary>
    /// <param name="axisName">The name of the axis you want the values from.</param>
    /// <returns>The current Axis values</returns>
    public Axis GetAxisValues(string axisName)
    {
        if (_axes.ContainsKey(axisName))
        {
            return _axes[axisName];
        }
        else
        {
            throw new KeyNotFoundException("Could not find " + '"' + axisName + '"' + " axis!");
        }
    }

    /// <summary>
    /// Sets a new values to an Axis.
    /// </summary>
    /// <param name="newAxisValues">The set of values to assign to a Axis.</param>
    public void SetAxisValues(Axis newAxisValues)
    {
        if (_axes.ContainsKey(newAxisValues.Name))
        {
            _axes.Add(newAxisValues.Name, newAxisValues);
        }
        else
        {
            throw new KeyNotFoundException("Could not find " + '"' + newAxisValues.Name + '"' + " axis!");
        }
    }

    /// <summary>
    /// Checks if any of the bound keys of an action are pressed down.
    /// </summary>
    /// <param name="actionName">The name of the action which keys are checked.</param>
    /// <returns>Either false or true.</returns>
    public bool GetKeyDown(string actionName)
    {
        if (_keyBoundActions.ContainsKey(actionName))
        {
            KeyBoundAction action = _keyBoundActions[actionName];
            if (Input.GetKeyDown(action.Button) || Input.GetKeyDown(action.AltButton))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new KeyNotFoundException("Could find " + '"' + actionName + '"' + " action!");
        }
    }

    /// <summary>
    /// Checks if any of the bound keys of an action are pressed and held.
    /// </summary>
    /// <param name="actionName">The name of the action which keys are checked.</param>
    /// <returns>Either false or true.</returns>
    public bool GetKey(string actionName)
    {
        if (_keyBoundActions.ContainsKey(actionName))
        {
            KeyBoundAction action = _keyBoundActions[actionName];
            if (Input.GetKey(action.Button) || Input.GetKey(action.AltButton))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new KeyNotFoundException("Could find " + '"' + actionName + '"' + " action!");
        }
    }

    /// <summary>
    /// Checks if any of the bound keys of an action are released.
    /// </summary>
    /// <param name="actionName">The name of the action which keys are checked.</param>
    /// <returns>Either false or true.</returns>
    public bool GetKeyUp(string actionName)
    {
        if (_keyBoundActions.ContainsKey(actionName))
        {
            KeyBoundAction action = _keyBoundActions[actionName];
            if (Input.GetKeyUp(action.Button) || Input.GetKeyUp(action.AltButton))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new KeyNotFoundException("Could find " + '"' + actionName + '"' + " action!");
        }
    }

    /// <summary>
    /// Checks if any of the bound keys of an axis are pressed and gets its current value.
    /// </summary>
    /// <returns>The current float value of the axis</returns>
    public float GetAxis(string axisName)
    {
        if (_axes.ContainsKey(axisName))
        {
            return _axes[axisName].GetCurrentValue();
        }
        else
        {
            throw new KeyNotFoundException("Could find " + '"' + axisName + '"' + " axis!");
        }
    }
}
