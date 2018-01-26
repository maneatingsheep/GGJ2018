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
        for (int i = 0; i < GameplayMasterRef.CurrentIndexSet.Count; i++) {
            int item = GameplayMasterRef.CurrentMissionDressSet[i][GameplayMasterRef.CurrentIndexSet[i]];

            for (int j = 0; j < Cats[j].Containers.Count; j++) {
                Cats[j].Containers[j].FixedContainer.sprite = Cats[j].Containers[j].FixedContent;
                Cats[j].Containers[j].ChangingContainer.sprite = Cats[j].Containers[j].Contents[item];
            }
            
        }
    }
}
