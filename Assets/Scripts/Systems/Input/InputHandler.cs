using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputHandler : MonoBehaviour, IInputSwitcher
{
    private List<IUpdatable> _inputs;
    private IUpdatable _currentInput;

    public void Build(IUpdatable defaultInput, params IUpdatable[] otherInputs)
    {
        _currentInput = defaultInput;
        _inputs = new(otherInputs) { _currentInput };
    }
    
    private void Update()
    {
        _currentInput.Update();
    }

    public void SwitchInput<T>() where T: IUpdatable
    {
        IUpdatable newInput = _inputs.FirstOrDefault(i => i is T);

        _currentInput = newInput ?? throw new($"Requested type is invalid: {typeof(T)}");
    }
}