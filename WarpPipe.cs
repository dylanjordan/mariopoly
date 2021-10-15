using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WarpPipe : MonoBehaviour
{
    [SerializeField] private int _posOne;
    [SerializeField] private int _posTwo;

    public WarpPipe(int posOne, int PosTwo)
    {
        _posOne = posOne;
        _posTwo = PosTwo;
    }

    public int GetPosOne()
    {
        return _posOne;
    }

    public int GetPosTwo()
    {
        return _posTwo;
    }
}
