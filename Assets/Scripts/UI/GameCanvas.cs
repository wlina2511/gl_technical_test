using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas Instance;
    public Text goldText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI dpsText;

    public TextMeshProUGUI waveText;
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

    public void UpdateLevel()
    {
        levelText.text = "Niveau " + GameManager.Instance.playerLevel.ToString();
    }

    public void UpdateDPS()
    {
        dpsText.text = "DPS: " + GameManager.Instance.dps.ToString() + "/s ";
    }

    public void UpdateWave()
    {
        waveText.text = WaveManager.Instance.waveCurrentNumber + "/" + WaveManager.Instance.waveTotalNumber;
    }

    
}
