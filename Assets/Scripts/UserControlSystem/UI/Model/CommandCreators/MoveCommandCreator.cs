﻿using System;
using UnityEngine;
using Zenject;

public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
{
    [Inject] private AssetsContext _context;
    private Action<IMoveCommand> _creationCallback;

    [Inject]
    private void Init(Vector3Value groundClicks)
    {
        groundClicks.OnNewValue += OnNewValue;
    }

    private void OnNewValue(Vector3 groundClick)
    {
        _creationCallback?.Invoke(_context.Inject(new MoveCommand(groundClick)));
        _creationCallback = null;
    }

    protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
    {
        _creationCallback = creationCallback;
    }

    public override void ProcessCancel()
    {
        base.ProcessCancel();
        _creationCallback = null;
    }
}
