using UnityEngine;

public class OutlinePresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedValue;

    private void Start()
    {
        _selectedValue.OnSelected += SelectObject;
        SelectObject(_selectedValue.CurrentValue);
    }

    private void SelectObject (ISelecatable unit)
    {
        if (unit != null) {

            if (!unit.GameObject.TryGetComponent(out Outline outline))
            {
                outline = unit.GameObject.AddComponent<Outline>();
            }

            outline.OutlineMode = Outline.Mode.OutlineVisible;
            outline.OutlineColor = Color.green;
            outline.OutlineWidth = 3;
        }
    }

    private void OnDestroy()
    {
        _selectedValue.OnSelected -= SelectObject;
    }
}
