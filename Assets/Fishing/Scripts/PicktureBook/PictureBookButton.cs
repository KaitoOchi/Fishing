using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBookButton : MonoBehaviour
{
    int m_number = 0;   //内部番号。

    /// <summary>
    /// 押されたときに表示。
    /// </summary>
    public void OnClick()
    {
        //説明画面を表示。
        PictureBook pictureBook = FindAnyObjectByType<PictureBook>();
        pictureBook.SetExplain(m_number);
    }

    /// <summary>
    /// 図鑑画面を終了。
    /// </summary>
    public void ExitClick()
    {
        Debug.Log("Exit");
    }

    /// <summary>
    /// 番号を設定。
    /// </summary>
    public void SetNumber(int num)
    {
        m_number = num;
    }
}
