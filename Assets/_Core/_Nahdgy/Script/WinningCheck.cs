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
    private AudioSource _sourceAudio;
    [SerializeField]
    private AudioClip _LoseSong;

    public Propulsion _control;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _winningLayer)
        {
            Debug.Log("Win");
            _txt.SetActive(true);
            _obj.freezeRotation = true;
            _sourceAudio.PlayOneShot(_LoseSong);
            _control.good = true;
        }
    }

    private void Points(int _pts)
    {


    }
}
