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

    public SkinnedMeshRenderer renderer;

    public Animator anim;

    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        atkSpeed = 0.5f * level;
        atkValue = 3;
        moveSpeed = 10 / level;
        maxHealth = 5 * level;

        target = GameObject.FindGameObjectWithTag("Castle");

        transform.localScale *= 1+ level * 0.5f;

        healthBar.minValue = 0;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        currentHealth = maxHealth;

        if (level > 3)
        {
            renderer.material.color = Color.blue;
        }


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
        audio.PlayOneShot(SoundManager.Instance.monsterDeath);
        StartCoroutine(DieCoroutine());
        monsterTarget.tag = "Dead";
        WaveManager.Instance.UpdateMonsterNumber(-1);
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
            audio.PlayOneShot(SoundManager.Instance.monsterAttack);
        }
    }

    IEnumerator DieCoroutine()
    {
        moveSpeed = 0;
        healthBar.gameObject.SetActive(false);
        anim.SetBool("Death", true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(LerpPosition(this.transform.position - new Vector3(0,3,0), 1.0f));
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

}
