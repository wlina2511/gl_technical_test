using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject[] slots;

    public static GameManager Instance;
    void Start()
    {
        Instance = this;
        slots = GameObject.FindGameObjectsWithTag("Slot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
