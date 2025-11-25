using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeviceLost()
    {
        gameObject.GetComponent<Image>().enabled = false;
    }
    public void DeviceReconnected()
    {
        gameObject.GetComponent<Image>().enabled = true;
    }
}
