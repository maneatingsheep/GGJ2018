using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMaster : MonoBehaviour {


    public GameplayMaster GameplayMasterRef;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitMission() {
        GameplayMasterRef.InitMission();
    }
}
