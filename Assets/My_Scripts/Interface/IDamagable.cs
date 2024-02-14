
using UnityEngine;

public interface IDamagable
{
    public int Health { get; set; }
    public void TakeDamage(int damage);
    public void Die();
}
