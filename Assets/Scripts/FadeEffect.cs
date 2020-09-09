using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeEffect : MonoBehaviour
{
    private GameObject _Target = null;
    private CanvasGroup _CanvasGroup = null;

    private float _Current = 0.0F;
    private float _Progress = 0.0F;

    [SerializeField]
    public bool _IsEnabled = true;

    [Header("透過度の線形")]
    [SerializeField, Range(0, 1)]
    private float _From = 0;

    [SerializeField, Range(0, 1)]
    private float _To = 1;

    [Header("実行時間")]
    [SerializeField]
    private float _Duration = 1.0F;

    [SerializeField]
    private AnimationCurve _Curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

    [Header("イベント")]
    public UnityEvent Begin;

    public UnityEvent End;


    void Start()
    {
        // _IsEnabled = true;

        _Target = gameObject;
        _CanvasGroup = _Target.GetComponent<CanvasGroup>();

        _Current = 0.0F;
        _Progress = 0.0F;

        Begin?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_IsEnabled) return; // ガード節

        if (_Progress <= 1.00F) // 進行度の割合
        {
            _Current += Time.deltaTime;
            _Progress = _Current / _Duration;

            if (_Progress >= 1.00F)
            {
                _Progress = 1.00F;
                _IsEnabled = false;

                End?.Invoke();
            }
        }

        var curvePoint = _Curve.Evaluate(_Progress);

        _CanvasGroup.alpha = curvePoint;
    }
}
