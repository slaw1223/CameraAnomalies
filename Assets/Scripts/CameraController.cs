using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private List<Transform> availableLocations = new List<Transform>();
    [SerializeField] private AudioSource cameraChangeAudioSource;
    public int currentLocationIndex = -1;
    private float cooldown = 0;
    void Start()
    {
        NextCamera();
    }

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

    }

    public void NextCamera()
    {
        if (cooldown > 0)
        {
            return;
        }
        currentLocationIndex++;
        if (currentLocationIndex >= availableLocations.Count)
        {
            currentLocationIndex = 0;
        }
        SetCamera();
    }

    public void PrevCamera()
    {
        if(cooldown > 0)
        {
            return;
        }
        currentLocationIndex--;
        if (currentLocationIndex < 0)
        {
            currentLocationIndex = availableLocations.Count - 1;
        }
        SetCamera();
    }

    public void SetCamera()
    {
        cooldown = 0.5f;
        cameraChangeAudioSource.Play();
        mainCamera.transform.position = availableLocations[currentLocationIndex].position;
        mainCamera.transform.rotation = availableLocations[currentLocationIndex].rotation;
    }
}
