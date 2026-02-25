using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Binds
    [SerializeField] private KeyCode doorToggle = KeyCode.R;
    [SerializeField] private KeyCode lightToggle = KeyCode.E;

    [SerializeField] private Vector3 openPos;
    [SerializeField] private Vector3 closedPos;
    [SerializeField] private Light doorLight;
    [SerializeField] private float doorSpeed = 30f;
    
    public bool isOpen;
    public bool isLightOn { get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Door starts open
        transform.localPosition = openPos;
        isOpen = true;
        
        // Light starts off
        isLightOn = false;
        if (doorLight != null)
        {
            doorLight.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Door Movement
        if (isOpen)
        {
            // If door is open (button press), then move door to open position
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, openPos, doorSpeed * Time.deltaTime);
        }
        else
        {
            // If door is closed, then move door to closed position and turn off light
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, closedPos, doorSpeed * Time.deltaTime);
            isLightOn = false;
        }
        
        if (Input.GetKeyDown(doorToggle))
        {
            isOpen = !isOpen;
        }

        // Lights
        if (isOpen && Input.GetKey(lightToggle))
        {
            doorLight.enabled = true;
            isLightOn = true;
        }
        else
        {
            doorLight.enabled = false;
            isLightOn = false;
        }
    
    }

}
