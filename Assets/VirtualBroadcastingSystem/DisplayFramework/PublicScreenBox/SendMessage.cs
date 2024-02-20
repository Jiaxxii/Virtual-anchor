using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace VirtualBroadcastingSystem.DisplayFramework.PublicScreenBox
{
    public class SendMessage : MonoBehaviour
    {
        [SerializeField] private GameObject messagePrf;

        private readonly List<MessageSetter> _messageList = new();

        private static float _currentHeight;


        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.Space)) Send(GetTempMessage());
        // }
        //
        // private string GetTempMessage()
        // {
        //     var message = DateTime.Now.ToString();
        //
        //     var result = new StringBuilder(new[] { "li Hua", "zhang shang", "xiao ming" }.GetRandomItem());
        //     var count = Random.Range(0, 5);
        //     for (var i = 0; i < count; i++)
        //     {
        //         result.Append(message);
        //     }
        //
        //     return result.ToString();
        // }


        public void Send(string message)
        {
            var messageSetter = Instantiate(messagePrf, transform).GetComponent<MessageSetter>();
            messageSetter.Text = message;
            messageSetter.Init();


            var maxHeight = (transform as RectTransform)?.rect.height ?? throw new InvalidCastException();

            // 如果这条消息会溢出,就把这条消息设置到底部
            if (Mathf.Abs(_currentHeight) + messageSetter.Size.y > maxHeight)
            {
                var y = maxHeight - messageSetter.Size.y;
                messageSetter.AnchoredPositionY = -y;

                // 将所有消息向上移动
                for (var i = _messageList.Count - 1; i >= 0; i--)
                {
                    var ms = _messageList[i];
                    y -= ms.Size.y;
                    ms.AnchoredPositionY = -y;

                    // 判断这个弹幕向上移动有没有完全超出显示宽
                    if (y < -ms.Size.y)
                    {
                        Destroy(ms.gameObject);
                        _messageList.RemoveAt(i);
                    }
                }
            }
            else
            {
                messageSetter.AnchoredPositionY = _currentHeight;
                _currentHeight -= messageSetter.Size.y;
            }

            _messageList.Add(messageSetter);
        }
        
        
        
    }
}