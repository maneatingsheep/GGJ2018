using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMaster : MonoBehaviour {

    public enum GameStates { Title, MissionIntro, MissionBrief, Game, Conclusion, GameOver} 

    public Canvas TitleCanvasRef;
    public Canvas MissionCanvasRef;

    

    public GameplayMaster GameplayMasterRef;

    public ClosetView ClosetViewRef;
    public SoldierView SoldierViewRef;

    private GameStates _state;

    private void Start() {
        Init();
        
    }

    public void Init() {
        ClosetViewRef.Init();
        SoldierViewRef.Init();

        State = GameStates.Title;
    }

    public GameStates State
    {
        set {
            _state = value;
            switch (_state) {
                case GameStates.Title:
                    TitleCanvasRef.gameObject.SetActive(true);
                    MissionCanvasRef.gameObject.SetActive(false);
                    break;
                case GameStates.MissionIntro:
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    break;
                case GameStates.MissionBrief:
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(true);
                    break;
                case GameStates.Game:
                    GameplayMasterRef.InitMission();
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    break;
                case GameStates.Conclusion:
                    GameplayMasterRef.EndMission();
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    break;
                case GameStates.GameOver:
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    break;

            }
        }
        get {
            return _state;
                }
    }

    public void GotoMission() {
        State = GameStates.MissionBrief;
    }

    public void StartMission() {
        State = GameStates.Game;
        Invoke("EndMission", 10);
    }

    public void EndMission() {
        State = GameStates.Conclusion;
    }

}
