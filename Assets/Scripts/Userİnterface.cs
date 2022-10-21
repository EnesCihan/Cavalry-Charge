using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class User›nterface : MonoBehaviour
{
    private int counter = 3;
    public static int point = 0;

    private void Update()
    {
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Score:" + point.ToString();
    }
    private void OnEnable()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = counter.ToString();
        StartCoroutine(Counter());
    }

    
    
    IEnumerator Counter()
    {
        while (counter > 0)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = counter.ToString();
            yield return new WaitForSeconds(1f);
            counter--;
            if (counter == 0)
            {
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Charge!";
            }
        }
        yield return new WaitForSeconds(1f);
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = null;
    }
}
