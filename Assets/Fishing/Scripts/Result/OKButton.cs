using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKButton : MonoBehaviour
{
    [SerializeField, Header("���U���g")]
    GameObject Result;

    public void ChangeActiveFlag()
    {
        Result.SetActive(false);
    }
}
