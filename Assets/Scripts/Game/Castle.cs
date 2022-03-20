using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{

    public int maxHealth, currentHealth;

    public Slider healthBar;

    public TextMeshProUGUI healthText;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.minValue = 0;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        healthText.text = currentHealth.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;
        healthText.text = currentHealth.ToString();

        anim.SetTrigger("Damage");

        if (amount > currentHealth)
        {
           // Dead
        }
    }
}
