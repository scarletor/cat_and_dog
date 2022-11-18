using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TextEff : MonoBehaviour
{




    private void Start()
    {
        transform.DOMoveY(transform.position.y + .5f, 1).OnComplete(() =>
        {
            Vector2 vec = GameAudition.ins.targetInputList.pos.transform.position;
            transform.DOJump(vec, 3, 1, 1);
            //transform.DOMove(GameAudition.ins.scoreCat.transform.position, 1);

        });
    }












}
