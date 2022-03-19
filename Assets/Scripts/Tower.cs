using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {


    
	public Transform shootElement;
    public GameObject Towerbug;
    public Transform LookAtObj;    
    public GameObject bullet;
    public GameObject DestroyParticle;
    public Vector3 impactNormal_2;
    public Transform target;
    public int dmg = 10;
    public float shootDelay;
    bool isShoot;
    public Animator anim_2;  
    private float homeY;

    

    void Start()
    {
    }
         
    
    

    void Update () {

        
        // Tower`s rotate

        if (target)
        {  
            
            Vector3 dir = target.transform.position - LookAtObj.transform.position;
                dir.y = 0; 
                Quaternion rot = Quaternion.LookRotation(dir);                
                LookAtObj.transform.rotation = Quaternion.Slerp( LookAtObj.transform.rotation, rot, 5 * Time.deltaTime);

        }
      
        else
        {
            
            Quaternion home = new Quaternion (0, homeY, 0, 1);
            
            LookAtObj.transform.rotation = Quaternion.Slerp(LookAtObj.transform.rotation, home, Time.deltaTime);                        
        }


        // Shooting
               

            if (!isShoot)
            {
                StartCoroutine(shoot());

            }
                    
       



    }

	IEnumerator shoot()
	{
		isShoot = true;
		yield return new WaitForSeconds(shootDelay);


        if (target)
        {
            GameObject b = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
            b.GetComponent<TowerBullet>().target = target;
            b.GetComponent<TowerBullet>().twr = this;
          
        }


        isShoot = false;
	}
              

}



