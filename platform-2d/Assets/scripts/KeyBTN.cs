using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBTN
{
    private KeyCode[] keys;

    public KeyBTN(KeyCode key)
    {
        this.keys = new[] {key};
    }
    public KeyBTN(KeyCode[] keys)
    {
        this.keys = keys; 
    }

    public bool isPressed()
    {
        bool isPressed = false;
        foreach (KeyCode key in keys)
        {
            if(Input.GetKey(key))
            {
                isPressed = true;
            }
        }
        return isPressed;
    }
    public bool isBeingPressed()
    {
        bool isBeingPressed = false;
        foreach (KeyCode key in keys)
        {
            if(Input.GetKeyDown(key))
            {
                isBeingPressed = true;
            }
        }
        return isBeingPressed;
    }
    public bool isBeingUnpressed()
    {
        bool isBeingUnpressed = false;
        foreach(KeyCode key in keys)
        {
            if(Input.GetKeyUp(key))
            {
                isBeingUnpressed = true;
            }
        }
        return isBeingUnpressed;
    }
}