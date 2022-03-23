﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject[] slots;
    public TowerButtons[] towerButtons;

    public int goldAmount;
    public int playerLevel;

    public int turretsTaken;
    public int turretAvailable;

    public float dps;

    public GameObject fence;


    public int refreshCost, levelUpCost;

    public static GameManager Instance;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
            foreach(GameObject m in monsters)
            {
                m.GetComponent<Monster>().anim.SetBool("Victory", true);
                m.GetComponent<Monster>().moveSpeed = 0;
                
            }
            fence.gameObject.SetActive(true);
        }
    }

    public void LevelUp()
    {
        playerLevel += 1;
        turretAvailable += 1;
        GameCanvas.Instance.UpdateTurrets();
        GameCanvas.Instance.UpdateLevel();
    }

    public void UpdateGold(int amount)
    {
        goldAmount += amount;
        GameCanvas.Instance.UpdateGold();
    }

    public void UpdateDPS()
    {
        foreach (GameObject g in slots)
        {
            if (g.GetComponent<Slot>().isUsed)
            {
                dps += g.GetComponent<Slot>().tower.dmg / g.GetComponent<Slot>().tower.shootDelay;
            }
        }
        GameCanvas.Instance.UpdateDPS();
    }
}
