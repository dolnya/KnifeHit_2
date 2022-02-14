
using UnityEngine;


namespace SDA.Generation
{
    public class LevelGenerator : MonoBehaviour
    {
        [Header("Shield")]
        [SerializeField]
        private Transform shieldPos;

        [SerializeField]
        private BaseShield shieldPrefab;

        [SerializeField]
        private BaseShield[] simpleShield;

        [SerializeField]
        private BaseShield[] bossShield;




        [SerializeField]
        private Transform shieldRoot;

        [Header("Knife")]
        [SerializeField]
        private Transform knifePos;

        [SerializeField]
        private Knife knifePrefab;

        [SerializeField]
        private Transform knifeRoot;


        public BaseShield SpawnShield(StageType stageType)
        {
            BaseShield shieldToSpawn = default;

            if (stageType == StageType.Normal)
            {
                var randomIndex = Random.Range(0, simpleShield.Length);
                shieldToSpawn = simpleShield[randomIndex];
            }
            else
            {
                var randomIndex = Random.Range(0, bossShield.Length);
                shieldToSpawn = bossShield[randomIndex];
            }

            var shieldObj = Instantiate(shieldToSpawn,
                shieldPos.position, shieldPos.rotation);

            shieldObj.transform.SetParent(shieldRoot);

            return shieldObj;



        }

        public Knife SpawnKnife()
        {
            var knifeObj = Instantiate(knifePrefab,
                knifePos.position, knifePos.rotation);

            knifeObj.transform.SetParent(knifeRoot);

            return knifeObj;
        }
    }
}
