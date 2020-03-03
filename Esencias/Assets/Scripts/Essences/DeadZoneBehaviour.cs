﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneBehaviour : MonoBehaviour
{
  
  private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Essence")
        {

            Destroy(other.gameObject);
            
        }
    }

}
