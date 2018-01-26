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
        CurrentIndexSet = new List<int>();

        CurrentMissionDressSet = new List<List<int>>();


        for (int i = 0; i < TotalItemsPerCat.Count; i++) {
            CurrentMissionDressSet.Add(new List<int>());
            for (int j = 0; j < 4; j++) {
                CurrentMissionDressSet[i].Add(j);
            }

            int rInd = Random.Range(0, 4);

            CurrentIndexSet.Add(rInd);
        }

        

        DressUp();

    }

    public void DressUp() {
        EDressChanged(0, 0, 0);
    }


}
