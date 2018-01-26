using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierView : MonoBehaviour {

    public GameplayMaster GameplayMasterRef;

    public List<DressCategory> Cats;

    public void Init() {
        GameplayMasterRef.EDressChanged += DressChanged;
    }

    private void DressChanged(int category, int from, int index) {
        throw new NotImplementedException();
    }
}
