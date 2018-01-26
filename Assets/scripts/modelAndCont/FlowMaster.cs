using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMaster : MonoBehaviour {

    public GameplayMaster GameplayMasterRef;

    public ClosetView ClosetViewRef;
    public SoldierView SoldierViewRef;
    


    private void Start() {
        Init();
    }

    public void Init() {
        ClosetViewRef.Init();
        SoldierViewRef.Init();
    }

    public void InitMission() {
        GameplayMasterRef.InitMission();
    }
}
