using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D element)
    {
        if(element.tag=="Player")
        {
            playerController.GetInstance().KillPlayer();
        }
    }
}
