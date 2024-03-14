using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioClip colSound;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = colSound;
    }

    // Update is called once per frame
    void OnCollisionEnter () {
        GetComponent<AudioSource> ().Play ();
    }
}
