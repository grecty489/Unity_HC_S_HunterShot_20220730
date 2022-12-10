using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

namespace grecty489
{
    /// <summary>
    /// �ˮ`�t�ΡG���Ͷˮ`�Ȫ���A��s�ˮ`�ȻP�ʵe�ĪG
    /// </summary>
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField, Header("�e���ˮ`��")]
        private GameObject prefabDamage;
        [SerializeField, Header("�ˮ`�Ȧ첾")]
        private Vector3 offsetDamge;

        private void Awake()
        {
            SpawnDamegeObject();
        }

        /// <summary>
        /// �ͦ��ˮ`�Ȫ���
        /// </summary>
        private void SpawnDamegeObject()
        {
             GameObject tempDamage = Instantiate(
                prefabDamage,
                transform.position + offsetDamge,
                Quaternion.Euler(60, 0, 0));

            StartCoroutine(AnimationEffect(tempDamage));
        }
        /// <summary>
        /// �ʵe�ĪG
        /// </summary>
        /// <param name="tempDamage">�ˮ`�Ȫ���</param>
        /// <returns></returns>
        private IEnumerator AnimationEffect(GameObject tempDamage)
        {
            StartCoroutine(Fade(tempDamage.GetComponent<CanvasGroup>()));

            yield return StartCoroutine(MoveDamage(tempDamage.GetComponent<RectTransform>()));

            yield return StartCoroutine(MoveDamage(tempDamage.GetComponent<RectTransform>(), false, 3));

            StartCoroutine(Fade(tempDamage.GetComponent<CanvasGroup>(), false));
        }

        /// <summary>
        /// ���ʶˮ`�ȮĪG
        /// </summary>
        /// <param name="rectDamage">�ˮ`���ܧΤ���</param>
        /// <returns></returns>

        private IEnumerator MoveDamage(RectTransform rectDamage, bool isUP = true, int count = 10)
        {
            float increase = isUP ? +0.1f : -0.1f;

            for (int i = 0; i < count; i++)
            {
                rectDamage.anchoredPosition += new Vector2(0, increase);
                yield return new WaitForSeconds(0.03f);
            }
        }

        /// <summary>
        /// �H�J�H�X
        /// </summary>
        /// <param name="group">�s�դ���</param>
        /// <param name="fadeIn">�O�_�H�J</param>
        private IEnumerator Fade(CanvasGroup group,bool fadeIn = true)
        {
            // �T���B��l
            // ���L�� ? ���L�Ȭ� true : ���L�Ȭ� false;
            float increase = fadeIn ? +0.1f : -0.1f;    // �p�G �H�J �N�W�[ +0.1 ���� -0.1

            for (int i = 0; i < 10; i++)
            {
                group.alpha += increase;                // �s�խ�󪺳z���� �v�W
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}

