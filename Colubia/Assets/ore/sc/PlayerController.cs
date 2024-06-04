using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    Vector2 position;

    LockerController lockerController;
    PaperController paperController;
    BatteryController batteryController;
    BatteryBar batteryBar;
    StunGunController stunGunController;
    enemyenemy en;
    LadderController ladderController;

    SpriteRenderer sp;
    Color spriteColor;

    public GameObject stungun;

    //�@�v���C���[�Ǘ�
    public float hideduration = 0.05f;
    public float speed = 3.0f;
    private float playerX;
    private float playerY;
    private bool Onmove = true;
    private bool isMoveLeft = false;
    private bool isMoveRight = false;
    private bool isTenjo = false;
    private bool moveup = false;
    private bool movedown = false;


    public bool isInteract = true;

    //�@���b�J�[�n
    public bool inLocker = false;

    //�@�y�[�p�[�n
    public bool isLookPaper = false;

    //  �d�͊Ǘ�
    private bool SwitchGravity = true;
    private float GravityPoint;

    //  ��]�Ǘ�
    private float PlayerAngle = 0;
    private int PlayerAngleCount = 0;

    //  �X�^���K���n
    public int Battery = 2;
    public bool onFire = false;

    //  ladder
    public bool onLadder = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //lockerController = GameObject.FindWithTag("Locker").GetComponent<LockerController>();
        //paperController = GameObject.FindWithTag("paper").GetComponent<PaperController>();
        //batteryController = GameObject.FindWithTag("Battery").GetComponent<BatteryController>();
        batteryBar = GameObject.Find("BatteryBar").GetComponent<BatteryBar>();
        //en = GameObject.FindWithTag("Enemy").GetComponent<enemyenemy>();

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
                isMoveLeft = true; isMoveRight = false;
                playerX = -speed;
            }
            //�@D����������E�ɐi��
            else if (Input.GetKey(KeyCode.D))
            {
                isMoveRight = true; isMoveLeft = false;
                playerX = speed;
            }
            else playerX = 0;
        }
        if (onLadder)
        {
            //�@S���������牺�ɐi��
            if (Input.GetKey(KeyCode.S))
            {
                movedown = true; moveup = false;
                playerY = -speed;
            }
            //�@W�����������ɐi��
            else if (Input.GetKey(KeyCode.W))
            {
                moveup = true; movedown = false;
                playerY = speed;
            }
            else playerY = 0;
        }

        //  �L�����N�^�[���i�s�����ɐi�ނ悤�ɂ���
        if (!isTenjo)
        {
            if (isMoveRight)
            {
                transform.localScale = new Vector2(-0.4f, 0.4f);
                stungun.transform.localScale = new Vector2(-0.3f, 0.7f);
            }
            if (isMoveLeft)
            {
                transform.localScale = new Vector2(0.4f, 0.4f);
                stungun.transform.localScale = new Vector2(0.3f, 0.7f);
            }
        }
        else
        {
            if (isMoveRight)
            {
                transform.localScale = new Vector2(0.4f, 0.4f);
                stungun.transform.localScale = new Vector2(-0.3f, 0.7f);
            }
            if (isMoveLeft)
            {
                transform.localScale = new Vector2(-0.4f, 0.4f);
                stungun.transform.localScale = new Vector2(0.3f, 0.7f);
            }
        }

        //�@Space����������d�͂𔽓]�����A�O���t�B�b�N�̌����𐮂���
        if (SwitchGravity && inLocker == false && isLookPaper == false && onLadder == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                GravityChange();
        }

        //�@�X�^���K��
        if (SwitchGravity && inLocker == false && isLookPaper == false && onLadder == false)
        {
            if (Input.GetMouseButton(0))
            {
                stungun.SetActive(true);
                stunGunController = GameObject.Find("stunarea").GetComponent<StunGunController>();
            }

            if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(StunGun());
            }
        }

        //  ���b�J�[�̃{�^���K�C�h���A�N�e�B�u�Ȃ�
        if (lockerController != null && lockerController.LockerF.activeSelf )
        {
            if (Input.GetKey(KeyCode.F) && isInteract == true)
            {
                isInteract = false;
                StartCoroutine(Interactive("Locker"));
            }
        }

        //�@�y�[�p�[�̃{�^���K�C�h���A�N�e�B�u�Ȃ�
        if (paperController != null && paperController.PaperF.activeSelf)
        {
            if (Input.GetKey(KeyCode.F) && isInteract == true)
            {
                isInteract = false;
                StartCoroutine(Interactive("Paper"));
            }
        }
        //  �y�[�p�[�����Ă鎞�@�����@�y�[�p�[ESC�K�C�h���L���̎�
        if (paperController != null && isLookPaper == true && paperController.PaperESC.activeSelf)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Debug.Log("iashd");
                isLookPaper = false;
                Onmove = true;
                paperController.PaperESC.SetActive(false);
                paperController.PaperLook.SetActive(false);

                isInteract = true;
            }
        }

        //�@�o�b�e���[
        if (batteryController != null && batteryController.BatteryF.activeSelf)
        {
            if (Input.GetKey(KeyCode.F) && isInteract == true && Battery < 5)
            {
                isInteract = false;
                StartCoroutine(Interactive("Battery"));
                batteryBar.UpdateBatteryBar();
            }
        }

        //  ladder
        if(ladderController != null)
        {
            if (SwitchGravity && inLocker == false && isLookPaper == false && ladderController.LadderF.activeSelf || ladderController.childLadderF.activeSelf)
            {
                if (Input.GetKey(KeyCode.F) && isInteract == true)
                {
                    isInteract = false;
                    StartCoroutine(Interactive("Ladder"));
                }
            }

            for (int i = 0; i < ladderController.childLadder.Length; i++)
            {
                if (ladderController.childLadder[i].GetComponent<LadderController>() != null)
                {
                    if (transform.position.y <= ladderController.transform.position.y - 0.4 ||
                        transform.position.y >= ladderController.childLadder[i].transform.position.y + 0.4 && onLadder)
                    {
                        if (transform.position.y >= ladderController.childLadder[i].transform.position.y + 0.4)
                            playerY = 0;    //��q�̈�ԏ�܂œo�������ɍ~���悤�ɑ�������
                        if (Input.GetKey(KeyCode.Space))
                        {
                            onLadder = false;
                            Onmove = true;
                            isInteract = true;

                            ladderController.childLadder[i].GetComponent<BoxCollider2D>().enabled = true;
                            rb2D.gravityScale = GravityPoint;
                        }
                    }
                }

            }
        }
        if(onLadder == false)
            rb2D.velocity = new Vector2(playerX, rb2D.velocity.y);
        else
            rb2D.velocity = new Vector2(playerX, playerY);
    }

    void GravityChange()
    {
        playerX = 0;//  �ړ����ɔ��]�ł��Ȃ��悤�ɂł���
        SwitchGravity = false;
        Onmove = false;
        isInteract = false;

        stungun.SetActive(false);

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
            PlayerAngle += 5.0f;

            //  ���̉�]�܂ŏ����ҋ@
            yield return new WaitForSeconds(0.000025f);
        }

        isTenjo = !isTenjo;

        //  �󒆂ŉ�]�ł��Ȃ��悤�ɏ����ҋ@
        yield return new WaitForSeconds(0.25f);
        SwitchGravity = true;
        Onmove = true; //���n��Ɉړ��ł���悤�ɂ���
        isInteract = true;
    }

    IEnumerator Interactive(string anyOBJ)
    {
        Debug.Log("F");

        if (anyOBJ == "Locker")
        {
            //  �B���
            if (inLocker == false)
            {
                inLocker = true;
                Onmove = false;      //�@��l�����~�߂�
                StartCoroutine(hideCTRL(0));    //�@��l�����\���ɂ���
                StartCoroutine(LockerActivate(true));   //�@���b�J�[���_��\������
            }
            //�@�\�ɏo��
            else
            {
                inLocker = false;
                Onmove = true;      //�@��l���𓮂���悤�ɂ���
                StartCoroutine(hideCTRL(1));    //�@��l����\������
                StartCoroutine(LockerActivate(false)); //�@���b�J�[���_����菜��
            }

            //�@���b�J�[��X���W���u��l���Ƃ͖��֌W�v�̃x�N�^�[�^�ϐ��ɕۑ�
            position = lockerController.transform.position;
            //�@�ۑ��������W���v���C���[�ɓ����
            transform.position = position;

            yield return new WaitForSeconds(4f);
            isInteract = true;
        }

        if (anyOBJ == "Paper") 
        {
            if(isLookPaper==false)
            {
                isLookPaper = true;
                Onmove = false;
                paperController.PaperLook.SetActive(true);

                yield return new WaitForSeconds(2f);
                paperController.PaperESC.SetActive(true);
            }
        }

        if (anyOBJ == "Battery")
        {
            Battery += 1;

            batteryController.objDestroy();

            yield return new WaitForSeconds(2f);
            isInteract = true;
        }

        if (anyOBJ == "Ladder") 
        {
            playerX = 0;
            onLadder = true;
            Onmove = false;

            for(int i =0; ; i++)
            {
                if (ladderController.childLadder[i].GetComponent<BoxCollider2D>() != null)
                {
                    ladderController.childLadder[i].GetComponent<BoxCollider2D>().enabled = false;
                    break;
                }
            }

            GravityPoint = rb2D.gravityScale;
            rb2D.gravityScale = 0;

            yield return new WaitForSeconds(0.25f);
            position = ladderController.transform.position;
            transform.position = position;          
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
        yield return new WaitForSeconds(0.05f);

        if (activate)
            lockerController.LockerVision.SetActive(true);
        else
            lockerController.LockerVision.SetActive(false);
    }

    IEnumerator StunGun()
    {
        if (Battery > 0) 
        {
            onFire = true;

            if (stunGunController.checkInArea && onFire)
            {
                Debug.Log("hit");
                Battery -= 1;
                batteryBar.UpdateBatteryBar();

               if( stunGunController.strong == false)
                    StunGunController.enemy_Security_Guard.enabled = false;
               else
                    StunGunController.enemy_Strength_Security_Guard.enabled=false;

                yield return new WaitForSeconds(0.5f);
                stungun.SetActive(false);
                yield return new WaitForSeconds(4.5f);

                if (stunGunController.strong == false)
                    StunGunController.enemy_Security_Guard.enabled = true;
                else
                    StunGunController.enemy_Strength_Security_Guard.enabled = true;
            }
            else if (stunGunController.checkInArea == false && onFire)
            {
                Debug.Log("miss");
                Battery -= 1;
                batteryBar.UpdateBatteryBar();
                yield return new WaitForSeconds(0.5f);
                stungun.SetActive(false);
            }

            onFire = false;
        }
        else
        {
            Debug.Log("0battery");
            yield return new WaitForSeconds(0.5f);
            stungun.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ladder")
        {
            ladderController = collision.GetComponent<LadderController>();
        }

        if(collision.gameObject.tag == "Locker")
        {
            lockerController = collision.GetComponent<LockerController>();
        }

        if(collision.gameObject.tag == "paper")
        {
            paperController = collision.GetComponent<PaperController>();
        }

        if(collision.gameObject.tag == "Battery")
        {
            batteryController = collision.GetComponent<BatteryController>();
        }
    }
}