using System.Collections.Generic;
using UnityEngine;

public class RocketsPool : Pool<Rocket>
{
    public static RocketsPool Instance;

    [SerializeField] private int _count;
    [SerializeField] private GameObject _rocket;
    [SerializeField] private GameObject _rocketContainer;

    private List<GameObject> _rockets = new List<GameObject>();

    protected override void Awake()
    {
        Instance = this;
        CreateObjects(_count);
    }

    protected override void CreateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(_rocket, _rocketContainer.transform);
            obj.gameObject.SetActive(false);
            _rockets.Add(obj);
        }
    }

    public override Rocket GetObject()
    {
        for (int i = 0; i < _rockets.Count; i++)
        {
            if (_rockets[i].gameObject.activeInHierarchy == false)
            {
                return _rockets[i].gameObject.GetComponent<Rocket>();
            }
        }

        return null;
    }
}
