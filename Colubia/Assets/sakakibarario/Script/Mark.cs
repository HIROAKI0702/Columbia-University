using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    GameObject player;

    public GameObject Exclamation_mark;
    public GameObject Question_mark;

    // Start is called before the first frame update
    void Start()
    {
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
            Question_mark.transform.localScale = new Vector2(-1, 1);//������
        }
        else if (transform.position.x > player.transform.position.x)
        {
            Question_mark.transform.localScale = new Vector2(1, 1);//������
        }


        if (Enemy_Strength_Security_Guard.isActive)
        {
            //EM = true;
            Exclamation_mark.SetActive(true);
            Debug.Log("�h���}�[�N");
        }
        else
        {
            Exclamation_mark.SetActive(false);
        }
        if(Enemy_Strength_Security_Guard.EMove_Stop_mark)
        {
             Question_mark.SetActive(true);
            
        }
        else
        {
            Question_mark.SetActive(false);
        }
    }
    private void FixedUpdate()
    {

        


    }
}
