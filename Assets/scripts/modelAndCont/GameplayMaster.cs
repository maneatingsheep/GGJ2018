using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMaster : MonoBehaviour {

    public List<int> TotalItemsPerCat;

    public List<List<int>> CurrentMissionDressSet;
    public List<int> CurrentIndexSet; //the right one is at 0

    public delegate void DressChengedDel(int category, int from, int index);
    public event DressChengedDel EDressChanged;

    public void Init() {
        for (int i = 0; i < CurrentIndexSet.Count; i++) {
            EDressChanged(i, -1, 0);
        }
    }

    public void InitMission() {
        //MissionDressSet; 
        //CurrentIndexSet randomize non zero
        DressUp();

    }

    public void DressUp() {

    }


}
