using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    InputInfo inputInfo;
    bool isUpdateProcessed = false;

    public void InputUpdate(float dt)
    {
        isUpdateProcessed = false;
    }
    public InputInfo GetInfo()
    {
        if (!isUpdateProcessed)
        {
            inputInfo = CreateInput();
            isUpdateProcessed = true;
        }
        return inputInfo;
    }

    public InputInfo CreateInput()
    {
        Vector2 inputDir = new Vector2();

        inputDir.x = Input.GetAxisRaw("Horizontal");
        bool throwPressed = Input.GetKeyDown(KeyCode.Mouse0);
        bool pickUp = Input.GetKeyDown(KeyCode.E);
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        bool switchPressed = Input.GetKeyDown(KeyCode.G);
        
        return new InputInfo(inputDir, pickUp,throwPressed, jumpPressed,switchPressed);
    }
    public class InputInfo
    {
        public Vector2 inputDir;
        public bool throwPressed;
        public bool jumpPressed;
        public bool switchPlayerPressed;
        public bool pickUp;

        public InputInfo(Vector2 _inputDir, bool _pickUp, bool _throwPressed, bool _jumpPressed, bool _switchPlayerPressed)
        {
            this.inputDir = _inputDir;
            this.throwPressed = _throwPressed;
            this.jumpPressed = _jumpPressed;
            this.switchPlayerPressed = _switchPlayerPressed;
            this.pickUp = _pickUp;
        }
    }
   
}
