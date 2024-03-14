using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameOnCollision : MonoBehaviour
{
    void OnCollisionEnter () {
        Application.Quit();
    }
}
