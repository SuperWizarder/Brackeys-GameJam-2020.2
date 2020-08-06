using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Health : MonoBehaviour
{
    public float health;
    public float healthPerSec;

    // Update is called once per frame
    void Update()
    {
        health += healthPerSec * Time.deltaTime;
    }
}
