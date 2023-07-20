using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKButton : MonoBehaviour
{
    [SerializeField, Header("ƒŠƒUƒ‹ƒg")]
    GameObject Result;

    public void ChangeActiveFlag()
    {
        Result.SetActive(false);
    }
}
