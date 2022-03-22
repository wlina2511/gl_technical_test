using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{

    
    public Text refreshText, levelUpText;

    // Start is called before the first frame update
    void Start()
    {
        refreshText.text = GameManager.Instance.refreshCost.ToString();
        levelUpText.text = GameManager.Instance.levelUpCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshTowers()
    {
        if (GameManager.Instance.refreshCost < GameManager.Instance.goldAmount)
        {
            Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.refresh);

            GameManager.Instance.UpdateGold(-GameManager.Instance.refreshCost);
            foreach (TowerButtons t in GameManager.Instance.towerButtons)
            {
                t.ChangeState(true);
            }
        }
        else
        {
            Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.error);
        }
    }

    public void LevelUp()
    {
        if (GameManager.Instance.levelUpCost < GameManager.Instance.goldAmount)
        {
            Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.levelUp);

            GameManager.Instance.UpdateGold(-GameManager.Instance.levelUpCost);
            GameManager.Instance.LevelUp();
            GameManager.Instance.levelUpCost += 2;
            levelUpText.text = GameManager.Instance.levelUpCost.ToString();
        }
        else
        {
            Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.error);

        }


    }
}
