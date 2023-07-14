using UnityEngine;
using UnityEngine.UI;

public class OutlinePresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    
    private Outline[] _outlineSelectors;
    private ISelecatable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += OnSelected;
        OnSelected(_selectable.CurrentValue);
    }

    private void OnSelected(ISelecatable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }

        _currentSelectable = selectable;
        SetSelected(_outlineSelectors, false);
        _outlineSelectors = null;

        if (selectable != null)
        {
            _outlineSelectors = (selectable as Component).GetComponentsInParent<Outline>();
            SetSelected(_outlineSelectors, true);
        }
    }

    static void SetSelected(Outline[] selectors, bool value)
    {
        if (selectors != null)
        {
            for (int i = 0; i < selectors.Length; i++)
            {
                selectors[i].OutlineMode = value ? Outline.Mode.OutlineVisible : Outline.Mode.OutlineHidden;
                selectors[i].OutlineColor = Color.green;
                selectors[i].OutlineWidth = 3;
            }
        }
    }

    private void OnDestroy()
    {
        _selectable.OnSelected -= OnSelected;
    }
}
