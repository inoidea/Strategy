using UnityEngine;

public interface ISelecatable : IHealthHolder, IIconHolder
{
    Transform PivotPoint { get; }
}