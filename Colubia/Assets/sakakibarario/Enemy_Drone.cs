using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Drone : MonoBehaviour
{
    Rigidbody2D rb;

    //�G�̓���
    public float speed = 7.0f;

    //�J�E���g�p
    private float countleftTime = 3.0f;   //������
    private float countrightTime = 3.0f;   //�E����
    private bool direction = false;        //true�͉E����


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void FixedUpdate()
    {
        if (GameManager.GState == "Playing")
        {
            if (direction)
            {
                countrightTime -= Time.deltaTime; //�J�E���g�A�b�v
              
                if (countrightTime < 0)
                {
                    StartCoroutine(Moveright());//�E����
                }
            }
            else
            {
                countleftTime -= Time.deltaTime;  //�J�E���g�A�b�v
                
                if (countleftTime < 0)
                {
                    StartCoroutine(Moveleft());//������
                }
            }
        }
        else
        {
            rb.Sleep();//�������~�߂�
        }

    }
    IEnumerator Moveleft()
    {
       
        this.transform.localScale = new Vector2(1, 1);//�����𒲐�
        rb.velocity = new Vector2(-speed, rb.velocity.y);//���������߂�
        yield return new WaitForSeconds(3.0f);//move time
        rb.velocity = new Vector2(0, rb.velocity.y);//�������~�߂�
        countleftTime = 3.0f;//���Z�b�g
        direction = true;
        yield break;
    }
    IEnumerator Moveright()
    {
       
        this.transform.localScale = new Vector2(-1, 1);//�����𒲐�
        rb.velocity = new Vector2(speed, rb.velocity.y);//���������߂�
        yield return new WaitForSeconds(3.0f);//move time
        rb.velocity = new Vector2(0, rb.velocity.y);//�������~�߂�
        countrightTime = 3.0f;//���Z�b�g
        direction = false;
        yield break;
    }
}