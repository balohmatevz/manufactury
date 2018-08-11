using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private bool _thresholdPassed = false;
    private Vector2 _lastMousePosition = Vector2.zero;
    private Vector2 _clickStartMousePosition = Vector2.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_thresholdPassed)
        {
            var mousePositionDifference = _lastMousePosition - mousePosition;
            var differenceX = mousePositionDifference.x;
            var currentPositionX = transform.position.x;
            var newPositionX = currentPositionX + differenceX;

            this.transform.position = new Vector3(newPositionX, 0, -10);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _clickStartMousePosition = mousePosition;
            _thresholdPassed = false;
        }

        if (Input.GetMouseButton(0))
        {
            var distanceFromStartPosition = Vector2.Distance(_clickStartMousePosition, mousePosition);
            if (distanceFromStartPosition > 0.1f)
            {
                _thresholdPassed = true;
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _thresholdPassed = false;
        }

        _lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
