using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleEffect : MonoBehaviour
{
    private GameObject _Target = null;
    private float _Current = 0.0F;
    private float _Progress = 0.0F;

    [SerializeField]
    public bool _IsEnabled = true;

    [Header("スケールの線形")]
    [SerializeField]
    private Vector3 _From = Vector3.one;

    [SerializeField]
    private Vector3 _To = Vector3.one;

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
        _Current = 0.0F;
        _Progress = 0.0F;

        Begin?.Invoke();
    }

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

        _Target.transform.localScale = Vector3.Lerp(_From, _To, curvePoint);
    }
}
