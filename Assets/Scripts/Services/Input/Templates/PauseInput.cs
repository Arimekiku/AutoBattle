using System;
using UnityEngine;

public class PauseInput : BaseInput
{
    public event Action OnUpPressed, OnDownPressed, OnRightPressed, OnLeftPressed;
    
    public PauseInput(IInputSwitcher inputSwitcher) : base(inputSwitcher) { }
    
    public override void Update()
    {
        base.Update();
        
        if (Keys.UpPressed)
            OnUpPressed?.Invoke();
        
        if (Keys.DownPressed)
            OnDownPressed?.Invoke();
        
        if (Keys.RightPressed)
            OnRightPressed?.Invoke();
        
        if (Keys.LeftPressed)
            OnLeftPressed?.Invoke();

        if (Keys.BackPressed)
            InputSwitcher.SwitchInput<PauseInput>();
    }
}