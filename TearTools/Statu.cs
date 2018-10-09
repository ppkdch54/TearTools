using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSJCMaster.Models
{
    /// <summary>
    /// 当前状态
    /// </summary>
    public enum Statu
    {
        /// <summary>
        /// 已连接
        /// </summary>
        Connected = 0,
        /// <summary>
        /// 未连接
        /// </summary>
        Notconnected,
        /// <summary>
        /// 正在重连
        /// </summary>
        Reconnecting,
        /// <summary>
        /// 未知
        /// </summary>
        Unknown
    }
}
