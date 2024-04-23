using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerWork : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    //�@�v���C���[�ړ��Ǘ�
    public float speed = 3.0f;
    private float playerSpeed;
    private bool Onmove = true;
    private bool MoveLeft = false;
    private bool MoveRight = false;


    //  �d�͊Ǘ�
    private bool SwitchGravity = true;

    //  ��]�Ǘ�
    private float PlayerAngle = 0;
    private int PlayerAngleCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Onmove)
        {
            //�@A���������獶�ɐi��
            if (Input.GetKey(KeyCode.A)) 
            { 
                MoveLeft = true;    MoveRight = false;
                playerSpeed = -speed;    
            }

            //�@B���������獶�ɐi��
            else if (Input.GetKey(KeyCode.D))
            {
                MoveRight = true; MoveLeft = false;
                playerSpeed = speed;
            }
            else playerSpeed = 0;
        }

        if (MoveRight) transform.eulerAngles = new Vector3(0, 0,);
        if (MoveLeft) transform.eulerAngles = new Vector3(0, 180,);


        //�@Space����������d�͂𔽓]�����A�O���t�B�b�N�̌����𐮂���
        if (SwitchGravity)
        {
            if (Input.GetKey(KeyCode.Space))
                GravityChange();
        }
            

        rigidbody2D.velocity = new Vector2(playerSpeed, rigidbody2D.velocity.y);
    }

    void GravityChange()
    {
        playerSpeed = 0;//  �ړ����ɔ��]�ł��Ȃ��悤�ɂł���
        SwitchGravity = false;
        Onmove = false;

        //�@�d�͂𔽓]������
        rigidbody2D.gravityScale *= -1;

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
    }

    void FlipX()
    {
        if (this.GetComponent<SpriteRenderer>().flipX == false)
            this.GetComponent<SpriteRenderer>().flipX = true;
        else
            this.GetComponent<SpriteRenderer>().flipX = false;

    }
}