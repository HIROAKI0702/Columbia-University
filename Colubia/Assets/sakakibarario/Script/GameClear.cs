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

    //SE�p
    AudioSource AudioSource;
    public AudioClip ClearStampSE;
    private bool StampSEFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();

        StampSEFlag = true;
        stage1.gameObject.SetActive(false);
        stage2.gameObject.SetActive(false);
        stage3.gameObject.SetActive(false);

        ClearStamp.gameObject.SetActive(false);
        TitleButton.gameObject.SetActive(false);
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
        if (StampSEFlag)
            StartCoroutine(Stamp());
    }

    IEnumerator Stamp()
    {
        StampSEFlag = false;

        yield return new WaitForSeconds(1.0f);
        //�I�[�f�B�I�Đ�
        AudioSource.PlayOneShot(ClearStampSE, 1.0f);
        yield return new WaitForSeconds(0.2f);
        //�X�^���v�\��
        ClearStamp.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        //�{�^���̕\��
        TitleButton.gameObject.SetActive(true);
        yield break;
    }

}
