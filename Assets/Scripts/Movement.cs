using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    
    Rigidbody rb;
    //[SerializeField] float Characterrotation = 2;

    float _translation;
    float _rotation;

    [SerializeField] bool haskey;
    Vector3 Offset;
    Player player;
    Transform CameraTransform;


    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        CameraTransform = Camera.main.transform;
        Offset = CameraTransform.position - transform.position;
    }

    void Update()
    {
        //CameraTransform.position = transform.position + Offset;
        CameraTransform.LookAt(transform.position);
        player.Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")));
        //_translation = Input.GetAxisRaw("Vertical");
        //_rotation = Input.GetAxisRaw("Horizontal");
        //if (_rotation != 0)
        //{
        //    movingRight(_rotation);
        //}
        //if (_translation <= 0)
        //{
        //    _animi.SetBool("Walk",false);
        //}
        //else
        //{
        //    _animi.SetBool("Walk", true);
        //}
        

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WinningCube"))
        {
            GameManger.Instance.Won();
        }
    }

    //private void movingRight(float _rotationVal)
    //{
    //    if (_rotationVal >0)

    //    {
    //        transform.Rotate(0, Characterrotation, 0);
    //    }
    //    else if(_rotationVal < 0)
    //        transform.Rotate(0,-Characterrotation, 0);

    //}

}

