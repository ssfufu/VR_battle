using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PistolScript : MonoBehaviour
{
    [SerializeField] GameObject firepoint;
    [SerializeField] int pistolDamage = 15;
    [SerializeField] GameObject hitFxPrefab;
    [SerializeField] int bulletMax = 11;
    [SerializeField] TextMeshProUGUI bulletText;
    int currentBulletAmount;

    private void Start()
    {
        currentBulletAmount = bulletMax;
        bulletText.text = currentBulletAmount.ToString("00");
    }

    public void Tir ()
    {
        if (currentBulletAmount <= 0) 
        {
            Debug.Log("No more bullets");
            return;
        }
        currentBulletAmount--;
        bulletText.text = currentBulletAmount.ToString("00");
        hitFxPrefab.SetActive(true);
        StartCoroutine(WaitForHitFx());
        Shoot();
    }

    IEnumerator WaitForHitFx()
    {
        yield return new WaitForSeconds(0.02f);
        hitFxPrefab.SetActive(false);
    }

    public void Shoot()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(firepoint.transform.position, firepoint.transform.forward, out hitInfo);
        if (hit && hitInfo.transform.gameObject.tag == "Destructible")
        {
            hitInfo.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(firepoint.transform.forward * 10, hitInfo.point, ForceMode.Impulse);
        }

        if(hit && hitInfo.transform.gameObject.tag == "Ennemy")
        {
            Debug.Log("Hit ennemy");
            hitInfo.transform.gameObject.GetComponent<ennemyHealth>().TakeDamage(pistolDamage, hitInfo.collider.gameObject);
        }
    }

    public void Reload()
    {
        currentBulletAmount = bulletMax;
        bulletText.text = currentBulletAmount.ToString("00");
    }
}
