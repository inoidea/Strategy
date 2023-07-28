using System.Threading.Tasks;

public class SetRallyPointCommandExecutor : CommandExecutorBase<ISetRallyPointCommand>
{
    public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
    {
        GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
    }
}