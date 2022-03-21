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

    public Slot slot;

    public Material defaultMat;

    public bool isFollowingMouse;

    public int cost;

    public AudioSource audio;

    

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
                StartCoroutine(Shoot());

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
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.transform.tag.Equals("Slot"))
                    {
                        PlaceTurret(hit);
                        foreach (GameObject g in GameManager.Instance.slots)
                        {
                            g.GetComponent<MeshRenderer>().material.color = Color.gray;
                        }
                        GameManager.Instance.UpdateGold(-cost);
                        GameManager.Instance.UpdateDPS();
                    }
                    else if (hit.transform.tag.Equals("Tower"))
                    {
                        hit.transform.gameObject.GetComponent<Tower>().Merge();
                        Destroy(gameObject);

                        foreach (GameObject g in GameManager.Instance.slots)
                        {
                            g.GetComponent<MeshRenderer>().material.color = Color.gray;
                        }
                        GameManager.Instance.UpdateGold(-cost);
                        GameManager.Instance.UpdateDPS();
                    }

                    
                }
                
            }
        }
    }

	IEnumerator Shoot()
	{
        isShoot = true;
		yield return new WaitForSeconds(shootDelay);


        if (target)
        {
            GameObject b = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
            b.GetComponent<TowerBullet>().target = target;
            b.GetComponent<TowerBullet>().twr = this;
            audio.PlayOneShot(SoundManager.Instance.turretShoot);
          
        }


        isShoot = false;
	}

    public void Merge()
    {
        //Material mat = defaultMat;
        //mat.color = Color.red;
        audio.PlayOneShot(SoundManager.Instance.buildTurret);
        transform.localScale *= 1.2f;
        dmg += 3;
        foreach(MeshRenderer m in transform.GetChild(0).GetComponentsInChildren<MeshRenderer>())
        {
            m.material.color = Color.red;
        }
    }

    public void PlaceTurret(RaycastHit hit)
    {
        audio.PlayOneShot(SoundManager.Instance.buildTurret);
        transform.position = hit.transform.position;
        slot = hit.transform.gameObject.GetComponent<Slot>();
        slot.isUsed = true;
        slot.tower = this;
        transform.parent = slot.transform;
        isFollowingMouse = false;
        GetComponent<BoxCollider>().enabled = true;
        GameCanvas.Instance.UpdateTurretsTaken();
        GameManager.Instance.turretsTaken += 1;
    }
              

}



