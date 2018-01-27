using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMaster : MonoBehaviour {

    public List<int> TotalItemsPerCat;

    public List<List<int>> CurrentMissionDressSet;
    public List<int> CurrentIndexSet; //the right one is at 0

    public Mission[] Missions;

    public int CurrentMission;

    //public delegate void DressChengedDel();
    public event Action EDressChanged;
    


    public void Init() {
        for (int i = 0; i < CurrentIndexSet.Count; i++) {
            EDressChanged();
        }
    }

    public void InitMission() {
        //MissionDressSet; 
        //CurrentIndexSet randomize non zero
        CurrentIndexSet = new List<int>();

        CurrentMissionDressSet = new List<List<int>>();


        for (int i = 0; i < TotalItemsPerCat.Count; i++) {
            CurrentMissionDressSet.Add(new List<int>());
            for (int j = 0; j < TotalItemsPerCat[i]; j++) {
                CurrentMissionDressSet[i].Add(j);
            }

            CurrentMissionDressSet[i].Add(Missions[CurrentMission].MissionItems[i]);

            int rInd = UnityEngine.Random.Range(0, CurrentMissionDressSet[i].Count);

            CurrentIndexSet.Add(rInd);
        }

        

        DressUp();


    }

    


    public void SetDress(bool isUp, int cat) {
        if (isUp) {
            CurrentIndexSet[cat] = (CurrentIndexSet[cat] + 1) % (CurrentMissionDressSet[cat].Count);

        } else {
            CurrentIndexSet[cat] = (CurrentIndexSet[cat] - 1 + CurrentMissionDressSet[cat].Count) % (CurrentMissionDressSet[cat].Count);

        }
        DressUp();
    }


    public void DressUp() {
        EDressChanged();
    }

    
}
