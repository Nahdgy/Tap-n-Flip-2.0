using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Propulsion : MonoBehaviour
{
    [SerializeField]
    private float _impulsionForce = 0, _impulsionRotation, _objHeight, _rotationY;
    [SerializeField]
    private bool _inputPressed, _isGrounded = true;
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private LayerMask _whatIsGround;
    [SerializeField]
    private Vector3 _rot;
    [SerializeField]
    GameObject _jauge;
    [SerializeField]
    Image _barImage;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        ForcePropulsion();
        GroundedCheck();
        RotationForce();
    }

    private void GroundedCheck()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _objHeight * .5f + .2f, _whatIsGround);
    }

    private void ForcePropulsion()
    {
     if(Input.GetKey(KeyCode.Space) && _isGrounded) 
     {
            _impulsionForce += 10;
            _jauge.SetActive(true);
            _rb.AddForce(transform.up * _impulsionForce, ForceMode.Impulse);
            _rb.AddForce(transform.forward * _impulsionForce, ForceMode.Impulse);
     }
     
    }
    private void RotationForce()
    {
        

        if (Input.GetKey(KeyCode.S))// && !_isGrounded) 
        { 
            _impulsionForce -= 10;
            _rotationY = _impulsionRotation;

            transform.Rotate(_rot * Time.deltaTime * _rotationY);
            Debug.Log("Rotation");
           
        }

    }

}
