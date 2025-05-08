using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public static LightingManager Instance { get; private set; }

    // global switch
    public bool disableFlickering = false;

    // internal variables
    private Light[] inGameLights;
    private float lightFlickerTimer;
    private float lightFlickerProbability;
    private float flickerLength = 0.25f;

    private float countDown;

    // default light values
    private float[] baseIntensities;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        // Get light components in scene
        inGameLights = GetComponentsInChildren<Light>();

        // save initial values for lights
        baseIntensities = new float[inGameLights.Length];
        for (int i = 0; i < inGameLights.Length; i++)
        {
            baseIntensities[i] = inGameLights[i].intensity;
        }
    }

    void Update()
    {
        if (!disableFlickering) FlickerRandomLight();
    }

    public void TurnOffAllLights()
    {
        for (int i = 0; i < inGameLights.Length; i++)
        {
            // get paramters
            Light light = inGameLights[i];
            //MeshRenderer lightRenderer = light.gameObject.GetComponent<MeshRenderer>();
            //int emissionPropertyID = Shader.PropertyToID("_EmissionColor");

            // modify parameters
            light.intensity = 0;
            //lightRenderer.material.color = Color.black;
            //lightRenderer.material.SetColor(emissionPropertyID, Color.black);
        }
        // disable flickering
        disableFlickering = true;
    }

    public void TurnOnAllLights()
    {
        for (int i = 0; i < inGameLights.Length; i++)
        {
            // get paramters
            Light light = inGameLights[i];
            //MeshRenderer lightRenderer = light.gameObject.GetComponent<MeshRenderer>();
            //int emissionPropertyID = Shader.PropertyToID("_EmissionColor");

            // modify parameters
            light.intensity = baseIntensities[i];
            //lightRenderer.material.color = Color.white;
            //lightRenderer.material.SetColor(emissionPropertyID, Color.white);
        }
        // enable flickering
        disableFlickering = false;
    }

    public void UpdateDay(SO_Day newDay)
    {
        lightFlickerTimer = newDay.lightFlickerTimer;
        lightFlickerProbability = newDay.lightFlickerProbability;
        countDown = lightFlickerTimer;
    }

    public void FlickerRandomLight()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            float random = Random.Range(0, 100);
            if (random < lightFlickerProbability)
            {
                Light light = inGameLights[Random.Range(0, inGameLights.Length)];
                StartCoroutine(FlickerForSeconds(light, flickerLength));
            }
            countDown = lightFlickerTimer;
        }
    }

    private IEnumerator FlickerForSeconds(Light light, float seconds)
    {
        // save default values
        float baseIntensity = light.intensity;
        MeshRenderer lightRenderer = light.gameObject.GetComponent<MeshRenderer>();
        int emissionPropertyID = Shader.PropertyToID("_EmissionColor");
        float flickerSpeed = Random.Range(5, 20);

        // flicker light for timer length
        float i = 0;
        while (i < seconds)
        {
            light.intensity = baseIntensity * (0.7f + 0.3f * Mathf.Sin(Mathf.PI / 2 + flickerSpeed * Time.time));
            //lightRenderer.material.color = Color.white * light.intensity / baseIntensity;
            //lightRenderer.material.SetColor(emissionPropertyID, Color.white * (light.intensity / baseIntensity - 0.25f));
            i += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        // return to default values
        light.intensity = baseIntensity;
        //lightRenderer.material.color = Color.white * light.intensity / baseIntensity;
        //lightRenderer.material.SetColor(emissionPropertyID, Color.white);
    }
}
