using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBookButton : MonoBehaviour
{
    bool    m_isDiscover = false;   //未発見かどうか。
    int     m_number = 0;           //内部番号。

    /// <summary>
    /// 押されたときに表示。
    /// </summary>
    public void OnClick()
    {
        if(m_isDiscover == false)
        {
            //説明画面を表示。
            PictureBook pictureBook = FindAnyObjectByType<PictureBook>();
            pictureBook.SetExplain(m_number);
        }
    }

    /// <summary>
    /// 未発見状態にする。
    /// </summary>
    public void SetDiscover()
    {
        m_isDiscover = true;
    }

    /// <summary>
    /// 番号を設定。
    /// </summary>
    public void SetNumber(int num)
    {
        m_number = num;
    }
}
