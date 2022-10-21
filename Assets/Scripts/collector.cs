using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class collector : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> _cavalrys = new List<GameObject>();
    public Canvas canvas;

    void Start()
    {
        _cavalrys.Add(this.transform.parent.GetChild(0).gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<sideCavalryMove>())
        {
            Collect(other.gameObject);
        }
        if (other.GetComponent<guardCombat>())
        {
            other.gameObject.GetComponent<guardCombat>().Death();
            LostCavalry();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("ChargePoint"))
        {
            GetReadyCharge();
            SoundOpen(other.gameObject);
        }
    }


    void Collect(GameObject cavalry)
    {
        cavalry.transform.SetParent(this.transform.parent);
        cavalry.GetComponent<BoxCollider>().enabled = false;
        cavalry.GetComponent<BoxCollider>().isTrigger = false;
        cavalry.GetComponent<sideCavalryMove>().Durdur();
        cavalry.transform.localPosition = new Vector3(0f, 0f, _cavalrys[_cavalrys.Count - 1].transform.localPosition.z - 2.5f);
        cavalry.transform.rotation = Quaternion.Euler(0, 0, 0);
        cavalry.GetComponent<Animator>().SetTrigger("isCollect");
        _cavalrys.Add(cavalry.gameObject);
    }

    void LostCavalry()
    {
        _cavalrys[0].GetComponent<Animator>().SetTrigger("isDead");
        _cavalrys[0].transform.parent = null;
        _cavalrys.RemoveAt(0);
        for (int i = 0; i < _cavalrys.Count; i++)
        {
            _cavalrys[i].transform.DOLocalMoveZ(_cavalrys[i].transform.localPosition.z+2.5f,1);
        }
        if (_cavalrys.Count == 0)
        {
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            canvas.transform.GetChild(2).gameObject.SetActive(true);
            canvas.transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    void GetReadyCharge()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponentInParent<playerMove>().enabled = false;
        _cavalrys[0].GetComponent<Animator>().SetTrigger("isReady");
        _cavalrys[0].GetComponent<BoxCollider>().enabled = true;
        canvas.gameObject.SetActive(true);
        if (_cavalrys.Count == 1)
        {
            
        }
        else if(_cavalrys.Count == 2)
        {
            _cavalrys[0].transform.localPosition = new Vector3(_cavalrys[0].transform.localPosition.x + 0.75f, 0f, 0f);
        }
        else if (_cavalrys.Count == 3)
        {
            _cavalrys[0].transform.localPosition = new Vector3(_cavalrys[0].transform.localPosition.x + 1.5f, 0f, 0f);
        }
        else
        {
            _cavalrys[0].transform.localPosition = new Vector3(_cavalrys[0].transform.localPosition.x + 2.25f, 0f, 0f);
        }


        for (int i = 1; i < _cavalrys.Count; i++)
        {
            if (i % 4 == 0)
            {
                _cavalrys[i].transform.localPosition = new Vector3(_cavalrys[i - 4].transform.localPosition.x, 0f, _cavalrys[i - 4].transform.localPosition.z - 2.5f);
            }
            else
            {
                _cavalrys[i].transform.localPosition = new Vector3(_cavalrys[i - 1].transform.localPosition.x - 1.5f, 0f, _cavalrys[i - 1].transform.localPosition.z);
            }
            _cavalrys[i].GetComponent<BoxCollider>().enabled = true;
            _cavalrys[i].GetComponent<Animator>().SetTrigger("isReady");
        }

        StartCoroutine(Charge());
    }

    IEnumerator Charge()
    {
        yield return new WaitForSeconds(4);
        GetComponentInParent<playerMove>().enabled = true;

        for (int i = 0; i < _cavalrys.Count; i++)
        {
            _cavalrys[i].GetComponent<Animator>().SetTrigger("isCharge");
        }
    }

    private void SoundOpen(GameObject Sound)
    {
        Sound.GetComponent<AudioSource>().enabled = true;
    }
}
