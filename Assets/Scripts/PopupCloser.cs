using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCloser : MonoBehaviour
{
    [SerializeField]
    private GameObject _PopupDialog = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseTest(float delaySecond = 0.0F)
    {
        Destroy(_PopupDialog, delaySecond);
    }
}
