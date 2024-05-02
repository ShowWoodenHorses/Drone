using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CheckDevice : MonoBehaviour
{
    public GameObject Player;
    public Camera CameraMain;
    public GameObject DeactiveForMobile;
    public GameObject MobileInputPanel;
    [Header("Arrows")] public GameObject ArrowOverEnemy;
    public GameObject ArrowsChargedsDrone;
    public GameObject ArrowsFinalPointEnemies;
    [Header("Effects")] public GameObject RandomPeople;
    public GameObject EffectSmoke;

    void Awake()
    {
        ArrowOverEnemy.SetActive(SettingManager.isHintsArrowDirectionEnemy);
        ArrowsChargedsDrone.SetActive(SettingManager.isHintsArrowChargedsDrone);
        ArrowsFinalPointEnemies.SetActive(SettingManager.isHintsArrowFinalPointEnemy);
        RandomPeople.SetActive(SettingManager.isPopulation);
        EffectSmoke.SetActive(SettingManager.isEffectSmoke);
        CameraMain.transform.GetComponent<PostProcessLayer>().enabled =
            SettingManager.isPostPocessing;
        CameraMain.transform.GetComponent<PostProcessVolume>().enabled =
            SettingManager.isPostPocessing;
        if (Application.isMobilePlatform)
        {
            //true
            Player.GetComponent<MobileControllerDrone>().enabled = true;
            MobileInputPanel.SetActive(true);

            //false
            Player.GetComponent<Rigidbody>().useGravity = false;
            Player.GetComponent<DroneMovement>().enabled = false;
            DeactiveForMobile.SetActive(false);
        }
        else
        {
            //true
            Player.GetComponent<Rigidbody>().useGravity = true;
            Player.GetComponent<DroneMovement>().enabled = true;
            DeactiveForMobile.SetActive(true);

            //false
            Player.GetComponent<MobileControllerDrone>().enabled = false;
            MobileInputPanel.SetActive(false);
        }
    }
}