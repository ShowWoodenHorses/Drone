using UnityEngine;

public class CheckDevice : MonoBehaviour
{
    public GameObject Player;
    public GameObject MobileInputPanel;
    public GameObject ArrowOverEnemy;
    public GameObject RandomPeople;

    void Awake()
    {
        ArrowOverEnemy.SetActive(SettingManager.isHints);
        RandomPeople.SetActive(SettingManager.isPopulation);
        if (Application.isMobilePlatform)
        {
            //true
            Player.GetComponent<MobileControllerDrone>().enabled = true;
            MobileInputPanel.SetActive(true);

            //false
            Player.GetComponent<Rigidbody>().useGravity = false;
            Player.GetComponent<DroneMovement>().enabled = false;
        }
        else
        {
            //true
            Player.GetComponent<Rigidbody>().useGravity = true;
            Player.GetComponent<DroneMovement>().enabled = true;

            //false
            Player.GetComponent<MobileControllerDrone>().enabled = false;
            MobileInputPanel.SetActive(false);
        }
    }
}
