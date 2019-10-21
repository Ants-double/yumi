using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeTools
{
    public static class MessageToken
    {

        /// <summary>
        /// 动画信息标志
        /// </summary>
        public static readonly string AnimateMessageToken;

        /// <summary>
        /// 发送消息标志
        /// </summary>
        public static readonly string SendMessageToken;

        static MessageToken()
        {
            AnimateMessageToken = nameof(AnimateMessageToken);

            SendMessageToken = nameof(SendMessageToken);
        }
    }
}
