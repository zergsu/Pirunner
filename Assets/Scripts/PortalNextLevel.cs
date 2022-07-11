using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNextLevel : MonoBehaviour
{
    [SerializeField] GameObject twirlEffect;

	private void Start()
	{
		twirlEffect.SetActive(false);
	}
	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            twirlEffect.SetActive(true);
    }
}
