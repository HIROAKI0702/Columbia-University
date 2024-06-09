using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_electric : MonoBehaviour
{
    Enemy_security_guard enemy_Guard;
  
    //�A�j���[�V�����p
    Animator animator; //�A�j���[�^�[
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //�Q�[���I�u�W�F�N�g�𓾂�
        enemy_Guard = GameObject.FindWithTag("Enemy_security_guard").GetComponent<Enemy_security_guard>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_Guard.enabled == false)
        {
            animator.Play("Enemy_electric");
        }
    }
   
}
