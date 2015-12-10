﻿using UnityEngine;
using System.Collections;

public class GameManager
{ 
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameManager();
            }

            return _instance;
        }
    }

    private bool isObjMove;
    public bool IsObjMove
    {
        get
        {
            return isObjMove;
        }
        set
        {
            isObjMove = value;
        }
    }

    private bool isCameraMove;
    public bool IsCameraMove
    {
        get
        {
            return isCameraMove;
        }
        set
        {
            isCameraMove = value;
        }
    }
        
}
