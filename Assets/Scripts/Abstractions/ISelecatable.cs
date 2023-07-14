using UnityEngine;

public interface ISelecatable
{
    float Health { get; }
    float MaxHealth { get; }
    Sprite Icon { get; }
}