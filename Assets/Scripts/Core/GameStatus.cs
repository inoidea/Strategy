using System;
using System.Threading;
using UniRx;
using UnityEngine;

public class GameStatus : MonoBehaviour, IGameStatus
{
    private Subject<int> _status = new Subject<int>();

    public IObservable<int> Status => _status;

    private void checkStatus(object state)
    {
        if (FactionMember.FactionsCount == 0)
        {
            _status.OnNext(0);
        }
        else if (FactionMember.FactionsCount == 1)
        {
            _status.OnNext(FactionMember.GetWinner());
        }
    }

    private void Update()
    {
        ThreadPool.QueueUserWorkItem(checkStatus);
    }
}