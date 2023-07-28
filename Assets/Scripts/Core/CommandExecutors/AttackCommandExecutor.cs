using System.Threading.Tasks;
using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"{name} is attacking {command.Target} (hp {command.Target.Health}/{command.Target.MaxHealth})!");
    }
}
