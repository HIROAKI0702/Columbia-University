using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] Transform playerTr; // �v���C���[��Transform��Inspector��������

    private void Update()
    {
        // �J�������v���C���[�̏ꏊ��
        transform.position = new Vector3(playerTr.position.x, playerTr.position.y, -5f);
    }
}
