using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

    #region Variables
    [Header("Points Settings")]
    [SerializeField] private int _pointValue = 0;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region Public Methods
    public int GetPointValue()
    {
        return _pointValue;
    }

    #endregion
}
