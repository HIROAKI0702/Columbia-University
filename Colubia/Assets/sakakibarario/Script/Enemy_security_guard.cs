using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_security_guard : MonoBehaviour
{
    Rigidbody2D rb;

    //�G�̓���
    public float speed = 2.5f;

    //�J�E���g�p
    private float countleftTime  = 3.0f;   //������
    private float countrightTime = 3.0f;   //�E����
    private bool direction = false;        //true�͉E����

    private bool Moved_Enemy = false;

    Vector2 MyEnemy = new Vector2(0, 0);
    Vector2 MyEnemy2 = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //�������W���L��
        MyEnemy = transform.position;
        MyEnemy2 = MyEnemy;
        MyEnemy2.x = MyEnemy2.x - 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GState == "Pose")
        {
            Moved_Enemy = true;//�����ʒu�ɖ߂�
        }

    }
    private void FixedUpdate()
    {
        if (GameManager.GState == "Playing")
        {

            if (Moved_Enemy)
            {
                if (transform.position.x < MyEnemy.x)
                {
                    this.transform.localScale = new Vector2(-1, 1);//������
                }
                else if (transform.position.x > MyEnemy.x)
                {
                    this.transform.localScale = new Vector2(1, 1);//������
                }
                transform.position = Vector3.MoveTowards(transform.position, MyEnemy, speed * Time.deltaTime);

                if (MyEnemy.x == transform.position.x)
                {
                    countrightTime = 3.0f;
                    countleftTime = 3.0f;
                    direction = false;
                    Moved_Enemy = false;

                }
            }

            if (!Moved_Enemy)
            {
                if (direction)
                {
                    countrightTime -= Time.deltaTime; //�J�E���g�A�b�v

                    if (countrightTime < 0)
                    {
                        this.transform.localScale = new Vector2(-1, 1);//�E����
                        transform.position = Vector3.MoveTowards(transform.position, MyEnemy, speed * Time.deltaTime);
                        //StartCoroutine(Moveright());
                        if (transform.position.x == MyEnemy.x)
                        {
                            Debug.Log("aaaa");
                            countrightTime = 3.0f;
                            direction = false;
                        }
                    }
                }
                else
                {
                    countleftTime -= Time.deltaTime;  //�J�E���g�A�b�v

                    if (countleftTime < 0)
                    {
                        this.transform.localScale = new Vector2(1, 1);//������
                                                                      //StartCoroutine(Moveleft());
                        transform.position = Vector3.MoveTowards(transform.position, MyEnemy2, speed * Time.deltaTime);

                        if (transform.position.x == MyEnemy2.x)
                        {
                            Debug.Log("aaaa");
                            countleftTime = 3.0f;
                            direction = true;
                        }
                    }
                }
            }
        }
        else
        {
            rb.Sleep();//�������~�߂�
        }

    }
    //IEnumerator Moveleft()
    //{
    //    this.transform.localScale = new Vector2(1, 1);//������
    //    rb.velocity = new Vector2(-speed, rb.velocity.y);//���������߂�
    //    yield return new WaitForSeconds(2.0f);
    //    direction = true;
    //    countleftTime = 3.0f;
    //    yield break;
    //}
    //IEnumerator Moveright()
    //{
    //    this.transform.localScale = new Vector2(-1, 1);//�E����
    //    rb.velocity = new Vector2(speed, rb.velocity.y);//���������߂�
    //    yield return new WaitForSeconds(2.0f);
    //    direction = false;
    //    countrightTime = 3.0f;
    //    yield break;
    //}
}
