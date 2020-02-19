using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlhe_Trigger : MonoBehaviour
{

    public GameObject setBatalha;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            setBatalha.SetActive(true);
        }
    }
}
