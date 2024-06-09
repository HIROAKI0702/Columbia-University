using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Strength_Security_Guard : MonoBehaviour
{
    Rigidbody2D rb;
    private GameObject player;
    PlayerController PlayerController;
    //GameObject MyEnemy;

    //�G�̓���
    public float speed = 4.0f;
    float speed_P = 2.5f;
    private int distance_traveled = 7;//�ړ�����
    private bool EMove_Stop = true;
    static public bool EMove_Stop_mark = false;
    public float Enemy_Start_Count = 3.0f;//�ŏ��̓����o�����Ԃ�ς���
    Vector2 movementx;
    Vector2 movementy;

    //�J�E���g�p
    private float countleftTime = 3.0f;   //������
    private float countrightTime = 3.0f;   //�E����
    private bool direction = false;        //true�͉E����
    private float countstoptime = 3.0f;   //������

    //player�Ƃ̋���
    public float reactionDistanceX = 10.0f;//����
    public float reactionDistanceY = 4.0f;//����
    private bool isActive = false;
    private bool Moved_Enemy = false;

    //�A�j���[�V�����p
    Animator animator; //�A�j���[�^�[
    private string stopAnime = "Enemy_Strength_Security_Guard_stand";
    private string moveAnime = "Enemy_Strength_Security_Guard_run";

    //�}�[�N�p
    public GameObject Exclamation_mark;
    public GameObject Question_mark;

    //SE�p
    AudioSource AudioSource;
    public AudioClip ExclamationAudio;
    public AudioClip QuestionAuidoname;
    private bool AudioFlag = false;

    Vector2 MyEnemy = new Vector2(0, 0);
    Vector2 MyEnemy2 = new Vector2(0, 0);

    bool isPose = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        AudioSource = GetComponent<AudioSource>();
        AudioFlag = true;
        Exclamation_mark.SetActive(false);
        Question_mark.SetActive(false);

        //Player�@�̃Q�[���I�u�W�F�N�g�𓾂�
        PlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        //�ŏ��̓����o�����Ԃ�ς���
        countleftTime = Enemy_Start_Count;

        //�������W���L��
        MyEnemy = transform.position;
        MyEnemy2 = MyEnemy;
        MyEnemy2.x = MyEnemy2.x - distance_traveled;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GState == "Pose")
        {
            animator.Play(stopAnime);    //�A�j���[�V�����Đ�
            Moved_Enemy = true;//�����ʒu�ɖ߂�
            isPose = true;
        }

        if(PlayerController.inLocker == true)
        {
            Debug.Log("���b�J�[");
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            isActive = false;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;

        }
            

        if (transform.position.x < PlayerController.transform.position.x)
        {
            Question_mark.transform.localScale = new Vector2(-0.7f, 0.7f);//������
        }
        else if (transform.position.x > PlayerController.transform.position.x)
        {
            Question_mark.transform.localScale = new Vector2(0.7f, 0.7f);//������
        }


        if (isActive)//��l��������
        {
            Exclamation_mark.SetActive(true);

            if (AudioFlag)
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

        if (EMove_Stop_mark)//��l����������
        {
            Debug.Log("������");
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
    private void FixedUpdate()
    {
        if (GameManager.GState == "Playing")
        {
            //�v���C���[�Ƃ̋��������߂�
            movementx.x = this.transform.position.x - PlayerController.transform.position.x;
            movementy.y = this.transform.position.y - PlayerController.transform.position.y;
            float distx = movementx.magnitude;
            float disty = movementy.magnitude;

            if (disty < reactionDistanceY && distx < reactionDistanceX && PlayerController.inLocker == false)
            {
              
                isActive = true; //�A�N�e�B�u�ɂ���
                Debug.Log(isActive);
                EMove_Stop_mark = false;
            }
            else
            {
                isActive = false; //��A�N�e�B�u�ɂ���

                Debug.Log("mihakken");
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
                        animator.Play(moveAnime);    //�A�j���[�V�����Đ�
                        this.transform.localScale = new Vector2(-0.6f, 0.6f);//�E����
                        transform.position = Vector3.MoveTowards(transform.position, MyEnemy, speed * Time.deltaTime);
                        
                        if (transform.position.x == MyEnemy.x)
                        {
                            animator.Play(stopAnime);    //�A�j���[�V�����Đ�
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
                        animator.Play(moveAnime);    //�A�j���[�V�����Đ�
                        this.transform.localScale = new Vector2(0.6f, 0.6f);//������
                       
                        transform.position = Vector3.MoveTowards(transform.position, MyEnemy2, speed * Time.deltaTime);

                        if (transform.position.x == MyEnemy2.x)
                        {
                            animator.Play(stopAnime);    //�A�j���[�V�����Đ�
                            countleftTime = 3.0f;
                            direction = true;
                        }
                    }
                }
            }
            else if(isActive)//��l�����߂��ɂ������̓���
            {
                animator.Play(moveAnime);    //�A�j���[�V�����Đ�
                Moved_Enemy = true;
                countleftTime = 3.0f;//�J�E���g���Z�b�g
                countrightTime = 3.0f;//�J�E���g���Z�b�g
                 // PLAYER�̈ʒu���擾
                Vector2 targetPos = PlayerController.transform.position;
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
                if (transform.position.x < PlayerController.transform.position.x)
                {
                    this.transform.localScale = new Vector2(-0.6f, 0.6f);//������
                }
                else if (transform.position.x > PlayerController.transform.position.x)
                {
                    this.transform.localScale = new Vector2(0.6f, 0.6f);//������
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
            animator.Play(stopAnime);    //�A�j���[�V�����Đ�
            if (!isPose)
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
            animator.Play(moveAnime);    //�A�j���[�V�����Đ�
            if (transform.position.x < MyEnemy.x)
            {
                this.transform.localScale = new Vector2(-0.6f, 0.6f);//������
            }
            else if (transform.position.x > MyEnemy.x)
            {
                this.transform.localScale = new Vector2(0.6f, 0.6f);//������
            }
              
            transform.position = Vector3.MoveTowards(transform.position, MyEnemy, speed * Time.deltaTime);//�����ʒu�߂�

            if (MyEnemy.x == transform.position.x)//�����ʒu�ɖ߂�����
            {
                animator.Play(stopAnime);    //�A�j���[�V�����Đ�
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
