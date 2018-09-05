using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour
{
    [SerializeField]
    private GameObject originGameObject;
    public GameObject OriginGameObject
    {
        get
        {
            return originGameObject;
        }
        set
        {
            originGameObject = value;
        }
    }
}
