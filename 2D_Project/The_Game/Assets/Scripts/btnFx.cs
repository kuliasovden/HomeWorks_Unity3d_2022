using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFx : MonoBehaviour
{
    [SerializeField]private AudioSource _myFx;
    [SerializeField]private AudioClip _hoverFx;
    [SerializeField]private AudioClip _clickFx;


    public void HoverSound()
    {
        _myFx.PlayOneShot(_hoverFx);
    }

    public void ClickSound()
    {
       
        _myFx.PlayOneShot(_clickFx);
    }
}
