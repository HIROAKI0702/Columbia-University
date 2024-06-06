using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;

    public GameObject ClearStamp;
    public GameObject TitleButton;

    private bool ButtonFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        stage1.gameObject.SetActive(false);
        stage2.gameObject.SetActive(false);
        stage3.gameObject.SetActive(false);

        ClearStamp.gameObject.SetActive(false);
        TitleButton.gameObject.SetActive(false);
        RandomQestion.BeginnerQuestionFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�e�X�e�[�W�ɂ���ĕύX
        if (RandomQestion.BeginnerQuestionFlag == true)
        {
            stage1.gameObject.SetActive(true);
        }
        if (RandomQestion.IntermediateQestionFlag == true)
        {
            stage2.gameObject.SetActive(true);
        }
        if (RandomQestion.AdvancedQuestionFlag == true)
        {
            stage3.gameObject.SetActive(true);
        }
        //�X�^���v�\��
        Invoke("Stamp", 2.0f);
    }

    void Stamp()
    {
        //�X�^���v�\��
        ClearStamp.gameObject.SetActive(true);
        Invoke("Button", 1.0f);
        
    }
    void Button()
    {
        //�{�^���̕\��
        TitleButton.gameObject.SetActive(true);
    }
}
