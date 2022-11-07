using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private KeyBindings _keyBindings;

    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    void Awake()
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
        InitKeyBindings(); // Initalize KeyBindings Object
        SetDefault(); // Set KeyBindings to default values
    }

    /// <summary>
    /// Initializes the KeyBindings 
    /// </summary>
    private void InitKeyBindings()
    {
        _keyBindings = ScriptableObject.CreateInstance<KeyBindings>();
        KeyBindingAction[] keyBindingActions = (KeyBindingAction[])Enum.GetValues(typeof(KeyBindingAction));
        _keyBindings.KeyBindingChecks = new KeyBindings.KeyBindingCheck[keyBindingActions.Length];
        foreach (KeyBindingAction keyBindingAction in keyBindingActions)
        {
            KeyBindings.KeyBindingCheck newKeyBinding = new KeyBindings.KeyBindingCheck();
            newKeyBinding.keyBindingAction = keyBindingAction;
            newKeyBinding.keyCode = new KeyCode[] { KeyCode.None };
            int index = (int)keyBindingAction;
            _keyBindings.KeyBindingChecks.SetValue(newKeyBinding, index);
        }
    }

    /// <summary>
    /// Sets all KeyBindingAction KeyCodes to their default value.
    /// </summary>
    public void SetDefault()
    {
        SetKeyForAction(KeyBindingAction.MoveLeft, new KeyCode[] { KeyCode.LeftArrow });
        SetKeyForAction(KeyBindingAction.MoveRight, new KeyCode[] { KeyCode.RightArrow });
        SetKeyForAction(KeyBindingAction.Jump, new KeyCode[] { KeyCode.Space });
    }

    /// <summary>
    /// Gets the currenly set KeyCodes for a KeyBindingAction.
    /// </summary>
    /// <param name="keyBindingAction">The KeyBindingAction you want the KeyCodes from</param>
    /// <returns>An array containing the currently set KeyCodes</returns>
    public KeyCode[] GetKeyForAction(KeyBindingAction keyBindingAction)
    {
        foreach (KeyBindings.KeyBindingCheck keyBindingCheck in _keyBindings.KeyBindingChecks)
        {
            if (keyBindingCheck.keyBindingAction == keyBindingAction)
            {
                return keyBindingCheck.keyCode;
            }
        }
        return new KeyCode[] { KeyCode.None };
    }

    /// <summary>
    /// Sets a new array of KeyCodes for an action.
    /// </summary>
    /// <param name="keyBindingAction">The action to assign new KeyCodes to.</param>
    /// <param name="newKeyCode">The array of KeyCodes to assign to the action.</param>
    public void SetKeyForAction(KeyBindingAction keyBindingAction, KeyCode[] newKeyCode)
    {
        foreach (KeyBindings.KeyBindingCheck keyBindingCheck in _keyBindings.KeyBindingChecks)
        {
            if (keyBindingCheck.keyBindingAction == keyBindingAction)
            {
                keyBindingCheck.keyCode = newKeyCode;
            }
        }
    }

    /// <summary>
    /// Checks if all keys of an action are pressed down.
    /// </summary>
    /// <param name="keyBindingAction">The action which keys are checked.</param>
    /// <returns>Either false or true.</returns>
    public bool GetKeyDown(KeyBindingAction keyBindingAction)
    {
        foreach (KeyBindings.KeyBindingCheck keyBindingCheck in _keyBindings.KeyBindingChecks)
        {
            if (keyBindingCheck.keyBindingAction == keyBindingAction)
            {
                foreach (KeyCode keyCode in keyBindingCheck.keyCode)
                {
                    if (!Input.GetKeyDown(keyCode))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks if all keys of an action are pressed and hold.
    /// </summary>
    /// <param name="keyBindingAction">The action which keys are checked.</param>
    /// <returns>Either false or true.</returns>
    public bool GetKey(KeyBindingAction keyBindingAction)
    {
        foreach (KeyBindings.KeyBindingCheck keyBindingCheck in _keyBindings.KeyBindingChecks)
        {
            if (keyBindingCheck.keyBindingAction == keyBindingAction)
            {
                foreach (KeyCode keyCode in keyBindingCheck.keyCode)
                {
                    if (!Input.GetKey(keyCode))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks if all keys of an action are released.
    /// </summary>
    /// <param name="keyBindingAction">The action which keys are checked.</param>
    /// <returns>Either false or true.</returns>
    public bool GetKeyUp(KeyBindingAction keyBindingAction)
    {
        foreach (KeyBindings.KeyBindingCheck keyBindingCheck in _keyBindings.KeyBindingChecks)
        {
            if (keyBindingCheck.keyBindingAction == keyBindingAction)
            {
                foreach (KeyCode keyCode in keyBindingCheck.keyCode)
                {
                    if (!Input.GetKeyUp(keyCode))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Gets the current X axis move direction.
    /// </summary>
    /// <returns>A float of value -1, 0 or 1</returns>
    public float GetMoveAxis()
    {
        float axis = 0;
        if (GetKey(KeyBindingAction.MoveLeft))
        {
            axis -= 1;
        }
        if (GetKey(KeyBindingAction.MoveRight))
        {
            axis += 1;
        }
        return axis;
    }
}
