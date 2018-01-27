using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMaster : MonoBehaviour {

    public enum GameStates { Title, MissionIntro, MissionBrief, Game, Conclusion, GameOver} 

    public Canvas TitleCanvasRef;
    public Canvas MissionCanvasRef;
    public Canvas GameCanvasRef;



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
                    GameCanvasRef.gameObject.SetActive(false);
                    break;
                case GameStates.MissionIntro:
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    GameCanvasRef.gameObject.SetActive(false);

                    break;
                case GameStates.MissionBrief:
                    SoldierViewRef.PlayBrief();
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(true);
                    GameCanvasRef.gameObject.SetActive(false);

                    break;
                case GameStates.Game:
                    GameplayMasterRef.InitMission();
                    SoldierViewRef.StartGame();
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    GameCanvasRef.gameObject.SetActive(true);

                    break;
                case GameStates.Conclusion:
                    SoldierViewRef.EndGame();
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    GameCanvasRef.gameObject.SetActive(false);

                    break;
                case GameStates.GameOver:
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    GameCanvasRef.gameObject.SetActive(false);

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
        GameplayMasterRef.CurrentMission = (GameplayMasterRef.CurrentMission + 1) % GameplayMasterRef.Missions.Length;
    }

}
