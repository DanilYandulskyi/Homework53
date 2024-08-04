using UnityEngine;
using DG.Tweening;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Vector3 _finalScale;
    [SerializeField] private float _duration;

    private void Update()
    {
        transform.DOScale(Vector3.one, _duration).OnComplete(() => 
        {
            transform.DOScale(_finalScale, _duration);
        });

        transform.DOScale(_finalScale, _duration).OnComplete(() =>
        {
            transform.DOScale(Vector3.one, _duration);
        });
    }
}
