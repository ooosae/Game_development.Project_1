using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Flowers>() != null || other.gameObject.GetComponent<Dogs>() != null)
        {
            Destroy(gameObject);
            return;
        }
        
        if (other.gameObject.name != "Cat")
        {
            return;
        }

        GameManager.inst.IncrementScore();

        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
