using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMaster : MonoBehaviour {

    public MonoBehaviour ClosetController;

    public List<List<int>> MissionDressSet;
    public List<int> CurrentIndexSet; //the right one is at 0

    public void Init() {
        //ClosetController.EDressChanged += DressUp;
    }

    public void InitMission() {
        //MissionDressSet; 
        //CurrentIndexSet randomize non zero
        DressUp();

    }

    public void DressUp() {

    }


}
