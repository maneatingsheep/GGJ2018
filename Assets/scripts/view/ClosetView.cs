using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetView : MonoBehaviour {

    public GameplayMaster GameplayMasterRef;

    public AudioSource switchSrc;
    public AudioClip[] SwitchSounds;

    public void Init() {
        
    }

    public void IncDress(int cat) {
        GameplayMasterRef.SetDress(true, cat);
        switchSrc.PlayOneShot(SwitchSounds[Random.Range(0, SwitchSounds.Length)]);


    }

    public void DecDress(int cat) {
        GameplayMasterRef.SetDress(false, cat);
        switchSrc.PlayOneShot(SwitchSounds[Random.Range(0, SwitchSounds.Length)]);
    }
}
