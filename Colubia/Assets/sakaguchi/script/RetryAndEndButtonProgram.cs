using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryAndEndButtonProgram : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickEnd()
    {
        //�Q�[���̏�Ԃ�home�ɕύX
        FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Title);
    }

    public void OnClickRetry()
    {
        //�Q�[���̏�Ԃ�playing�ɕύX
        FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Playing);
    }
}
