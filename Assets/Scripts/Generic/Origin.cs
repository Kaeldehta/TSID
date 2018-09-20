using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour
{
    [SerializeField]
    private GameObject originGameObject;
    [SerializeField]
    private string enemyTag;
    [SerializeField]
    private string originTag;
    public GameObject OriginGameObject
    {
        get
        {
            return originGameObject;
        }
        set
        {
            originGameObject = value;
            if(originGameObject.CompareTag("Entity"))
            {
                enemyTag = "Player";
                originTag = "Entity";
            }
            else if (originGameObject.CompareTag("Player"))
            {
                enemyTag = "Entity";
                originTag = "Player";
            }
        }
    }

    public string EnemyTag
    {
        get
        {
            return enemyTag;
        }
    }
    public string OriginTag
    {
        get
        {
            return originTag;
        }
    }

}
