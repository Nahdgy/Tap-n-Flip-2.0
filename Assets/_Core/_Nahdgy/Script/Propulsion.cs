using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Propulsion : MonoBehaviour
{
    [SerializeField]
    private float _impulsionForce = 0, _impulsionRotation, _objHeight, _rotationY, _incrementation, _forceLimit;
    [SerializeField] 
    private int _zone = 7;
    [SerializeField]
    private bool _inputPressed, _isGrounded = true, _canGo = true; 
    public bool good = false;
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
    [SerializeField]
    GameObject _gameOver;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _audioClip;

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
     if(Input.GetButton("ACTION") && _isGrounded && _canGo) //touchCount > 0f
     {
         if(_impulsionForce < _forceLimit)
         {
            _impulsionForce += _incrementation * Time.deltaTime;
         }  
     }

        if (Input. GetButtonUp("ACTION") && _isGrounded && _canGo) //.touchCount > 0
     { 
        _jauge.SetActive(false);
        _rb.AddForce(transform.up * _impulsionForce, ForceMode.Impulse);
        _rb.AddForce(transform.forward! * _impulsionForce, ForceMode.Impulse);
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
            //_rotationY += _impulsionRotation;
            _rotationY = Mathf.Lerp(_rotationY, _impulsionRotation,Time.deltaTime);

            transform.Rotate(_rot * _rotationY);
            Debug.Log("Rotation");
        }
    }
    private void Desactivate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.layer == _zone && good == false )
        {
            Debug.Log("CanStop");
            _rb.isKinematic = true;
            _canGo = false;
            _gameOver.SetActive(true);
            _audioSource.PlayOneShot(_audioClip);
        }
    }

}
