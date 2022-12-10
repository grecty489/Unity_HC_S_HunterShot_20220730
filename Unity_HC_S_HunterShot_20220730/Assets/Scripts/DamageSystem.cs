using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

namespace grecty489
{
    /// <summary>
    /// 傷害系統：產生傷害值物件，更新傷害值與動畫效果
    /// </summary>
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField, Header("畫布傷害值")]
        private GameObject prefabDamage;
        [SerializeField, Header("傷害值位移")]
        private Vector3 offsetDamge;

        private void Awake()
        {
            SpawnDamegeObject();
        }

        /// <summary>
        /// 生成傷害值物件
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
        /// 動畫效果
        /// </summary>
        /// <param name="tempDamage">傷害值物件</param>
        /// <returns></returns>
        private IEnumerator AnimationEffect(GameObject tempDamage)
        {
            StartCoroutine(Fade(tempDamage.GetComponent<CanvasGroup>()));

            yield return StartCoroutine(MoveDamage(tempDamage.GetComponent<RectTransform>()));

            yield return StartCoroutine(MoveDamage(tempDamage.GetComponent<RectTransform>(), false, 3));

            StartCoroutine(Fade(tempDamage.GetComponent<CanvasGroup>(), false));
        }

        /// <summary>
        /// 移動傷害值效果
        /// </summary>
        /// <param name="rectDamage">傷害值變形元件</param>
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
        /// 淡入淡出
        /// </summary>
        /// <param name="group">群組元件</param>
        /// <param name="fadeIn">是否淡入</param>
        private IEnumerator Fade(CanvasGroup group,bool fadeIn = true)
        {
            // 三元運算子
            // 布林值 ? 布林值為 true : 布林值為 false;
            float increase = fadeIn ? +0.1f : -0.1f;    // 如果 淡入 就增加 +0.1 直到 -0.1

            for (int i = 0; i < 10; i++)
            {
                group.alpha += increase;                // 群組原件的透明度 逐增
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}

