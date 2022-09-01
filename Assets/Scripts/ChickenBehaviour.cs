using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehaviour : AnimalBehaviour
{
    [SerializeField] float chickenSpeed;
    [SerializeField] float chickenJumpStrenght;

    protected override void Start()
    {
        gameManager = GameManager.instance;

        JumpStrenght = chickenJumpStrenght;
        Speed = chickenSpeed;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void HandleMovement()
    {
        base.HandleMovement();
    }

    protected override void HandleJump()
    {
        base.HandleJump();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
