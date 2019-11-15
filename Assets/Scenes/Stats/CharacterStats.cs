using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // shouldn't have modifiers, so no Stat
    public int maxHealth = 100;
    public int CurrentHealth { get; private set; }

    [SerializeField] private Stat damage;

    void Awake()
    {
        CurrentHealth = maxHealth;
    }

    void Update()
    {
        //
    }

    public void TakeDamage (int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // override
        Debug.Log(transform.name + " DIED");
    }
}
