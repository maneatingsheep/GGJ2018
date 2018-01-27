using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParallaxView : MonoBehaviour
{
    private class ParallaxObject
    {
        public GameObject gameObject;
        public ParallaxContainer ParallaxContainer;
        public float TimeToLive;
    }

    [Serializable]
    public class ParallaxContainer
    {
        public string LayerName;
        public GameObject[] Prefabs;
        public float Speed;
        public float MaxAmount;
        public float SpawnSpeed;
        public float TimeToLive;
        public bool DieInEnd;
        public float XrandomWidth;
        [System.NonSerialized]
        public float TimeUntilNextSpwan;
        [System.NonSerialized]
        public int CurrentAmount = 0;
    }

    public ParallaxContainer[] ParallaxContainers;
    public GameplayMaster GameplayMasterRef;
    private float _startTime;
    private Boolean isStarted = false;
    private List<ParallaxObject> _parallaxObjects = new List<ParallaxObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (isStarted)
	    {
	        for (var i = 0; i < ParallaxContainers.Length; i++)
	        {
	            if (ParallaxContainers[i].CurrentAmount == ParallaxContainers[i].MaxAmount)
	            {
	                continue;
	            }

	            ParallaxContainers[i].TimeUntilNextSpwan -= Time.deltaTime;

	            if (ParallaxContainers[i].TimeUntilNextSpwan < 0)
	            {
	                ParallaxContainers[i].TimeUntilNextSpwan = ParallaxContainers[i].SpawnSpeed;
	                Spwan(ParallaxContainers[i]);
	            }
	        }

	        for (var i = 0; i < _parallaxObjects.Count; i++)
	        {
	            if (_parallaxObjects[i].TimeToLive > 0)
	            {
	                _parallaxObjects[i].TimeToLive -= Time.deltaTime;
	                _parallaxObjects[i].gameObject.transform.localPosition +=
	                    new Vector3(0, Time.deltaTime * _parallaxObjects[i].ParallaxContainer.Speed, 0);
	            }
            }
	    }
	}

    private void Spwan(ParallaxContainer parallaxContainer)
    {
        parallaxContainer.CurrentAmount++;
        var prefab = parallaxContainer.Prefabs[UnityEngine.Random.Range(0, parallaxContainer.Prefabs.Length)];
        var parallaxGameObject = Instantiate(prefab);
        parallaxGameObject.transform.parent = gameObject.transform;

        var randomX = UnityEngine.Random.Range(-parallaxContainer.XrandomWidth, parallaxContainer.XrandomWidth);
        parallaxGameObject.transform.localPosition += new Vector3(randomX, 0,0);
        
        _parallaxObjects.Add(new ParallaxObject()
        {
            gameObject = parallaxGameObject,
            ParallaxContainer = parallaxContainer,
            TimeToLive = parallaxContainer.TimeToLive
        });
    }

    void Awake()
    {

    }

    public void Init()
    {
        GameplayMasterRef.EStartLevel += Play;
    }

    private void Play(bool isStart)
    {
        if (isStart)
        {
            isStarted = true;
            for (var i = 0; i < ParallaxContainers.Length; i++)
            {
                ParallaxContainers[i].TimeUntilNextSpwan = ParallaxContainers[i].SpawnSpeed;
            }
        }
    }
}
