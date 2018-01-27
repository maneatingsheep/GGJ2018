using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierView : MonoBehaviour {

    public GameplayMaster GameplayMasterRef;

    public List<DressCategory> Cats;

    public Animator SoldierAnim;
    public Animator ClosetAnim;
    public Animator PlaneAnim;

    public void Init() {
        GameplayMasterRef.EDressChanged += DressChanged;
    }

    public void PlayBrief() {
        PlaneAnim.SetTrigger("in");
        PlaneAnim.SetTrigger("in");
    }

    public void StartGame() {
        PlaneAnim.SetTrigger("out");
        PlaneAnim.SetTrigger("out");

        Invoke("Drop", 2);
        

    }

    public void Drop() {
        SoldierAnim.SetTrigger("in");
        ClosetAnim.SetTrigger("in");
    }

    public void EndGame() {
        SoldierAnim.SetTrigger("out");
        ClosetAnim.SetTrigger("out");
    }

    private void DressChanged() {
        for (int i = 0; i < GameplayMasterRef.CurrentIndexSet.Count; i++) {
            int item = GameplayMasterRef.CurrentMissionDressSet[i][GameplayMasterRef.CurrentIndexSet[i]];

            for (int j = 0; j < Cats[i].Containers.Count; j++) {
                Cats[i].Containers[j].FixedContainer.sprite = Cats[i].Containers[j].FixedContent;
                Cats[i].Containers[j].ChangingContainer.sprite = Cats[i].Containers[j].Contents[item];
            }
            
        }
    }
}
