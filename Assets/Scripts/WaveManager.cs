using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    
    public static WaveManager Instance;
    public int gameStage;
    public int waveCurrentNumber;
    public int waveTotalNumber;

    public int totalNumberOfMonster, currentNumberOfMonster;

    public Spawner spawner;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateWave();
        CreateWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            NextWave();
            UpdateWave();
        }
    }

    public void NextWave()
    {
        if(waveCurrentNumber < waveTotalNumber)
        {
            waveCurrentNumber += 1;
            StartCoroutine(GameCanvas.Instance.PopText(GameCanvas.Instance.waveText, 0.25f));
            CreateWave();
        }
    }

    public void UpdateWave()
    {
        GameCanvas.Instance.UpdateWave();
    }

    public void CreateWave()
    {
        totalNumberOfMonster = (int)(waveCurrentNumber * 1.5f);
        currentNumberOfMonster = totalNumberOfMonster;
        StartCoroutine(spawner.SpawnWave(totalNumberOfMonster));
    }

    public void UpdateMonsterNumber(int amount)
    {
        currentNumberOfMonster += amount;
        if(currentNumberOfMonster <= 0)
        {
            Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.win);
            NextWave();
            UpdateWave();
        }
    }
    
}
