using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _duration;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        StartCoroutine(HandleText());
    }

    private IEnumerator HandleText()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_duration);

        while (enabled)
        {
            _text.DOText("Changed", _duration).OnComplete(() =>
            {
                _text.DOText("Hacked", _duration, true, ScrambleMode.All);
            });

            _text.DOText("Added", _duration).SetRelative().OnComplete(() =>
            {
                _text.DOText("Changed", _duration);
            });            
            
            _text.DOText("Added", _duration).SetRelative().OnComplete(() =>
            {
                _text.DOText("Hacked", _duration, true, ScrambleMode.All);
            });

            yield return waitTime;
        }
    }
}