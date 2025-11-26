using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    public void DeviceLost()
    {
        gameObject.GetComponent<Image>().enabled = false;
    }
    public void DeviceReconnected()
    {
        gameObject.GetComponent<Image>().enabled = true;
    }
}
