using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMaster : MonoBehaviour {

    public enum GameStates { Title, MissionIntro, MissionBrief, Game, Conclusion, GameOver} 

    public Canvas TitleCanvasRef;
    public Canvas MissionCanvasRef;
    public Canvas OverCanvasRef;



    public GameplayMaster GameplayMasterRef;

    public ClosetView ClosetViewRef;
    public SoldierView SoldierViewRef;
    public ParallaxView ParallaxViewRef;
    public TimerView TimerViewRef;

    public AudioClip MusicMenu;
    public AudioClip MusicGame;
    public AudioSource MusicPlayer;

    private GameStates _state;

    private void Start() {
        Init();
        
    }

    public void Init() {
        ClosetViewRef.Init();
        SoldierViewRef.Init();
        ParallaxViewRef.Init();
        TimerViewRef.Init();

        State = GameStates.Title;

        MusicPlayer.Stop();
        MusicPlayer.clip = MusicMenu;
        MusicPlayer.Play();
    }

    public GameStates State
    {
        set {
            _state = value;
            switch (_state) {
                case GameStates.Title:
                    ParallaxViewRef.Init();
                    SoldierViewRef.Reset();
                    TitleCanvasRef.gameObject.SetActive(true);
                    MissionCanvasRef.gameObject.SetActive(false);
                    OverCanvasRef.gameObject.SetActive(false);
                   
                    break;
                case GameStates.MissionIntro:
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    OverCanvasRef.gameObject.SetActive(false);
                    break;
                case GameStates.MissionBrief:
                    SoldierViewRef.PlayBrief();
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(true);
                    OverCanvasRef.gameObject.SetActive(false);
                    break;
                case GameStates.Game:
                    GameplayMasterRef.InitMission();
                    SoldierViewRef.StartGame();
                    TimerViewRef.Play();
                    ParallaxViewRef.Play();
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    OverCanvasRef.gameObject.SetActive(false);

                    MusicPlayer.Stop();
                    MusicPlayer.clip = MusicGame;
                    MusicPlayer.Play();

                    Invoke("EndMission", 23);
                    break;
                case GameStates.Conclusion:
                    SoldierViewRef.EndGame();
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    OverCanvasRef.gameObject.SetActive(false);

                    GameplayMasterRef.CurrentMission = (GameplayMasterRef.CurrentMission + 1) % GameplayMasterRef.Missions.Length;
                    Invoke("ConcludeMission", 4);


                    break;
                case GameStates.GameOver:
                    TitleCanvasRef.gameObject.SetActive(false);
                    MissionCanvasRef.gameObject.SetActive(false);
                    OverCanvasRef.gameObject.SetActive(true);

                    MusicPlayer.Stop();
                    MusicPlayer.clip = MusicMenu;
                    MusicPlayer.Play();

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
    }

    public void EndMission() {
        State = GameStates.Conclusion;
    }

    public void ConcludeMission() {
        State = GameStates.GameOver;
    }

    public void Restart() {
        State = GameStates.Title;
    }
}
