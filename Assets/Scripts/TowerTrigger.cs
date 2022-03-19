using UnityEngine;
using System.Collections;

public class TowerTrigger : MonoBehaviour {

	public Tower twr;    
    public bool lockE;
	public GameObject curTarget;
    


    void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("MonsterTarget") && !lockE)
		{   
			twr.target = other.gameObject.transform;            
            curTarget = other.gameObject;
			lockE = true;
		}
       
    }
	void Update()
	{
        if (curTarget)
        {
            if (curTarget.CompareTag("Dead"))
            {
                lockE = false;
                twr.target = null;               
            }
        }




        if (!curTarget) 
		{
			lockE = false;            
        }
	}
	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("MonsterTarget") && other.gameObject == curTarget)
		{
			lockE = false;
            twr.target = null;            
        }
	}
	
}
