using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas Instance;
    public Text goldText;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateGold();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGold()
    {
        goldText.text = GameManager.Instance.goldAmount.ToString();
    }

    
}
