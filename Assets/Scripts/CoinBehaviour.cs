using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    float rotationSpeed = 120.0f;

    GameManager gameManager;

    [SerializeField] ParticleSystem collectedParticle;

    void Start()
    {
        gameManager = GameManager.instance;
    }

    void Update()
    {
        CoinRotate();
    }

    void CoinRotate()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gameManager.UpdateCoins(1);
            Instantiate(collectedParticle, transform.position, collectedParticle.transform.rotation);
            Destroy(gameObject);
        }
    }
}