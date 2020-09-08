using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCaller : MonoBehaviour
{
    private GameObject _DialogPrefab;

    [SerializeField]
    private GameObject _Canvas = null;

    // Start is called before the first frame update
    void Start()
    {
        _DialogPrefab = Resources.Load("PopupDialog") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopupTest()
    {
        var instance = Instantiate<GameObject>(_DialogPrefab);

        instance.transform.SetParent(_Canvas.transform, false);
    }
}
