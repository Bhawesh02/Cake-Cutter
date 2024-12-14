using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 6;
    [FormerlySerializedAs("frosteddSpeed")] [FormerlySerializedAs("creamedSpeed")] [SerializeField] private float frostedSpeed = 3;
    [SerializeField] private float rotationSpeed = 30;
    [SerializeField] private float bladeRotationSpeed = 30;
    [SerializeField] private Transform model;
    private Vector2 movementInput;
    private bool isCreamed = false;
    private bool isFrosted = false;
    
    private float GetSpeed() => isFrosted ? frostedSpeed : speed;

    private void Awake()
    {
        GameplayEvent.OnCreamCollision += HandleOnCreamCollision;
        GameplayEvent.OnFrostCollision += HandleOnFrostCollision;
    }

    private void OnDestroy()
    {
        GameplayEvent.OnCreamCollision -= HandleOnCreamCollision;
        GameplayEvent.OnFrostCollision -= HandleOnFrostCollision;
    }

    private void HandleOnCreamCollision()
    {
        isCreamed = true;
        StartCoroutine(CoroutineUtils.Delay(4f, () =>
        {
            isCreamed = false;
        }));
    }
    
    private void HandleOnFrostCollision()
    {
        isFrosted = true;
        StartCoroutine(CoroutineUtils.Delay(4f, () =>
        {
            isFrosted = false;
        }));
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleInput();
        Move();
    }

    private void HandleInput()
    {
        movementInput.y = Input.GetAxisRaw("Vertical");
        movementInput.x = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        if(movementInput.y != 0)
        {
            transform.position += movementInput.y * GetSpeed() * Time.deltaTime * model.transform.forward;
        }

        if(!isCreamed && movementInput.x != 0)
        {
            model.transform.rotation = Quaternion.Euler(model.transform.rotation.eulerAngles + new Vector3(0, movementInput.x * rotationSpeed * Time.deltaTime, 0));
        }
    }
}
