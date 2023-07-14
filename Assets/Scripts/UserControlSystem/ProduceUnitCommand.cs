using UnityEngine;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [InjectAsset("Chomper")] private GameObject _unitPrefab;

    public GameObject UnitPrefab => _unitPrefab;

    //public ProduceUnitCommand(GameObject unitPrefab)
    //{
    //    _unitPrefab = unitPrefab;
    //}
}
