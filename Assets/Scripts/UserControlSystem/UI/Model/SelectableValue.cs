using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : ScriptableObject
{
    public ISelecatable CurrentValue { get; private set; }
    public Action<ISelecatable> OnSelected;

    public void SetValue(ISelecatable value)
    {
        CurrentValue = value;
        OnSelected?.Invoke(value);
    }
}