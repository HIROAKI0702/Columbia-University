using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�Q�[���X�e�[�g
    public enum GameState
    {
        Playing,
        Clear,
        Over,
        home
    }

    // ���݂̃Q�[���i�s���
    public GameState currentState = GameState.home;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
            case GameState.home:

                break;
        }

    }
    // �I�[�v�j���O����
    void GameOpening()
    {

    }

    // �Q�[���X�^�[�g����
    void GameStart()
    {
       
    }

    // �Q�[���N���A�[����
    void GameClear()
    {
      
    }

    // �Q�[���I�[�o�[����
    void GameOver()
    {
        Debug.Log("gameover");
    }

}
