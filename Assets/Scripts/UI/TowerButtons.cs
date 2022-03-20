using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtons : MonoBehaviour
{

    public GameObject tower;
    public int towerCost;
    public Text costText;

    // Start is called before the first frame update
    void Start()
    {
        RandomCost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddTower()
    {
        if (towerCost < GameManager.Instance.goldAmount)
        {
            GameObject t = Instantiate(tower);
            t.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            t.GetComponent<Tower>().isFollowingMouse = true;
            t.GetComponent<Tower>().cost = towerCost;
            foreach (GameObject g in GameManager.Instance.slots)
            {
                g.GetComponent<MeshRenderer>().material.color = Color.red;
            }

            
            ChangeState(false);
        }
        
        
    }

    public void ChangeState(bool state)
    {
        RandomCost();
        gameObject.SetActive(state);
    }

    public void RandomCost()
    {
        towerCost = Random.Range(1, 12);
        costText.text = towerCost.ToString();
    }
}
