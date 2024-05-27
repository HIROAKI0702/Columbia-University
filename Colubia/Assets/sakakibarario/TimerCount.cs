using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCount : MonoBehaviour
{
    //�b�J�E���g�_�E��
    private float countupsecond = 50;

    //���J�E���g�_�E��
    private int countupinute = 9;


    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;

    //�|�[�Y���Ă邩�ǂ���
    public static bool isPose = false;

    private void Start()
    {
       
    }

    //Uodate is called once per frame
    void Update()
    {
       
          
        //�N���b�N���ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //�|�[�Y���ɃN���b�N���ꂽ�Ƃ�
            if (isPose)
            {
                //�|�[�Y��Ԃ���������
                FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Playing);
                isPose = false;
              
            }
            //�i�s���ɃN���b�N���ꂽ�Ƃ�
            else
            {
                //�|�[�Y��Ԃɂ���
                FindObjectOfType<GameManager>().dispatch(GameManager.GameState.Pose);
                isPose = true;
            }
        }


        if (GameManager.GState != "Playing")
        {
            return;
        }
        //�|�[�Y�����ǂ���
        if (isPose)
        {
            //�|�[�Y���ł��邱�Ƃ�\��
            //timeText.text = "�|�[�Y��";
            //�J�E���g�_�E�����Ȃ�
            return;
        }

        //���Ԃ��J�E���g����
        countupsecond += Time.deltaTime;

        if (countupsecond >= 60)
        {
            countupinute++;
            countupsecond = 0.0f;
        }

        //���Ԃ�\������
        if (countupsecond < 10)
        {
            timeText.text = countupinute.ToString("00") + ":0" + countupsecond.ToString("f2");
        }
        else
        {
            timeText.text = countupinute.ToString("00") + ":" + countupsecond.ToString("f2");
        }

        
    }
}
