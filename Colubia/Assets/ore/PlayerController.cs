using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    Vector2 position;
    public GameObject LockerVision;

    LockerController lockerController;

    SpriteRenderer sp;
    Color spriteColor;

    //�@�v���C���[�Ǘ�
    public float hideduration = 0.005f;
    public float speed = 3.0f;
    private float playerX;
    private bool Onmove = true;
    private bool isMoveLeft = false;
    private bool isMoveRight = false;

    //�@���b�J�[�n
    public bool isInteract = true;
    public bool inLocker = false;


    //  �d�͊Ǘ�
    private bool SwitchGravity = true;

    //  ��]�Ǘ�
    private float PlayerAngle = 0;
    private int PlayerAngleCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        lockerController = GameObject.FindWithTag("Locker").GetComponent<LockerController>();
        sp = GetComponent<SpriteRenderer>();
        spriteColor = sp.color;

        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Onmove)
        {
            //�@A���������獶�ɐi��
            if (Input.GetKey(KeyCode.A)) 
            { 
                isMoveLeft = true;    isMoveRight = false;
                playerX = -speed;    
            }

            //�@B���������獶�ɐi��
            else if (Input.GetKey(KeyCode.D))
            {
                isMoveRight = true; isMoveLeft = false;
                playerX = speed;
            }
            else playerX = 0;
        }

        //  �L�����N�^�[���i�s�����ɐi�ނ悤�ɂ���
        if (isMoveRight) transform.localScale = new Vector2(-0.4f, 0.4f);
        if (isMoveLeft)  transform.localScale = new Vector2(0.4f, 0.4f);


        //�@Space����������d�͂𔽓]�����A�O���t�B�b�N�̌����𐮂���
        if (SwitchGravity)
        {
            if (Input.GetKey(KeyCode.Space))
                GravityChange();
        }

        //  ���b�J�[�̃{�^���K�C�h���A�N�e�B�u�Ȃ�
        if (lockerController.childObj.activeSelf) 
        {
            if (Input.GetKey(KeyCode.F) && isInteract == true) 
            {
                isInteract = false;
                StartCoroutine(Interactive("Locker"));

                //  �B���
                if(inLocker == false)
                {
                    inLocker = true;
                    Onmove = false;      //�@��l�����~�߂�
                    StartCoroutine(hideCTRL(0));    //�@��l�����\���ɂ���
                    StartCoroutine(LockerActivate(true));
                }
                //�@�\�ɏo��
                else
                {
                    inLocker = false;
                    Onmove = true;      //�@��l���𓮂���悤�ɂ���
                    StartCoroutine(hideCTRL(1));    //�@��l����\������
                    StartCoroutine(LockerActivate(false)); 
                }
            }
        }
        rb2D.velocity = new Vector2(playerX, rb2D.velocity.y);
    }

    void GravityChange()
    {
        playerX = 0;//  �ړ����ɔ��]�ł��Ȃ��悤�ɂł���
        SwitchGravity = false;
        Onmove = false;
        isInteract = false;

        //�@�d�͂𔽓]������
        rb2D.gravityScale *= -1;

        StartCoroutine(PlayerRotate());
    }

    IEnumerator PlayerRotate()
    {
        yield return new WaitForSeconds(0.25f);

        //  PlayerAngleCount�������������Đ�����傫���Ȃ肷���Ȃ��悤�ɂ���
        if (PlayerAngleCount >= 2) PlayerAngleCount = 0;
        //  PlayerCount�������������Đ�����傫���Ȃ肷���Ȃ��悤�ɂ���
        if (PlayerAngle >= 360) PlayerAngle = 0;


        //  ������g�p���čő�p�x��ύX�����邱�ƂŁA�V�䂩���ɓ��Œ��n���Ȃ��悤�ɂ���
        PlayerAngleCount += 1;

        //�@�v���C���[�̌������W���W���ɕς���
        for (; PlayerAngle <= 180 * PlayerAngleCount;) 
        {
            //  1���Â�]������
            transform.rotation = Quaternion.Euler(0, 0, PlayerAngle);
            PlayerAngle += 3.0f;

            //  ���̉�]�܂ŏ����ҋ@
            yield return new WaitForSeconds(0.000025f);
        }

        //  ��]��A���E���t�Ȃ̂Ŕ��]������
        FlipX();

        //  �󒆂ŉ�]�ł��Ȃ��悤�ɏ����ҋ@
        yield return new WaitForSeconds(0.25f);
        SwitchGravity = true;
        Onmove = true; //���n��Ɉړ��ł���悤�ɂ���
        isInteract = true;
    }

    void FlipX()
    {
        if (this.GetComponent<SpriteRenderer>().flipX == false)
            this.GetComponent<SpriteRenderer>().flipX = true;
        else
            this.GetComponent<SpriteRenderer>().flipX = false;

    }

    IEnumerator Interactive(string anyOBJ)
    {
        Debug.Log("F");

        if (anyOBJ == "Locker")
        {
            //�@���b�J�[��X���W���u��l���Ƃ͖��֌W�v�̃x�N�^�[�^�ϐ��ɕۑ�
            position.x = lockerController.transform.position.x;
            //�@�ۑ����Ă����W���v���C���[�ɓ����
            transform.position = position;

            yield return new WaitForSeconds(4f);
            isInteract = true;
        } 
    }

    IEnumerator hideCTRL(float targetAlpha)
    {
        Debug.Log("aaa");
        while (!Mathf.Approximately(spriteColor.a, targetAlpha))
        {
            float changePerFrame = Time.deltaTime / hideduration;
            spriteColor.a = Mathf.MoveTowards(spriteColor.a, targetAlpha, changePerFrame);
            sp.color = spriteColor;
            yield return null;
        }
    }

    IEnumerator LockerActivate(bool activate)
    {
        yield return new WaitForSeconds(0.25f);

        if (activate) 
            LockerVision.SetActive(true);
        else
            LockerVision.SetActive(false);
    }

}