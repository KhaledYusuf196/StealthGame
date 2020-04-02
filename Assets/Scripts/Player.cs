using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2;
    Animator _animator;
    float turnAmount;
    float forwardAmount;
    [SerializeField] GameObject sound;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        sound.SetActive(false);
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
            //SoundManagerScripts.PlayerWalk("Walk");
            sound.SetActive(true);
            _animator.SetBool("Walk", true);
        }
        else
        {
            sound.SetActive(false);
            _animator.SetBool("Walk", false);
        }
    }
}
