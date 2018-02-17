using System.Linq;
using UnityEngine;

namespace Assets
{
    public class ElementsPool : MonoBehaviour {
        public GameObject[] fireShown;
        public GameObject[] waterShown;
    
        // Use this for initialization
        void Start ()
        {
            for(int i=0;i< waterShown.Length; i++)
            {
                waterShown[i].SetActive(false);
            }
        }

        private GameObject FindRandomInactiveGameObject(GameObject[] gameobjects)
        {
            var indexes = gameobjects.Select((go, index) => new { go, index })
                .Where(item => ! item.go.activeSelf)
                .Select(item => item.index)
                .ToList();

            var randomIndex = Random.value * indexes.Count();
            var waterIndex = indexes[(int)randomIndex];

            return gameobjects[waterIndex];
        }

        private GameObject FindRandomActiveGameObject(GameObject[] gameobjects)
        {
            var indexes = gameobjects.Select((go, index) => new { go, index })
                .Where(item => item.go.activeSelf )
                .Select(item => item.index)
                .ToList();

            var randomIndex = Random.value * indexes.Count();
            var waterIndex = indexes[(int)randomIndex];

            return gameobjects[waterIndex];
        }

        public void RemoveWater()
        {
            var water = FindRandomActiveGameObject(waterShown);
            water.SetActive(false);
        }
        public void RemoveFire()
        {
            var fire = FindRandomActiveGameObject(fireShown);
            fire.SetActive(false);
        }

        public void AddWater(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                var water = FindRandomInactiveGameObject(waterShown);
                water.SetActive(true);
            }
        }
        public void AddFire(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var fire = FindRandomInactiveGameObject(fireShown);
                fire.SetActive(true);
            }
        }

        // Update is called once per frame
        void Update ()
        {
        }
    }
}
