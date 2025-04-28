using UnityEngine;

public class doorEffect : MonoBehaviour
{
    public Animator DoorAnimator;
    public KeyCode openKey = KeyCode.O;
    public KeyCode closeKey = KeyCode.C;
    private bool isOpen = false;

    void Update()
    {
        if (DoorAnimator == null)
        {
            Debug.LogError("DoorAnimator is not assigned!");
            return;
        }

        if (Input.GetKeyDown(openKey) && !isOpen)
        {
            Debug.Log("Door Opened");
            DoorAnimator.SetTrigger("DoorOpen");
            isOpen = true;
        }
        else if (Input.GetKeyDown(closeKey) && isOpen)
        {
            Debug.Log("Door Closed");
            DoorAnimator.SetTrigger("DoorClose");
            isOpen = false;
            Debug.Log("Door is closed");
        }
    }
}