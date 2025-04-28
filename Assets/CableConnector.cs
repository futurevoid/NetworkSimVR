using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // ✅ ضروري للـ IEnumerator

public class CableConnector : MonoBehaviour
{
    public GameObject cablePrefab;
    public GameObject goToTCPButton;

    private Transform pointA = null;
    private Transform pointB = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (pointA == null)
                {
                    pointA = hit.transform;
                    Debug.Log("🟢 I chose the first server: " + pointA.name);
                }
                else if (pointB == null)
                {
                    pointB = hit.transform;
                    Debug.Log("🔵 I chose the second server:" + pointB.name);
                    CreateCableBetweenPoints();
                }
            }
        }
    }

    void CreateCableBetweenPoints()
    {
        GameObject cable = Instantiate(cablePrefab);
        var cableScript = cable.GetComponent<OptimizedCable>();
        cableScript.startPoint = pointA;
        cableScript.endPoint = pointB;

        pointA = null;
        pointB = null;

        StartCoroutine(SimulatePing());
    }

    IEnumerator SimulatePing()
    {
        Debug.Log("📡 Pinging...");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("✅ Ping Successful!");
        goToTCPButton.SetActive(true);
    }

    public void GoToTCPScene()
    {
        SceneManager.LoadScene("tcp_master");
    }
}

