
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int _startHealth;
    private int _health;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                Die();
            }
        }
    }

    private void Start()
    {
        _health = _startHealth;
    }
    public void Die()
    {
        Debug.Log("Player died");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
