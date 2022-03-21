﻿using UnityEngine;
using System.Collections;

public class TowerTrigger : MonoBehaviour {

	public Tower twr;    
    public bool lockE;
	public GameObject curTarget;
    


    void OnTriggerEnter(Collider other)
	{
        if (!twr.isFollowingMouse)
        {
            if (other.CompareTag("MonsterTarget") && !lockE)
            {
                twr.target = other.gameObject.transform;
                curTarget = other.gameObject;
                lockE = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(twr.target == null)
        {
            if (!twr.isFollowingMouse)
            {
                if (other.CompareTag("MonsterTarget") && !lockE)
                {
                    twr.target = other.gameObject.transform;
                    curTarget = other.gameObject;
                    lockE = true;
                }
            }
        }
        
    }

    void Update()
	{
        if (!twr.isFollowingMouse)
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
	}


	void OnTriggerExit(Collider other)
	{
        if (!twr.isFollowingMouse)
        {
            if (other.CompareTag("MonsterTarget") && other.gameObject == curTarget)
            {
                lockE = false;
                twr.target = null;
            }
        }
		
	}
	
}
