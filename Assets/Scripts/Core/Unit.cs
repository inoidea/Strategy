using UnityEngine;

public class Unit : MonoBehaviour, ISelecatable
{
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    private float _health = 1000;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public GameObject GameObject => gameObject;
}
