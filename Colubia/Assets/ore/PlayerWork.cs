using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWork : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    //�@�v���C���[���x�Ǘ�
    public float speed = 3.0f;
    private float playerSpeed;

    private bool SwitchGravity = true;
    public float Gravity = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�@A���������獶�ɐi��
        if (Input.GetKey(KeyCode.A)) playerSpeed = -speed;
        //�@B���������獶�ɐi��
        else if (Input.GetKey(KeyCode.D)) playerSpeed = speed;
        else playerSpeed = 0;

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
        SwitchGravity = false;

        //�@�d�͂𔽓]������
        rigidbody2D.gravityScale *= -1;
        Debug.Log("a");

        StartCoroutine(PlayerRotate());
    }

    IEnumerator PlayerRotate()
    {
        yield return new WaitForSeconds(0.25f);

        //�@�v���C���[�̌�����ς���
        transform.Rotate(0, 0, 180);

        SwitchGravity = true;
    }
}
