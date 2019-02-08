
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public Stat Damage;
    public Stat phyResist;
    public Stat magResist;

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void CalcDamage(int Damage)
    {
        int FinalDamage = 0;
        //if (damage.type = 1)
        TakeDamage(FinalDamage);
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;

        if (currentHealth <= 0)
        {
            CharDeath();
        }

    }

    public virtual void CharDeath()
    {

    }

    public void Heal(int Damage)
    {
        if (currentHealth + Damage < maxHealth)
        {
            currentHealth += Damage;
        }
        else
        {
            currentHealth = maxHealth;
        }
    }

}
