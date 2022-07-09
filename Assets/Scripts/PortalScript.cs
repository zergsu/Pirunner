using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] float loadTime = 2;
    float inTime;
    bool playerIsInPortal;

    // Start is called before the first frame update
    void Start()
    {
        if (level == -1)
        {
            level = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }

    private void FixedUpdate()
    {
        if (playerIsInPortal)
        {
            inTime += Time.deltaTime;
            if (inTime > loadTime)
            {
                LoadLevel(level);
            }
        }
        else
            inTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        playerIsInPortal = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsInPortal = false;
    }

    public void LoadLevel(int id)
    {
        SceneManager.LoadScene(id);
    }

}
