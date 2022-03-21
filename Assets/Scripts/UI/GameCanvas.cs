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

    public Image[] availableTurrets;

    public TextMeshProUGUI waveText;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateGold();
        UpdateTurrets();
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

    public void UpdateTurrets()
    {
        for (int i = 0; i < GameManager.Instance.turretAvailable; i++)
        {
            availableTurrets[i].gameObject.SetActive(true);
        }
    }

    public void UpdateTurretsTaken()
    {
        availableTurrets[GameManager.Instance.turretsTaken].color = Color.red;
    }

    public IEnumerator PopText(TextMeshProUGUI target, float duration)
    {
        float scaleModifier = 1.0f;
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = transform.localScale;
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, 1.2f, time / duration);
            target.transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }
        target.transform.localScale = startScale * 1.2f;

        scaleModifier = 1.2f;
        time = 0;
        startValue = scaleModifier;
        startScale = transform.localScale;
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, 1.0f, time / duration);
            target.transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }
        target.transform.localScale = startScale * 1.0f;

    }

}
