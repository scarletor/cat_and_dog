using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class ProgressBar : MonoBehaviour
{





    public GameObject posStart, posEnd, indicator;
    public float timeToMove = 1;
    [Button]
    public void MoveIndicator()
    {
        indicator.transform.position = posStart.transform.position;
        indicator.transform.DOMove(posEnd.transform.position, timeToMove).SetEase(Ease.Linear).OnComplete(()=> {
            GameAudition.ins.OnFinishMove();
        });
    }


}
