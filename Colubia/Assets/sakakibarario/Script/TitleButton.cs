using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButton : MonoBehaviour
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
    public void OnClick()
    {
        //�I�[�f�B�I�Đ�
        AudioSource.PlayOneShot(ButtonSE, 1.5f);
        //�Q�[���̏�Ԃ�title�ɕύX
        FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Title);
    }
}
