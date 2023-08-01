using UnityEngine;

public class Unit : MonoBehaviour, ISelecatable, IAttackable, IAutomaticAttacker
{
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommand;
    [SerializeField] private int _damage = 25;
    [SerializeField] private float _visionRadius = 8f;

    private float _health = 1000;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => _pivotPoint;
    public int Damage => _damage;
    public float VisionRadius => _visionRadius;

    public void RecieveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }

        _health -= amount;

        if (_health <= 0)
        {
            _animator.SetTrigger("PlayDead");
            Invoke(nameof(Destroy), 1f);
        }
    }

    private async void Destroy()
    {
        await _stopCommand.ExecuteSpecificCommand(new StopCommand());
        Destroy(gameObject);
    }
}
