using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("SaveObject")]
    GameObject SaveDataObject;
    [SerializeField, Header("ResourceFishList")]
    GameObject ResourceFishList;

    void Awake()
    {
        //©g‚ÍƒV[ƒ“‚ğ‚Ü‚½‚¢‚Å‚àíœ‚³‚ê‚È‚¢‚æ‚¤‚É‚·‚é
        DontDestroyOnLoad(gameObject);

        Instantiate(SaveDataObject);
        Instantiate(ResourceFishList);
    }
}
