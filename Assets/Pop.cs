using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{

    Vector3 startSize;
    // Start is called before the first frame update
    void Start()
    {
        startSize = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.localScale += Vector3.one;
        this.transform.localScale = (Mathf.PingPong(Time.time/4, 0.1f) +1) * startSize;
    }
}
