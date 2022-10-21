using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class sideCavalryMove : MonoBehaviour
{   [SerializeField]



    private void Start()
    {
        MoveForward();
    }
    //7.86f
    void MoveForward()
    {
        transform.DOMoveX(3.93f, 3).SetEase(Ease.Linear).OnComplete(() =>
        {
            turn();
            MoveBack();
        });
    }
    void MoveBack()
    {
        transform.DOMoveX(-3.93f, 3).SetEase(Ease.Linear).OnComplete(() =>
        {
            turn();
            MoveForward();
        });
    }
    void turn()
    {
        transform.Rotate(0, 180, 0);
    }

    public void Durdur()
    {
        transform.DOKill();
    }
}
