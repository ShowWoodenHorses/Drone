
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int _startHealth;
    [SerializeField] private DropBomb _dropBomb;

    [SerializeField] private GameObject TakeDamageEffect;
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
        _dropBomb = GetComponent<DropBomb>();
        _health = _startHealth;
    }
    public void Die()
    {
        Debug.Log("Player died");
    }

    public void TakeDamage(int damage)
    {
        _dropBomb.countBomb -= damage;
        TakeDamageEffect.SetActive(false);
        if (_dropBomb.countBomb < 0)
            _dropBomb.countBomb = 0;
        if (!TakeDamageEffect.activeInHierarchy)
            StartCoroutine(ShowEffectTakeDamage());
    }

    private IEnumerator ShowEffectTakeDamage()
    {
        TakeDamageEffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        TakeDamageEffect.SetActive(false);
    }
}
