using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeBetweenSpawn;
    private float currentTimeBetweenSpawn;

    public int maxLevel;

    public Transform[] spawners;

    public GameObject monsterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeBetweenSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeBetweenSpawn > timeBetweenSpawn)
        {
            Spawn(spawners[Random.Range(0,spawners.Length)].position, Random.Range(1,maxLevel + 1));
            currentTimeBetweenSpawn = 0;
        }
        else
        {
            currentTimeBetweenSpawn += Time.deltaTime;
        }
    }

    private void Spawn(Vector3 pos, int level)
    {
        GameObject monster = Instantiate(monsterPrefab, pos, Quaternion.identity);
        monster.transform.position = monster.transform.position + new Vector3(0, monster.transform.localScale.y, 0);
        monster.GetComponent<Monster>().level = level;
    }
}
