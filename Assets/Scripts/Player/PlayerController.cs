using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("Player Controls")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 100f;

    private int _playerPoints;

    //gaining access
    private Points _gamePoints;
    UIManager _uiManager;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GameObject _points = GameObject.FindWithTag("Points");
        if(_points != null )
        {
            _gamePoints = _points.GetComponent<Points>();
        }

        GameObject canvas = GameObject.FindWithTag("Canvas");
        if (canvas != null)
        {
            _uiManager = canvas.GetComponent<UIManager>();
        }

        _playerPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    #region Movement Methods
    void MovePlayer()
    {
        //Movement Input
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        //Movement direction
        Vector3 _movementDirection = (transform.forward * _vertical + transform.right * _horizontal).normalized;

        //Apply movement to player
        transform.position += _movementDirection * _moveSpeed * Time.deltaTime;
    }
    void RotatePlayer()
    {
        //Rotate player horizontally based on mouse x-axis
        float _mouseX = Input.GetAxis("Mouse X");

        //Apply rotation
        transform.Rotate(0, _mouseX * _rotationSpeed * Time.deltaTime, 0);
    }


    #endregion


    #region Game Mechanics
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Points")
        {
            _playerPoints = _playerPoints + _gamePoints.GetPointValue();
            _uiManager.AdjustScore(_playerPoints);
            Destroy(other.gameObject);
        }
    }
    #endregion

}
