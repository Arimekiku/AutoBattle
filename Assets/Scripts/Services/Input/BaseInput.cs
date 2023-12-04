using System;

public abstract class BaseInput : IUpdatable
{
    protected readonly IInputSwitcher InputSwitcher;
    
    public event Action OnBackPressed;

    protected BaseInput(IInputSwitcher inputSwitcher)
    {
        InputSwitcher = inputSwitcher;
    }
    
    public virtual void Update()
    {
        if (Keys.BackPressed)
            OnBackPressed?.Invoke();
    }
}