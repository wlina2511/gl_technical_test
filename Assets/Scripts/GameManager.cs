using System.Collections;
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


    public int refreshCost, levelUpCost;

    public static GameManager Instance;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp()
    {
        playerLevel += 1;
    }

    public void ChangeGold(int amount)
    {
        goldAmount += amount;
        GameCanvas.Instance.UpdateGold();
    }
}
