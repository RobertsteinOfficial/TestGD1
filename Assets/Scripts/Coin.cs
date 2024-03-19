using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject door;
    public int score = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.GetComponent<PlayerController>().score += score;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        Debug.Log("Hello");
        Debug.Log("oasfjklsfjlasfd");
    }

}
