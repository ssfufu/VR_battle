using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    [SerializeField] GameObject firepoint;

    public void Tir ()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(firepoint.transform.position, firepoint.transform.forward, out hitInfo);
        if (hit)
        {
            hitInfo.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(firepoint.transform.forward * 10, hitInfo.point, ForceMode.Impulse);
        }
    }
}
