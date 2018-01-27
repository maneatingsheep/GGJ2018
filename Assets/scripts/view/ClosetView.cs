using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetView : MonoBehaviour {

    public GameplayMaster GameplayMasterRef;

    private int _clothCategory = 0;
    public Button[] Buttons;

    public void Init() {
        Buttons[_clothCategory].Select();
    }

    public void IncDress() {
        GameplayMasterRef.SetDress(true, _clothCategory);
        Buttons[_clothCategory].Select();
    }

    public void DecDress() {
        GameplayMasterRef.SetDress(false, _clothCategory);
        Buttons[_clothCategory].Select();
    }

    public void OnClothCategoryChange(int clothCategory)
    {
        _clothCategory = clothCategory;
    }


}
