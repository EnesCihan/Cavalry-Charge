using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardCombat : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.LookAt(player);
    }

    public void Death()
    {
        GetComponent<Animator>().enabled = false;
        transform.GetChild(2).gameObject.SetActive(true);
    }
}
