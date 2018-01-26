using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollHandler : MonoBehaviour
{

    public GameObject ScrollIndecator;
    public RectTransform ThisRectTransform;
    public ClothView ClothView;

    private float _xMinLimit;
    private float _xMaxLimit;
    private float _totalDis;

    private int _amountOfCloths = 0;
    private float _clothIndexSize;

    private bool _isInitilized = false;

    public void Awake()
    {
        _xMaxLimit = ThisRectTransform.rect.width/2;
        _xMinLimit = -_xMaxLimit;
        _totalDis = _xMaxLimit - _xMinLimit;
        Init(6);
    }

    public void Start()
    {
        SetAllClothsPosition(2);
    }
    
    public void Init(int amountOfCloths)
    {
        _amountOfCloths = amountOfCloths;
        _clothIndexSize = _totalDis / _amountOfCloths;
        _isInitilized = true;
    }


    public void SetAllClothsPosition(int index)
    {
        var ratio = (float)index / _amountOfCloths;

        var indecatorTran = ScrollIndecator.transform;
        indecatorTran.localPosition = new Vector3(_xMinLimit + ratio * _totalDis, indecatorTran.localPosition.y);

        ClothView.OnRatioChanged(ratio);
    }


    public void OnValueChanged(Vector2 position)
    {
        var indecatorTran = ScrollIndecator.transform;
        if (indecatorTran.localPosition.x > _xMaxLimit)
        {
            indecatorTran.localPosition = new Vector3(_xMaxLimit, indecatorTran.localPosition.y);
        }
        if (indecatorTran.localPosition.x < _xMinLimit)
        {
            indecatorTran.localPosition = new Vector3(_xMinLimit, indecatorTran.localPosition.y);
        }

        if (!_isInitilized)
        {
            return;
        }
        
        var ratio = 1 - (_xMaxLimit - indecatorTran.localPosition.x) / _totalDis;

        ClothView.OnRatioChanged(ratio);
    }

}
