using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierView : MonoBehaviour {

    public GameplayMaster GameplayMasterRef;

    public List<DressCategory> Cats;

    public Animator SoldierAnim;
    public Animator ClosetAnim;
    public Animator PlaneAnim;

    public SpriteRenderer ConclusionGfx;
    public GameObject ConclusionScreen;

    public Text BriefText;
    public Text PostText;

    public void Init() {
        GameplayMasterRef.EDressChanged += DressChanged;
    }

    public void PlayBrief() {
        
        BriefText.text = GameplayMasterRef.Missions[GameplayMasterRef.CurrentMission].MissionText;
        PostText.text = GameplayMasterRef.Missions[GameplayMasterRef.CurrentMission].MissionFinalText;
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

    internal void Reset() {
        ConclusionScreen.gameObject.SetActive(false);
    }

    public void EndGame() {
        SoldierAnim.SetTrigger("out");
        ClosetAnim.SetTrigger("out");

        Invoke("ShowConclusion", 4);

        ConclusionGfx.sprite = GameplayMasterRef.Missions[GameplayMasterRef.CurrentMission].MissionConcSprite;
    }

    public void ShowConclusion() {
        ConclusionScreen.gameObject.SetActive(true);

    }

    private void DressChanged() {
        for (int i = 0; i < GameplayMasterRef.CurrentIndexSet.Count; i++) {
            int item = GameplayMasterRef.CurrentMissionDressSet[i][GameplayMasterRef.CurrentIndexSet[i]];

            for (int j = 0; j < Cats[i].Containers.Count; j++) {
                Cats[i].Containers[j].FixedContainer.sprite = Cats[i].Containers[j].FixedContent;
                Cats[i].Containers[j].ConcFixedContainer.sprite = Cats[i].Containers[j].FixedContent;
                Cats[i].Containers[j].ChangingContainer.sprite = Cats[i].Containers[j].Contents[item];
                Cats[i].Containers[j].ConcChangingContainer.sprite = Cats[i].Containers[j].Contents[item];
            }
            
        }
    }
}
