using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    GameObject player;

    //�}�[�N�p
    public GameObject Exclamation_mark;
    public GameObject Question_mark;

    //SE�p
    AudioSource AudioSource;
    public AudioClip ExclamationAudio;
    public AudioClip QuestionAuidoname;
    private bool AudioFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioFlag = true;
        Exclamation_mark.SetActive(false);
        Question_mark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Player�@�̃Q�[���I�u�W�F�N�g�𓾂�
        player = GameObject.FindGameObjectWithTag("Player");
        if (transform.position.x < player.transform.position.x)
        {
            Question_mark.transform.localScale = new Vector2(-0.7f, 0.7f);//������
        }
        else if (transform.position.x > player.transform.position.x)
        {
            Question_mark.transform.localScale = new Vector2(0.7f, 0.7f);//������
        }


        if (Enemy_Strength_Security_Guard.isActive)//��l��������
        {
            Exclamation_mark.SetActive(true);

            if(AudioFlag)
            {
                //�I�[�f�B�I�Đ�
                AudioSource.PlayOneShot(ExclamationAudio, 1.0f);
                AudioFlag = false;
            }
        }
        else
        {
            Exclamation_mark.SetActive(false);
        }

        if(Enemy_Strength_Security_Guard.EMove_Stop_mark)//��l����������
        {
             Question_mark.SetActive(true);

            if (!AudioFlag)
            {
                //�I�[�f�B�I�Đ�
                AudioSource.PlayOneShot(QuestionAuidoname, 1.0f);
                AudioFlag = true;
            }
        }
        else
        {
            Question_mark.SetActive(false);
        }
    }
}
