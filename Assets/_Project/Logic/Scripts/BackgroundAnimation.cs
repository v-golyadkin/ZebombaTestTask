using DG.Tweening;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    private Transform _startTransform;

    private void Awake()
    {
        transform.DOMoveX(-15f, 10f).From(15f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
