using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TransformDotwen : MonoBehaviour
{
    public float rotation_duration = 1.0f;
    public float move_duration = 1.0f;
    public float move_amount = 1.0f;

    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), rotation_duration, RotateMode.FastBeyond360)
                 .SetEase(Ease.Linear)
                 .SetLoops(-1, LoopType.Restart);

        transform.DOMoveY(transform.position.y + move_amount, move_duration)
                 .SetEase(Ease.InOutSine)
                 .SetLoops(-1, LoopType.Yoyo);

    }


}
