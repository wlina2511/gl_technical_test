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

    public GameObject slot;


    public bool isFollowingMouse;

    

    void Start()
    {
    }
         
    
    

    void Update () {

        if (!isFollowingMouse)
        {
            // Tower`s rotate

            if (target)
            {

                Vector3 dir = target.transform.position - LookAtObj.transform.position;
                dir.y = 0;
                Quaternion rot = Quaternion.LookRotation(dir);
                LookAtObj.transform.rotation = Quaternion.Slerp(LookAtObj.transform.rotation, rot, 5 * Time.deltaTime);

            }

            else
            {

                Quaternion home = new Quaternion(0, homeY, 0, 1);

                LookAtObj.transform.rotation = Quaternion.Slerp(LookAtObj.transform.rotation, home, Time.deltaTime);
            }


            // Shooting


            if (!isShoot)
            {
                StartCoroutine(shoot());

            }
        }
        else
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                // Do something with the object that was hit by the raycast.
                //this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
                transform.position = hit.point;
                if (hit.transform.tag.Equals("Slot"))
                {
                    if (Input.GetMouseButton(0))
                    {
                        transform.position = hit.transform.position;
                        isFollowingMouse = false;
                        foreach (GameObject g in GameManager.Instance.slots)
                        {
                            g.GetComponent<MeshRenderer>().material.color = Color.gray;
                        }
                    }
                }
            }
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



