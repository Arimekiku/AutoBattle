using System;
using UnityEngine;

public class BattleInput : BaseInput
{
    public event Action<Vector2> OnInputVectorReceived;
    
    public BattleInput(IInputSwitcher inputSwitcher) : base(inputSwitcher) { }
    
    public override void Update()
    {
        base.Update();
        
        Vector2 inputVector = new(Keys.HorizontalInput, Keys.VerticalInput);
        
        if (inputVector != Vector2.zero) 
            OnInputVectorReceived?.Invoke(inputVector);
        
        if (Keys.BackPressed)
            InputSwitcher.SwitchInput<PauseInput>();
    }
}