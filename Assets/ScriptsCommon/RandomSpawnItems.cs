using UnityEngine;

namespace Assets.ScriptsCommon
{
    public class RandomSpawnItems
    {
        public static GameObject SpawnItem(Vector3 position, Quaternion rotation)
        {
            string tagGameObject = "coin";
            float range = Random.Range(0, 1);
            if(range >= 0.5)
            {
                tagGameObject = "coin";
            }

           return ObjectPooler.Instance.SpawnFromPool(tagGameObject, position, rotation);        
        }
    }
}
