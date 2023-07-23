using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class CommandButtonsPresenter : MonoBehaviour
{
    //[SerializeField] private SelectableValue _selectable;
    [Inject] private IObservable<ISelecatable> _selectedValues;
    [SerializeField] private CommandButtonsView _view;
    [Inject] private CommandButtonsModel _model;

    private ISelecatable _currentSelectable;

    private void Start()
    {
        _view.OnClick += _model.OnCommandButtonClicked;
        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteractions;

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

        if (_currentSelectable != null)
        {
            _model.OnSelectionChanged();
        }

        _currentSelectable = selectable;
        _view.Clear();

        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }
}
