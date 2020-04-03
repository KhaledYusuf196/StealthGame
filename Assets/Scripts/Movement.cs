using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
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

}

