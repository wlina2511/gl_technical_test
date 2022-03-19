using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{

    public GameObject target, monsterTarget;
    public float maxHealth, currentHealth, atkSpeed, moveSpeed;
    public int level, atkValue;

    public Slider healthBar;


    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        atkSpeed = 0.5f * level;
        atkValue = 3;
        moveSpeed = 0.5f * level * 5;
        maxHealth = 5 * level;

        target = GameObject.FindGameObjectWithTag("Castle");

        transform.localScale *= level * 0.5f;

        healthBar.minValue = 0;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        currentHealth = maxHealth;


    }
    

    // Update is called once per frame
    void Update()
    {
        

        // Check if the position of the cube and sphere are approximately equal.
        if ( Vector3.Distance(transform.position, target.transform.position) > 1f)
        {
            float step = moveSpeed * Time.deltaTime; // Calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;

        if (amount > currentHealth)
        {
            Die();
        }
    }

    public void Die()
    {
        
        gameObject.SetActive(false);
        monsterTarget.tag = "Dead";
    }

    void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Castle")
        {

            moveSpeed = 0;
            target = other.gameObject;
            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y,target.transform.position.z);
            //transform.LookAt(targetPosition);
            anim.SetBool("RUN", false);
            anim.SetBool("Attack", true);

        }

    }

    public void Attack()
    {
        if (target.tag.Equals("Castle"))
        {
            target.GetComponent<Castle>().TakeDamage(atkValue);
        }
    }

    
}
