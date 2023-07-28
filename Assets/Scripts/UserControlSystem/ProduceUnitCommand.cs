using UnityEngine;
using Zenject;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [InjectAsset("Chomper")] private GameObject _unitPrefab;
    [Inject(Id = "Chomper")] public string UnitName { get; }
    [Inject(Id = "Chomper")] public Sprite Icon { get; }
    [Inject(Id = "Chomper")] public float ProductionTime { get; }

    public GameObject UnitPrefab => _unitPrefab;
}
