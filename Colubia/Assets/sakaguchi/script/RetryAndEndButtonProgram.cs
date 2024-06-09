using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryAndEndButtonProgram : MonoBehaviour
{
    //SE�p
    AudioSource AudioSource;
    public AudioClip ButtonSE;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickEnd()
    {
        //�I�[�f�B�I�Đ�
        AudioSource.PlayOneShot(ButtonSE, 1.5f);
        //�Q�[���̏�Ԃ�home�ɕύX
        FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Title);
    }

    public void OnClickRetry()
    {
        //�I�[�f�B�I�Đ�
        AudioSource.PlayOneShot(ButtonSE, 1.5f);
        //�Q�[���̏�Ԃ�playing�ɕύX
        FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Playing);
    }
}
