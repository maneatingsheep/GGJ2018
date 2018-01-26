using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMaster : MonoBehaviour {


    public GameplayMaster GameplayMasterRef;

    private void Start() {
        Init();
    }

    public void Init() {

    }

    public void InitMission() {
        GameplayMasterRef.InitMission();
    }
}
