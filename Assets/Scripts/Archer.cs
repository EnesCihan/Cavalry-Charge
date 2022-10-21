using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cavalry"))
        {
            Death();
            User›nterface.point++;
        }
    }
    public void Death()
    {
        GetComponent<Animator>().enabled = false;
        transform.GetChild(2).gameObject.SetActive(true);
    }
}
