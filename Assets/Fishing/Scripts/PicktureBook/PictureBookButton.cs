using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBookButton : MonoBehaviour
{
    bool    m_isDiscover = false;   //���������ǂ����B
    int     m_number = 0;           //�����ԍ��B

    /// <summary>
    /// �����ꂽ�Ƃ��ɕ\���B
    /// </summary>
    public void OnClick()
    {
        if(m_isDiscover == false)
        {
            //������ʂ�\���B
            PictureBook pictureBook = FindAnyObjectByType<PictureBook>();
            pictureBook.SetExplain(m_number);
        }
    }

    /// <summary>
    /// ��������Ԃɂ���B
    /// </summary>
    public void SetDiscover()
    {
        m_isDiscover = true;
    }

    /// <summary>
    /// �ԍ���ݒ�B
    /// </summary>
    public void SetNumber(int num)
    {
        m_number = num;
    }
}
