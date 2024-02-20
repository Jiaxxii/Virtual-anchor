using System;
using TMPro;
using UnityEngine;

namespace VirtualBroadcastingSystem.DisplayFramework.PublicScreenBox
{
    public class MessageSetter : MonoBehaviour
    {
        private const float FirstLineTextMaxWidth = 200;


        [SerializeField] private RectTransform content;
        [SerializeField] private RectTransform bubble;
        [SerializeField] private RectTransform level;
        [SerializeField] private RectTransform label;
        [SerializeField] private TextMeshProUGUI input;
        [SerializeField] private TextMeshProUGUI nextText;


        public string Text
        {
            get => input.text;
            set => input.text = value;
        }


        public Vector2 Size
        {
            get => content.sizeDelta;
            set => content.sizeDelta = value;
        }

        public Vector2 AnchoredPosition
        {
            get => content.anchoredPosition;
            set => content.anchoredPosition = value;
        }

        public float AnchoredPositionY
        {
            get => content.anchoredPosition.y;
            set => content.anchoredPosition = new Vector2(AnchoredPosition.x, value);
        }


        // 我一直怀疑“ Get( 360f,input.preferredWidth - FirstLineTextMaxWidth) + 1;”这里是愚蠢的，它是不是不需要单独写一个函数就可以实现？
        // private static int Get(float step, float target)
        public void Init()
        {
            input.text = input.text.Replace(" ", "<space=5>");
            // 文字未出水平范围
            if (input.preferredWidth < FirstLineTextMaxWidth)
            {
                var x = 5 + level.sizeDelta.x + 5 + label.sizeDelta.x + 5 + input.preferredWidth + 5;
                var y = 10 + input.preferredHeight + 5;
                bubble.sizeDelta = new Vector2(x, y);
            }
            else
            {
                var scale = Mathf.Floor((input.preferredWidth - FirstLineTextMaxWidth) / 360f) + 2;
                var height = input.preferredHeight * scale;

                bubble.sizeDelta = new Vector2(bubble.sizeDelta.x, height + level.sizeDelta.y);
                nextText.rectTransform.sizeDelta = new Vector2(nextText.rectTransform.sizeDelta.x, bubble.sizeDelta.y - level.sizeDelta.y - 10);
            }

            content.sizeDelta = new Vector2(content.sizeDelta.x, bubble.sizeDelta.y + 10 + 10);
        }


        private static int Get(float step, float target)
        {
            var index = 1;
            var value = step;
            while (value < target)
            {
                index++;
                value += step;
            }

            return index;
        }
    }
}