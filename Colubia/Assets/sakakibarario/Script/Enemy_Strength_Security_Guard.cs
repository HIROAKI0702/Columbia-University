using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Strength_Security_Guard : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    //GameObject MyEnemy;

    //�G�̓���
    public float speed = 4.0f;
    float speed_P = 1.0f;
    private int distance_traveled = 7;//�ړ�����
    private bool EMove_Stop = true;
    static public bool EMove_Stop_mark = false;

    //�J�E���g�p
    private float countleftTime = 3.0f;   //������
    private float countrightTime = 3.0f;   //�E����
    private bool direction = false;        //true�͉E����
    private float countstoptime = 3.0f;   //������

    //player�Ƃ̋���
    public float reactionDistance = 10.0f;//����
    static public bool isActive = false;
    private bool Moved_Enemy = false;

    Vector2 MyEnemy = new Vector2(0, 0);
    Vector2 MyEnemy2 = new Vector2(0, 0);

    bool isPose = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //�������W���L��
        MyEnemy = transform.position;
        MyEnemy2 = MyEnemy;
        MyEnemy2.x = MyEnemy2.x - distance_traveled;
    }

    // Update is called once per frame
    void Update()
    {
        //Player�@�̃Q�[���I�u�W�F�N�g�𓾂�
         player = GameObject.FindGameObjectWithTag("Player");
        if(GameManager.GState == "Pose")
        {
            Moved_Enemy = true;//�����ʒu�ɖ߂�
            isPose = true;
        }

    }
    private void FixedUpdate()
    {
        if (GameManager.GState == "Playing")
        {
            //�v���C���[�Ƃ̋��������߂�
            float dist = Vector2.Distance(transform.position, player.transform.position);
            if (dist < reactionDistance)
            {
                isActive = true; //�A�N�e�B�u�ɂ���
                EMove_Stop_mark = false;
            }
            else
            {
                isActive = false; //��A�N�e�B�u�ɂ���
               
                if (Moved_Enemy)
                {
                  
                    MoveBack();
                }
               
            }

            if (!isActive && !Moved_Enemy)//��l���Ɨ���Ă���Ƃ�
            {
                if (direction)
                {
                    countrightTime -= Time.deltaTime; //�J�E���g�A�b�v

                    if (countrightTime < 0)
                    {
                        this.transform.localScale = new Vector2(-1.5f, 1.5f);//�E����
                        transform.position = Vector3.MoveTowards(transform.position, MyEnemy, speed * Time.deltaTime);
                        
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
                        this.transform.localScale = new Vector2(1.5f, 1.5f);//������
                       
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
            else if(isActive)//��l�����߂��ɂ������̓���
            {
               
                Moved_Enemy = true;
                countleftTime = 3.0f;//�J�E���g���Z�b�g
                countrightTime = 3.0f;//�J�E���g���Z�b�g
                 // PLAYER�̈ʒu���擾
                Vector2 targetPos = player.transform.position;
                // PLAYER��x���W
                float x = targetPos.x;
                // ENEMY�́A�n�ʂ��ړ�������̂ō��W�͏��0�Ƃ���
                float y = 0;
                // �ړ����v�Z�����邽�߂̂Q�����̃x�N�g�������
                Vector2 direction = new Vector2(
                    x - transform.position.x, y).normalized;
                // ENEMY��Rigidbody2D�Ɉړ����x���w�肷��
                rb.velocity = direction * speed_P;
                //���]
                if (transform.position.x < player.transform.position.x)
                {
                    this.transform.localScale = new Vector2(-1.5f, 1.5f);//������
                }
                else if (transform.position.x > player.transform.position.x)
                {
                    this.transform.localScale = new Vector2(1.5f, 1.5f);//������
                }
            }
        }
        else
        {
            rb.Sleep();//�������~�߂�
        }

    }
    void MoveBack()
    { 
        if(EMove_Stop)//�ꎞ��~
        {
            if(!isPose)
            EMove_Stop_mark = true;
            countstoptime -= Time.deltaTime;

            if(countstoptime < 0)
            {
                countstoptime = 3.0f;
                EMove_Stop_mark = false;
                EMove_Stop = false;
            }
        }
        if (!EMove_Stop)
        {
            if (transform.position.x < MyEnemy.x)
            {
                this.transform.localScale = new Vector2(-1.5f, 1.5f);//������
            }
            else if (transform.position.x > MyEnemy.x)
            {
                this.transform.localScale = new Vector2(1.5f, 1.5f);//������
            }

            transform.position = Vector3.MoveTowards(transform.position, MyEnemy, speed * Time.deltaTime);//�����ʒu�߂�

            if (MyEnemy.x == transform.position.x)//�����ʒu�ɖ߂�����
            {
                countrightTime = 3.0f;
                countleftTime = 3.0f;
                isPose = false;//�|�[�Y�t���O
                EMove_Stop = true;
                direction = false;//�����̌����ɖ߂�
                Moved_Enemy = false;//�ŏ��̓����ɖ߂�
            }
        }
    }
}