using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothView : MonoBehaviour
{

    public float closetSize = 200f;
    public float _clothMovementDistance = 30f;
    public GameObject clothPrefab;

    private bool _isInitilized = false;
    private int _amountOfCloths = 0;
    private float[] clothsOriginalLocalPosition;
    public GameObject[] cloths;


    public void Awake()
    {
        Init(6);
    }

    public void Init(int amountOfCloths)
    {
        _isInitilized = true;
        _amountOfCloths = amountOfCloths;

        clothsOriginalLocalPosition = new float[amountOfCloths];
        cloths = new GameObject[amountOfCloths];

        for (var i = 0; i < amountOfCloths; i++)
        {
            cloths[i] = Instantiate(clothPrefab).gameObject;
            cloths[i].transform.parent = gameObject.transform;
            var distanceBetweenCloths = closetSize / amountOfCloths;
            cloths[i].transform.localPosition = new Vector3(i * distanceBetweenCloths, 0);
            clothsOriginalLocalPosition[i] = cloths[i].transform.localPosition.x;
        }
    }

    public void SetAllClothsPosition(int index)
    {
        SetAllClothsPosition((float)index / _amountOfCloths);
    }

    public void SetAllClothsPosition(float ratio)
    {

        var index = (int)Mathf.Floor(ratio * _amountOfCloths);
        var inIndexRatio = (ratio - index * (1f / _amountOfCloths)) / (1f / _amountOfCloths);

        for (var i = 0; i < _amountOfCloths; i++)
        {
            if (i == index)
            {
                cloths[i].transform.localPosition = new Vector3(clothsOriginalLocalPosition[i] - inIndexRatio * _clothMovementDistance, 0);
                continue;
            }
            if (i < index)
            {
                cloths[i].transform.localPosition = new Vector3(clothsOriginalLocalPosition[i] - 1 * _clothMovementDistance, 0);
                continue;
            }
            cloths[i].transform.localPosition = new Vector3(clothsOriginalLocalPosition[i], 0);
        }
    }

    public void OnRatioChanged(float ratio)
    {
        if (!_isInitilized)
        {
            return;
        }
        SetAllClothsPosition(ratio);
    }

}
