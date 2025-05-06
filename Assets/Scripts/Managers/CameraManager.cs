using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    [Header("Cameras")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera zoomCamera;

    private Vector3 startPositionMainCamera;
    private Vector3 startPositionZoomCamera;

    private bool isMoving = false;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        mainCamera.gameObject.SetActive(true);
        zoomCamera.gameObject.SetActive(false);

        startPositionMainCamera = mainCamera.transform.position;
        startPositionZoomCamera = zoomCamera.transform.position;

        isMoving = false;
    }

    internal void ZoomInCamera()
    {
        if (isMoving) return;

        mainCamera.transform.position = startPositionMainCamera;

        StartCoroutine(ZoomIn(startPositionMainCamera));
    }

    private IEnumerator ZoomIn(Vector3 startPosition)
    {
        isMoving = true;
        float duration = 1f;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            mainCamera.transform.position = Vector3.Lerp(startPosition, zoomCamera.transform.position, t);
            yield return null;
        }

        mainCamera.transform.position = startPositionMainCamera;
        mainCamera.gameObject.SetActive(false);
        zoomCamera.gameObject.SetActive(true);
        isMoving = false;
    }

    internal void ZoomOutCamera()
    {
        if (isMoving) return;

        zoomCamera.transform.position = startPositionZoomCamera;

        StartCoroutine(ZoomOut(startPositionZoomCamera));
    }

    private IEnumerator ZoomOut(Vector3 startPosition)
    {
        isMoving = true;
        float duration = 1f;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            zoomCamera.transform.position = Vector3.Lerp(startPosition, mainCamera.transform.position, t);
            yield return null;
        }
        zoomCamera.transform.position = startPositionZoomCamera;
        zoomCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        isMoving = false;
    }
}
