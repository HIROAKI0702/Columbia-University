using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    Rigidbody2D rb;
    
    public BoxCollider2D bx;
    public LayerMask GroundLayer;
    float axisH = 0.0f;
    public float speed = 3.0f;  //�ړ����x
    public float jump = 6.0f;   //�W�����v��

    public bool ongrond = false;             //�n�ʔ���
    bool gojump = false;                     //�W�����v����
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //���������̃`�F�b�N
        axisH = Input.GetAxisRaw("Horizontal");

        //�����̒���
        if (axisH > 0.0f)
        {
            //�E�ړ�
            // Debug.Log("�E�ړ�");
            transform.localScale = new Vector2(1, 1);
            
        }
        if (axisH < 0.0f)
        {
            //���ړ�
            //Debug.Log("���ړ�");
            transform.localScale = new Vector2(-1, 1);
           
        }
        //�L�����N�^�[�̃W�����v
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {

        //�n�㔻��
        ongrond = Physics2D.Linecast(transform.position,
                                    transform.position - (transform.up * 0.1f),
                                    GroundLayer);
        if (ongrond || axisH != 0 )
        {
            //�n��or���x���O�ł͂Ȃ�or�U�����ł͂Ȃ�
            //���x���X�V
            rb.velocity = new Vector2(axisH * speed, rb.velocity.y);
        }
        if (ongrond && gojump)
        {
            //�n�ォ�W�����v�L�[�������ꂽ�Ƃ�
            //�W�����v����
            Debug.Log("�W�����v");
            Vector2 jumpPw = new Vector2(0, jump);      //�W�����v������x�N�g��
            rb.AddForce(jumpPw, ForceMode2D.Impulse);   //�u�ԓI�ȗ͂�������
            gojump = false; //�W�����v�t���O�����낷
        }
    }
    //��l���ɓ���
    void Jump()//�W�����v
    {
        gojump = true; //�W�����v�t���O�𗧂Ă�
        Debug.Log(ongrond);
    }
}
