using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_security_guard : MonoBehaviour
{
    Rigidbody2D rb;

    //�G�̓���
    public float speed = 2.5f;
    private int distance_traveled = 5;//�ړ�����
    public int Enemy_start_count = 0;//�ŏ��̓����o�����Ԃ�ς���

    //�J�E���g�p
    private float countleftTime  = 3.0f;   //������
    private float countrightTime = 3.0f;   //�E����
    private bool direction = false;        //true�͉E����

    private bool Moved_Enemy = false;


    //�A�j���[�V�����p
    Animator animator; //�A�j���[�^�[
    public string stopAnime = "Enemy_security_guardB_stand";
    public string moveAnime = "Enemy_security_guardB_run";
    

    Vector2 MyEnemy = new Vector2(0, 0);
    Vector2 MyEnemy2 = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Animator ���Ƃ��Ă���
        animator = GetComponent<Animator>();

     

        //�������W���L��
        MyEnemy = transform.position;
        MyEnemy2 = MyEnemy;
        MyEnemy2.x = MyEnemy2.x - distance_traveled;//�G�̉���

        countleftTime = Enemy_start_count;//�����o�����Ԃ����炷
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GState == "Pose")
        {
            animator.Play(stopAnime);    //�A�j���[�V�����Đ�
            Moved_Enemy = true;//�����ʒu�ɖ߂�
        }

    }
    private void FixedUpdate()
    {
        if (GameManager.GState == "Playing")
        {

            if (Moved_Enemy)
            {
                animator.Play(moveAnime);    //�A�j���[�V�����Đ�
                if (transform.position.x < MyEnemy.x)
                {
                    this.transform.localScale = new Vector2(-2, 2);//������
                }
                else if (transform.position.x > MyEnemy.x)
                {
                    this.transform.localScale = new Vector2(2, 2);//������
                }
                //�w����W�܂ňړ�
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
                        animator.Play(moveAnime);
                        this.transform.localScale = new Vector2(-2, 2);//�E����
                        //�w����W�܂ňړ�
                        transform.position = Vector3.MoveTowards(transform.position, MyEnemy, speed * Time.deltaTime);
                       
                        if (transform.position.x == MyEnemy.x)
                        {
                            animator.Play(stopAnime);
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
                        animator.Play(moveAnime);
                        this.transform.localScale = new Vector2(2, 2);//������
                        //�w����W�܂ňړ�                                             
                        transform.position = Vector3.MoveTowards(transform.position, MyEnemy2, speed * Time.deltaTime);

                        if (transform.position.x == MyEnemy2.x)
                        {
                            animator.Play(stopAnime);
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
            animator.Play(stopAnime);    //�A�j���[�V�����Đ�
            rb.Sleep();//�������~�߂�
        }

    }
  

}
