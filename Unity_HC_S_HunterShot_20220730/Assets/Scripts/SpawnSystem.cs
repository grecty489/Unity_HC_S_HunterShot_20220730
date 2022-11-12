using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace grecty489
{
    /// <summary>
    /// �ͦ��t��
    /// </summary>
    public class SpawnSystem : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("�Ǫ��w�s��")]
        private GameObject[] prefabEnemys;
        [SerializeField, Header("�Ǫ��ͦ��ĤG��")]
        private Transform[] traSpawnPoints;
        [Header("�ͦ��ƶq�G�̤p�P�̤j��")]
        [SerializeField]
        private int minEnemy = 2;
        [SerializeField]
        private int maxEnemy = 5;
        [SerializeField, Header("�ĤG�ƪ���l�M��")]
        private List<Transform> listSpawnPoints = new List<Transform>();
        [SerializeField, Header("�u�]��l")]
        private GameObject prefabMarble;
        #endregion

        #region �ƥ�
        private void Awake()
        {
            spwanEnemy();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �ͦ��ĤH
        /// </summary>
        private void spwanEnemy() 
        {
            int randomCount = Random.Range(minEnemy, maxEnemy + 1);
            print("<color=blue>�ĤH�H���ƶq�G" + randomCount + "</color>");

            int countToDelete = traSpawnPoints.Length - randomCount;
            print("<color=red>�n�R�����ƶq�G" + countToDelete + "</color>");

            // �M�� = �}�C.�ର�M��()�F
            listSpawnPoints = traSpawnPoints.ToList();

            // �t��.�H�� �H�� = �s �H������F
            System.Random random = new System.Random();
            // �ͦ��M�� = �ͦ��M��.�Ƨ�(�C�@�ӲM�� => �çǱƧ�).��^�M��F
            listSpawnPoints = listSpawnPoints.OrderBy(item => random.Next()).ToList();

            // �z�L�j��R���M��Ĥ@��
            for (int i = 0; i < countToDelete; i++) listSpawnPoints.RemoveAt(0);

            for (int i = 0; i < randomCount; i++)
            {
                // ���o�M�椺�ĤG�Ʈ�l���y��
                Vector3 pos = listSpawnPoints[i].position;
                if (i == 0)
                {
                    Instantiate(prefabMarble, pos, Quaternion.identity);
                }
                else
                {
                    // �H���Ǫ�
                    int randomEnemy = Random.Range(0, prefabEnemys.Length);
                    // �ɦ��Ǫ�(�Ǫ��A�y�СA���׹s)�F
                    Instantiate(prefabEnemys[randomEnemy], pos, Quaternion.identity);
                }
            }
        }
        #endregion

    }

}
