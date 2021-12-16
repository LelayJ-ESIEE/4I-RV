using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    void Start()
    {
        spawnedHandModel = Instantiate(handModelPrefab, transform);
        handAnimator = spawnedHandModel.GetComponent<Animator>();
        // Besoin de passer par une coroutine pour décaler le chargement car certains casques s'initialisent après l'appel de Start
        StartCoroutine(SetControllerPrefab(1.0f));
    }

    IEnumerator SetControllerPrefab(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices); // Rempli devices avec tout les device qui correspondent à controllerCharacteristics
        if (devices.Count == 0) yield return new WaitForSeconds(delayTime);

        /*foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }*/

        if (devices.Count > 0)
        {
            // Prends le premier device correspondant et récupère son modèle
            targetDevice = devices[0];
            Debug.Log(targetDevice.name);
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);

            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find controller model corresponding to detected controller");
                Debug.LogWarning("Default controller model set");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
        }
    }

    void UpdateHandAnimation()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0.0f);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnedController != null)
        {
            if (showController)
            {
                spawnedHandModel.SetActive(false);
                spawnedController.SetActive(true);
            }
            else
            {
                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateHandAnimation();
            }
        }
    }
}
