using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : AnimalBehaviour
{
    [SerializeField] float dogSpeed;
    [SerializeField] float dogJumpStrenght;

    protected override void Start()
    {
        gameManager = GameManager.instance;

        JumpStrenght = dogJumpStrenght;
        Speed = dogSpeed;
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
