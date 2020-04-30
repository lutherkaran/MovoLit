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
       /* if (Input.GetKey(KeyCode.A))
        {
            inputDir.x = -1;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputDir.x = 1;
          
        }*/
        inputDir.x = Input.GetAxisRaw("Horizontal");
        bool throwPressed = Input.GetKeyDown(KeyCode.F);
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        
        return new InputInfo(inputDir, throwPressed, jumpPressed);
    }
    public class InputInfo
    {
        public Vector2 inputDir;
        public bool throwPressed;
        public bool jumpPressed;

        public InputInfo(Vector2 _inputDir, bool _throwPressed, bool _jumpPressed)
        {
            this.inputDir = _inputDir;
            this.throwPressed = _throwPressed;
            this.jumpPressed = _jumpPressed;
        }
    }
   
}
