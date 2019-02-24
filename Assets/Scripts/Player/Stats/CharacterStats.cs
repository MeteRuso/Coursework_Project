
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public Stat Damage;
    public Stat Resist;

    public Stat maxHealth ;
    public Stat currentHealth;

    public Stat maxStamina ;
    public Stat currentStamina;

    public Stat maxMana ;
    public Stat currentMana;

    private void Start()
    {
        //InvokeRepeating("Replenish", 5, 5);
    }

    private void Update()
    {

    }

    private void Awake()
    {
        //currentHealth = maxHealth;
        //currentStamina = maxStamina;
        //currentMana = maxMana;
    }

    public void CalcDamage(int Damage)
    {
        int FinalDamage = Damage * Resist.GetValue() / 100;
        TakeDamage(FinalDamage);
    }

    public void TakeDamage(int Damage)
    {
        currentHealth.AddValue(-Damage);

        if (currentHealth.GetValue() <= 0)
        {
            CharDeath();
        }

    }

    public virtual void CharDeath()
    {

    }

    public void Replenish()
    {
        //float counter = 0f;
        //counter += Time.deltaTime;
        //if (counter > 5f)
        //{

        //    counter = 0
        //}
        if (maxHealth.GetValue() - currentHealth.GetValue() > 3)
        {
            currentHealth.AddValue(3);
        }
        else
        {
            currentHealth.SetValue(maxHealth.GetValue());
        }

        if (maxStamina.GetValue() - currentStamina.GetValue() > 3)
        {
            currentStamina.AddValue(3);
        }
        else
        {
            currentStamina.SetValue(maxStamina.GetValue());
        }

        if (maxMana.GetValue() - currentMana.GetValue() > 5)
        {
            currentMana.AddValue(5);
        }
        else
        {
            currentMana.SetValue(maxMana.GetValue());
        }
        Debug.Log("Heal");
    }

    public void Heal(int Damage)
    {
        if (currentHealth.GetValue() + Damage < maxHealth.GetValue())
        {
            currentHealth.AddValue(Damage);
        }
        else
        {
            currentHealth.SetValue(maxHealth.GetValue());
        }
    }

}
