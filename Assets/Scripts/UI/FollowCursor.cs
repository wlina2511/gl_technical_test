using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
        }
        else
        {
            transform.localScale = new Vector3(2, 2, 2);
        }


    }
}
