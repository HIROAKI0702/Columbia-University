using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomeButton : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //�Q�[���̏�Ԃ�home�ɕύX
        FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Home);
        audioSource.PlayOneShot(audioSource.clip);
    }
}
