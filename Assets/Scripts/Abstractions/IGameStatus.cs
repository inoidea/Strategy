using System;

public interface IGameStatus
{
    IObservable<int> Status { get; }
}
