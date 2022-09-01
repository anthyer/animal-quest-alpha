using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxBehaviour : AnimalBehaviour
{
    [SerializeField] float foxSpeed;
    [SerializeField] float foxJumpStrenght;

    protected override void Start()
    {
        gameManager = GameManager.instance;

        JumpStrenght = foxJumpStrenght;
        Speed = foxSpeed;
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
