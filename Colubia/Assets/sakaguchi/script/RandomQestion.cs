using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomQestion : MonoBehaviour
{
    static public bool BeginnerQuestionFlag = false;
    static public bool IntermediateQestionFlag = false;
    static public bool AdvancedQuestionFlag = false;
    static public bool TutorialFlag = false;

    //�`���[�g���A��
    public GameObject Tutorial;

    //����
    public GameObject BeginnerQuestion1;
    public GameObject BeginnerQuestion2;
    public GameObject BeginnerQuestion3;

    //����
    public GameObject IntermediateQuestion1;
    public GameObject IntermediateQuestion2;
    public GameObject IntermediateQuestion3;
    public GameObject IntermediateTips1;
    public GameObject IntermediateTips2;
    public GameObject IntermediateTips3;
    

    //�㋉
    public GameObject AdvancedQuestion1;
    public GameObject AdvancedQuestion2;
    public GameObject AdvancedQuestion3;
    public GameObject AdvancedTips1;
    public GameObject AdvancedTips2;
    public GameObject AdvancedTips3;


    // Start is called before the first frame update
    void Start()
    {
        //�`���[�g���A��
        Tutorial.SetActive(false);

        //����
        BeginnerQuestion1.SetActive(false);
        BeginnerQuestion2.SetActive(false);
        BeginnerQuestion3.SetActive(false);

        //����
        IntermediateQuestion1.SetActive(false);
        IntermediateQuestion2.SetActive(false);
        IntermediateQuestion3.SetActive(false);
        IntermediateTips1.SetActive(false);
        IntermediateTips2.SetActive(false);
        IntermediateTips3.SetActive(false);


        //�㋉
        AdvancedQuestion1.SetActive(false);
        AdvancedQuestion2.SetActive(false);
        AdvancedQuestion3.SetActive(false);

        RndQ();
    }

    void RndQ()
    {
        if(TutorialFlag)
        {
            int[] TutorialQ = new int[4] { 6, 9, 1, 2 };
            Tutorial.SetActive(true);
            RandomQuestion(TutorialQ);
        }

        if (BeginnerQuestionFlag)//����
        {
            int rand = Random.Range(1, 4);
            Debug.Log(rand);
            switch (rand)
            {
                case 1:
                    int[] beginner1 = new int[4] { 8, 7, 5, 3 };
                    BeginnerQuestion1.SetActive(true);
                    RandomQuestion(beginner1);
                    break;

                case 2:
                    int[] beginner2 = new int[4] { 2, 9, 8, 3 };
                    BeginnerQuestion2.SetActive(true);
                    RandomQuestion(beginner2);
                    break;

                case 3:
                    int[] beginner3 = new int[4] { 4, 8, 4, 2 };
                    BeginnerQuestion3.SetActive(true);
                    RandomQuestion(beginner3);
                    break;
            }
        }

        if (IntermediateQestionFlag)//����
        {

            int rand = Random.Range(1, 4);

            switch (rand)
            {
                case 1:
                    Debug.Log("IN");
                    int[] Intermediate1 = new int[4] { 8, 7, 4, 6 };
                    IntermediateQuestion1.SetActive(true);
                    IntermediateTips1.SetActive(true);
                    RandomQuestion(Intermediate1);
                    break;

                case 2:
                    int[] Intermediate2 = new int[4] { 1, 7, 2, 9 };
                    IntermediateQuestion2.SetActive(true);
                    IntermediateTips2.SetActive(true);
                    RandomQuestion(Intermediate2);
                    break;

                case 3:
                    int[] Intermediate3 = new int[4] { 6, 5, 7, 7 };
                    IntermediateQuestion3.SetActive(true);
                    IntermediateTips3.SetActive(true);
                    RandomQuestion(Intermediate3);
                    break;
            }
        }

        if (AdvancedQuestionFlag)//�㋉
        {
            int rand = Random.Range(1, 4);

            switch (rand)
            {
                case 1:
                    int[] Advanced1 = new int[4] { 1, 5, 7, 9 };
                    AdvancedQuestion1.SetActive(true);
                    AdvancedTips1.SetActive(true);
                    RandomQuestion(Advanced1);
                    break;

                case 2:
                    int[] Advanced2 = new int[4] { 0, 5, 0, 5 };
                    AdvancedQuestion2.SetActive(true);
                    AdvancedTips2.SetActive(true);
                    RandomQuestion(Advanced2);
                    break;

                case 3:
                    int[] Advanced3 = new int[4] { 1, 1, 8, 0 };
                    AdvancedQuestion3.SetActive(true);
                    AdvancedTips3.SetActive(true);
                    RandomQuestion(Advanced3);
                    break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }

    public void RandomQuestion(int[] Q)
    {
        //BeginnerQuestionFlag = false;
        //IntermediateQestionFlag = false;
        //AdvancedQuestionFlag = false;
        for (int i = 0; i < 4; i++)
        {
            KeyPad_Program.answer[i] = Q[i];
            Debug.Log(KeyPad_Program.answer[i]);
        }
    }
}
