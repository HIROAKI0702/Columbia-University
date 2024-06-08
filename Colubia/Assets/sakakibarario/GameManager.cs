using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�Q�[���X�e�[�g
    public enum GameState
    {
        Playing,
        Clear,
        Over,
        Home,
        Pose,
        Title,
        Safe
    }
    //�t�F�[�h�p
    public string sceneNameO;
    public string sceneNameC;
    public string sceneName1;
    public string sceneName2;
    public string sceneName3;
    public string sceneNameS;
    public string sceneNameH;
    public string sceneNameT;

    public Color loadToColor = Color.white;
    public float fadeSpeed;

    // ���݂̃Q�[���i�s���
    GameState currentState = GameState.Home;

    public static string GState = "home";//�Q�[���̏��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            dispatch(GameState.Playing);
    }

    // ��Ԃɂ��U�蕪������
    public void dispatch(GameState state)
    {
        currentState = state;
        switch (state)
        {
            case GameState.Playing:
                GameStart();
                break;
            case GameState.Clear:
                GameClear();
                break;
            case GameState.Over:
                GameOver();
                break;
            case GameState.Home:
                GameHome();
                break;
            case GameState.Pose:
                GamePose();
                break;
            case GameState.Title:
                GameTitle();
                break;
            case GameState.Safe:
                GameSafe();
                break;
        }

    }
    void GameTitle()
    {
        Debug.Log("Title");
        Initiate.Fade(sceneNameT, loadToColor, fadeSpeed);
    }
    // �I�[�v�j���O����
    void GameHome()
    {
        Debug.Log("home");
        Initiate.Fade(sceneNameH, loadToColor, fadeSpeed);
    }

    //�|�[�Y����
    void GamePose()
    {
        GState = "Pose";
    }

    // �Q�[���X�^�[�g����
    void GameStart()
    {
        GState = "Playing";
        if (RandomQestion.BeginnerQuestionFlag == true)
        {
            Debug.Log("Beginner");
            Initiate.Fade(sceneName1, loadToColor, fadeSpeed);
        }
        if (RandomQestion.IntermediateQestionFlag == true)
        {
            Debug.Log("Intermediate");
            Initiate.Fade(sceneName2, loadToColor, fadeSpeed);
        }
        if (RandomQestion.AdvancedQuestionFlag == true)
        {
            Debug.Log("Advabced");
            Initiate.Fade(sceneName3, loadToColor, fadeSpeed);
        }

        Debug.Log("playing");
    }

    //���ɏ���
    void GameSafe()
    {
        GState = "GameSafe";
        Initiate.Fade(sceneNameS, loadToColor, fadeSpeed);
        Debug.Log("GameSafe");
    }

    // �Q�[���N���A�[����
    void GameClear()
    {
        GState = "GameClear";
        //SceneManager.LoadScene(sceneNameC);
        Initiate.Fade(sceneNameC, loadToColor, fadeSpeed);
        Debug.Log("GameClear");
    }

    // �Q�[���I�[�o�[����
    void GameOver()
    {
        GState = "GameOver";
        Initiate.Fade(sceneNameO, loadToColor, fadeSpeed);
        
        Debug.Log("gameover");
    }

}
