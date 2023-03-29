using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Propulsion : MonoBehaviour
{
    [SerializeField]
    private float _impulsionForce = 0, _impulsionRotation, _objHeight, _rotationY, _incrementation, _forceLimit;
    [SerializeField] 
    private int _obj = 6;
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
        BarreRender();
    }

    private void GroundedCheck()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _objHeight * .5f + .2f, _whatIsGround);
    }

    private void ForcePropulsion()
    {
     if(Input.GetButton("ACTION") && _isGrounded) //touchCount > 0f
     {
         if(_impulsionForce < _forceLimit)
         {
            _impulsionForce += _incrementation * Time.deltaTime;
         }  
     }

        if (Input. GetButtonUp("ACTION") && _isGrounded) //.touchCount > 0
     { 
        _jauge.SetActive(false);
        _rb.AddForce(transform.up * _impulsionForce, ForceMode.Impulse);
        _rb.AddForce(transform.forward * _impulsionForce, ForceMode.Impulse);
     } 
    }
    private void BarreRender()
    {
        _barImage.fillAmount = (_impulsionForce/_forceLimit);
    }
    private void RotationForce()
    {
        

        if (Input.GetButtonDown("ACTION") && !_isGrounded) 
        { 
            _rotationY += _impulsionRotation;

            transform.Rotate(_rot * Time.deltaTime * _rotationY);
            Debug.Log("Rotation");
           
        }

    }
    private void Desactivate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _obj &&_isGrounded )
        {
            Debug.Log("CanStop");
            _rb.isKinematic = true;
        }
    }

}
