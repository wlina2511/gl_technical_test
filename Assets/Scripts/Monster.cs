using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public GameObject target;
    public float health, atkSpeed, moveSpeed;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        atkSpeed = 0.5f * level;
        moveSpeed = 0.5f * level;
        health = 5 * level;

        target = GameObject.FindGameObjectWithTag("Castle");

        transform.localScale *= level * 0.5f;

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
}
