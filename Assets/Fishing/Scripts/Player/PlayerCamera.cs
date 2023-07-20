using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField, Header("���x")]
    float sensitivity = 3.0f;
    [SerializeField, Header("�v���C���[")]
    PlayerMove PlayerMove;


    GameObject  m_parentObject;     //�e�I�u�W�F�N�g�B
    Quaternion  m_cameraRot;        //�J�����̉�]�B


    // Start is called before the first frame update
    void Start()
    {
        //�e�I�u�W�F�N�g���擾�B
        m_parentObject = transform.parent.gameObject;

        //�J�����̏�����]���擾�B
        m_cameraRot = m_parentObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerMove.GetCursorLock())
        {
            return;
        }

        if(!PlayerMove.GetCanMove())
        {
            return;
        }

        //�����_���v���C���[�ɍ��킹��B
        m_parentObject.transform.position = PlayerMove.transform.position;

        //�}�E�X�̓��́B
        float xRot = Input.GetAxis("Mouse X") * sensitivity;

        //�I�C���[�p���g�p���Ċp�x��ݒ�B
        m_cameraRot *= Quaternion.Euler(0, xRot, 0);

        m_parentObject.transform.localRotation = m_cameraRot;
    }
}
