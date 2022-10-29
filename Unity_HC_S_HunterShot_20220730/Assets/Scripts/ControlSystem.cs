using UnityEngine;
using System.Collections;

namespace grecty489
{
    /// <summary>
    /// ����t��
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        #region ���
        [Header("�򥻸��")]
        [SerializeField, Range(0, 50)]
        private float Speed = 10.5f;
        [SerializeField]
        private int countShootMarble = 10;
        [SerializeField, Range(0, 5000)]
        private int SpeedMarble = 1500;
        [SerializeField, Range(0, 3)]
        private float intervalShoot = 0.5f;
        [SerializeField, Header("�u�]���s��")]
        private GameObject prefabMarble;
        [SerializeField, Header("�u�]�ͦ��I")]
        private Transform pointSpwan;
        [SerializeField, Header("�b�Y")]
        private GameObject goArrow;

        private string perAttact = "Ĳ�o����";
        private Animator ani;
        #endregion

        private void Awake()
        {
            //  ���o����<�x��>()
            //  �ʵe = ���o����<�ʵe>()
            ani = GetComponent<Animator>();

            StartCoroutine(SpawnMarble(countShootMarble));
        }

        #region ��k
        /// <summary>
        /// ���ਤ��
        /// </summary>
        private void TurnCharacter()
        {
            
        }

        /// <summary>
        /// �o�g�u�]
        /// </summary>
        private void ShootMarble() 
        {
            
        }

        /// <summary>
        /// �ͦ��u�]
        /// </summary>
        /// <param name="countToSpwan">�n�ͦ����u�]�ƶq</param>
        private IEnumerator SpawnMarble(int countToSpwan) 
        {
            // Objet.Instantiate();     //�Ĥ@�ؼg�k�AStatic
            //Instantiate();            //�ĤG�ؼg�k�A�~�����O

            for (int i = 0; i < countToSpwan; i++)
            { 
                //�ͦ�(����A�y�СA����)
                Instantiate(prefabMarble, pointSpwan.position, pointSpwan.rotation);
                ani.SetTrigger(perAttact);
                yield return new WaitForSeconds(intervalShoot);
            }
        }
        #endregion
        
    }
}



