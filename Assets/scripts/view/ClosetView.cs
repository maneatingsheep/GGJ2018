using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetView : MonoBehaviour {

    public GameplayMaster GameplayMasterRef;

    public AudioSource switchSrc;
    public AudioClip[] SwitchSounds;


    public void Init() {
        Buttons[_clothCategory].Select();
    }

    public void IncDress() {
        GameplayMasterRef.SetDress(true, _clothCategory);
        Buttons[_clothCategory].Select();
        switchSrc.PlayOneShot(SwitchSounds[Random.Range(0, SwitchSounds.Length)]);
    }


    public void DecDress() {
        GameplayMasterRef.SetDress(false, _clothCategory);
        Buttons[_clothCategory].Select();
        switchSrc.PlayOneShot(SwitchSounds[Random.Range(0, SwitchSounds.Length)]);
    }

    public void OnClothCategoryChange(int clothCategory)
    {
        _clothCategory = clothCategory;
    }


}
