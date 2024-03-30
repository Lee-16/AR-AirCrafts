using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject Rock1;
    public Vector3 movement;

 

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = gameObject.transform.position + movement;
    }
}
