using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(10);
        }

        if (currentHealth > 0 && currentHealth != maxHealth)
        {
            RegenerateHealth(.001f);
        }
    }

    //calculate damage taken
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void RegenerateHealth(float health)
    {
        if (currentHealth < 100)
            currentHealth += health;

        healthBar.SetHealth(currentHealth);
    }

    IEnumerator AddHealth(float health)
    {
        yield return new WaitForSeconds(1f);

        if (currentHealth < 100)
            currentHealth += health;

        yield return null;
    }
}
