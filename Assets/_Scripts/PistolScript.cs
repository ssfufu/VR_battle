using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    [SerializeField] GameObject firepoint;
    [SerializeField] int pistolDamage = 15;
    [SerializeField] GameObject hitFxPrefab;


    public void Tir ()
    {
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
        if (hit)
        {
            Debug.Log("Hit");
            hitInfo.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(firepoint.transform.forward * 10, hitInfo.point, ForceMode.Impulse);
        }

        if(hit && hitInfo.transform.gameObject.tag == "Enemy")
        {
            hitInfo.transform.gameObject.GetComponent<ennemyHealth>().TakeDamage(pistolDamage, hitInfo.collider.gameObject);
        }
    }
}
