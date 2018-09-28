using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour
{
    private bool isMapOpened = false;
    [SerializeField]
    GameObject miniMap;

    private void Start()
    {
        CloseMap();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isMapOpened)
            {
                CloseMap();
            }
            else
            {
                OpenMap();
            }
        }
    }

    private void CloseMap()
    {
        miniMap.SetActive(false);
        isMapOpened = false;
    }

    private void OpenMap()
    {
        miniMap.SetActive(true);
        isMapOpened = true;
    }
}
