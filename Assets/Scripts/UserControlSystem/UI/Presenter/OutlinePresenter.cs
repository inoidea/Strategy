using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OutlinePresenter : MonoBehaviour
{
    //[SerializeField] private SelectableValue _selectable;
    [Inject] private IObservable<ISelecatable> _selectedValues;

    private Outline[] _outlineSelectors;
    private ISelecatable _currentSelectable;

    private void Start()
    {
        //_selectable.OnNewValue += OnNewValue;
        //OnNewValue(_selectable.CurrentValue);

        _selectedValues.Subscribe(OnNewValue);
    }

    private void OnNewValue(ISelecatable selectable)
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
}
