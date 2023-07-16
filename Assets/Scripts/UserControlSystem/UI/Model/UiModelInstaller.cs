﻿using System.ComponentModel;
using UnityEngine;
using Zenject;

public class UiModelInstaller : MonoInstaller
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private Vector3Value _vector3Value;
    [SerializeField] private AttackableValue _attackableValue;

    public override void InstallBindings()
    {
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        Container.Bind<SelectableValue>().FromInstance(_selectableValue);
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        Container.Bind<AttackableValue>().FromInstance(_attackableValue);

        Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IStopCommand>>().To<StopCommandCreator>().AsTransient();

        Container.Bind<CommandButtonsModel>().AsTransient();
    }
}