using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButtons : MonoBehaviour
{

    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
    }


    public void AddTower()
    {
        GameObject t = Instantiate(tower);
        t.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        t.GetComponent<Tower>().isFollowingMouse = true;
        foreach (GameObject g in GameManager.Instance.slots)
        {
            g.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        this.gameObject.SetActive(false);
        
    }
}
