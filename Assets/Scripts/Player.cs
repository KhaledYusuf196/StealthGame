using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2;
    Animator _animator;
    float turnAmount;
    float forwardAmount;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(Vector3 move)
    {
        if (move.sqrMagnitude > 1f) move.Normalize();
        move = transform.InverseTransformDirection(move);
        turnAmount = Mathf.Atan2(move.x, move.z);
        Debug.Log(turnAmount);
        forwardAmount = move.z;
        transform.Rotate(Vector3.up, turnAmount * rotationSpeed * Time.deltaTime);
        if(forwardAmount > 0.5)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
    }
}
