using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovment : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] float speed;
    int countChildNumbers;

    int target = 0;


    void Start()
    {
        countChildNumbers = startPoint.childCount;
        transform.position = startPoint.GetChild(target).position;
    }

    // Update is called once per frame
    void Update()
    {

        if((this.transform.position - startPoint.GetChild(target).position).sqrMagnitude < .05f )
        changeGhostTarget();
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void changeGhostTarget()
    {
        
        target = (target + 1) % countChildNumbers;
        transform.forward = startPoint.GetChild(target).position-transform.position;
    }

   
}
