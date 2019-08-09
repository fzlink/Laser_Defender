using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config param
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] GameObject laser;

    private float cameraMinX;
    private float cameraMaxX;
    private float cameraMinY;
    private float cameraMaxY;

    // Start is called before the first frame update
    void Start()
    {
        SetMoveBoundaries();
    }

    private void SetMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        cameraMinX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        cameraMaxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        cameraMinY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        cameraMaxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX,cameraMinX ,cameraMaxX);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,cameraMinY , cameraMaxY);
        transform.position = new Vector2(newXPos, newYPos);

    }
}
