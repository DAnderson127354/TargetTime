using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip fire;
    public AudioClip hit;
    public AudioClip clickMain;
    public AudioClip clickThrough;
    public AudioClip clickBack;
    AudioSource source;

    void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
    }

    public void Fire()
    {
        source.PlayOneShot(fire);
    }

    public void Hit()
    {
        source.PlayOneShot(hit);
    }

    public void ClickMain()
    {
        source.PlayOneShot(clickMain);
    }

    public void ClickThrough()
    {
        source.PlayOneShot(clickThrough);
    }

    public void ClickBack()
    {
        source.PlayOneShot(clickBack);
    }
}
