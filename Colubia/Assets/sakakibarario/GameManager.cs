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
        Pose
    }
    //�t�F�[�h�p
    [SerializeField] private string sceneName;
    [SerializeField] private Color fadeColor;
    [SerializeField] private float fadeSpeed;

    // ���݂̃Q�[���i�s���
    public GameState currentState = GameState.Home;

    public static string GState = "home";//�Q�[���̏��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

                break;
            case GameState.Pose:
                GamePose();
                break;
        }

    }
    // �I�[�v�j���O����
    void GameOpening()
    {

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
        Debug.Log("playing");
    }

    // �Q�[���N���A�[����
    void GameClear()
    {
        GState = "GameClear";
        Debug.Log("GameClear");
    }

    // �Q�[���I�[�o�[����
    void GameOver()
    {
        GState = "GameOver";
        Initiate.Fade(sceneName, fadeColor, fadeSpeed);
        Debug.Log("gameover");
    }

}
