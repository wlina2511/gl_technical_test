using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public UnityEngine.UI.Toggle[] colorToggles;
    public Color currentColor;
    public DrawSystem DS;


    void Start()
    {
        
    }
   
    void Update()
    {
        for(int i = 0; i < colorToggles.Length; i++)
        {
            if(colorToggles[i].isOn)
            {
                currentColor = colorToggles[i].targetGraphic.color;
                break;
            }
        }
    }

    public void CloseMenu()
    {
        this.GetComponent<Animator>().enabled = true;
        StartCoroutine(WaitAndDisable());
    }

    IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(1);
        DS.PrintTShirt();
        DS.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
