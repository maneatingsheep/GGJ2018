using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetView : MonoBehaviour {

    public GameplayMaster GameplayMasterRef;

    public void Init() {
        
    }

    public void IncDress(int cat) {
        GameplayMasterRef.SetDress(true, cat);
        
    }

    public void DecDress(int cat) {
        GameplayMasterRef.SetDress(false, cat);
    }
}
