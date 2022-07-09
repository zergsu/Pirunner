using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNextLevel : MonoBehaviour
{
    [SerializeField] GameObject twirlEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            twirlEffect.SetActive(true);
    }
}
