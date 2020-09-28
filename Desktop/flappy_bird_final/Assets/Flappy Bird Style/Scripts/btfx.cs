using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btfx : MonoBehaviour
{
    public AudioSource fx;
    public AudioClip hfx;
    public AudioClip cfx;


    public void hsound()
    {
        fx.PlayOneShot(hfx);
    }
    public void clickfx()
    {
        fx.PlayOneShot(hfx);
    }
}
