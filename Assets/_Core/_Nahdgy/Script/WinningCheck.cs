using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCheck : MonoBehaviour
{
    [SerializeField]
    private int _winningLayer = 7;
    [SerializeField]
    private GameObject _txt;
    [SerializeField] 
    private Rigidbody _obj;
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private string _animName;
    [SerializeField]
    private AudioSource _sourceAudio;
    [SerializeField]
    private AudioClip _songWinning;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _winningLayer) 
        {
            _txt.SetActive(true);
            _obj.freezeRotation = true;
        }
        
    }
    private void Points(int _pts)
    {


    }
}
