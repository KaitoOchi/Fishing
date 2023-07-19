using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBookButton : MonoBehaviour
{
    int m_number = 0;   //�����ԍ��B

    /// <summary>
    /// �����ꂽ�Ƃ��ɕ\���B
    /// </summary>
    public void OnClick()
    {
        //������ʂ�\���B
        PictureBook pictureBook = FindAnyObjectByType<PictureBook>();
        pictureBook.SetExplain(m_number);
    }

    /// <summary>
    /// �}�Ӊ�ʂ��I���B
    /// </summary>
    public void ExitClick()
    {
        Debug.Log("Exit");
    }

    /// <summary>
    /// �ԍ���ݒ�B
    /// </summary>
    public void SetNumber(int num)
    {
        m_number = num;
    }
}
