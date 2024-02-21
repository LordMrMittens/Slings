using System;
using UnityEngine;

[Serializable]
struct CloudGroup{
    public String groupName; //this is for organisational purposes only
    public Cloud[] clouds;
    public float minFrequency;
    public float maxFrequency;
    public float minHeight;
    public float maxHeight;
    public float speed;
    public float CloudFrequency {get;set;}
    public float timeOfLastCloud {get;set;}

}

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] CloudGroup[] clouds;


    private void Start() {
        for (int i = 0; i < clouds.Length; i++)
        {
            clouds[i].CloudFrequency = SetGenerationFrequency(clouds[i].minFrequency, clouds[i].maxFrequency);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCloudsIfTimeElapsed();
    }

    private void SpawnCloudsIfTimeElapsed()
    {
        for (int i = 0; i < clouds.Length; i++)
        {
            if (Time.time - clouds[i].timeOfLastCloud > clouds[i].CloudFrequency)
            {
                clouds[i].timeOfLastCloud = Time.time;
                clouds[i].CloudFrequency = SpawnCloud(clouds[i]);
                Debug.Log($"Cloud {clouds[i].groupName} time elapsed{Time.time - clouds[i].timeOfLastCloud} freq : {clouds[i].CloudFrequency}");
            }
        }
    }

    float SetGenerationFrequency(float minFrequency, float maxFrequency){
        return UnityEngine.Random.Range(minFrequency, maxFrequency);
    }
    float SpawnCloud(CloudGroup cloudGroup){
        
        int cloudIndex = UnityEngine.Random.Range(0, cloudGroup.clouds.Length);
        Cloud cloud = Instantiate(cloudGroup.clouds[cloudIndex], SetSpawnPosition(cloudGroup), Quaternion.identity);
        cloud.speed = cloudGroup.speed;
        
        
        return SetGenerationFrequency(cloudGroup.minFrequency,cloudGroup.maxFrequency);
    }
    Vector3 SetSpawnPosition(CloudGroup cloudGroup){
        return new Vector3(-GameManager.instance.screenBounds.x+3, UnityEngine.Random.Range(cloudGroup.minHeight, cloudGroup.maxHeight),0);
    }

}
