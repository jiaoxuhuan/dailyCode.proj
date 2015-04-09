/**************************************************************************************************
 * 作    者：郭晓东             创始时间：2013-07-18                                              *
 * 修 改 人：                   修改时间：                                                        *
 * 描    述：巡检内容结果记录扩展实体，用于手持服务中的巡检内容结果数据上传方法                                                                       *
 **************************************************************************************************/

using System.Collections.Generic;

namespace DailyConsoleApplication.entity
{
    /// <summary>
    /// 巡检内容结果记录扩展实体，用于手持服务中的巡检内容结果数据上传方法  
    /// </summary>
    /// <remarks>
    /// 模块编号：mes_om_entity_class_SetPtrlPointRecContentExEntity
    /// 作    者：郭晓东 
    /// 创建时间：2013-07-18
    /// 修改编号：1         
    /// 描    述：巡检内容结果记录扩展实体，用于手持服务中的巡检内容结果数据上传方法 
    /// </remarks>
    public class SetPtrlPointRecContentExEntity
    {
        /// <summary>
        /// 巡检内容ID
        /// </summary>
        public string ptrl_content_id { get; set; }

        /// <summary>
        /// 巡检内容结果ID
        /// </summary>
        public string result_point_id { get; set; }

        /// <summary>
        /// 巡检点结果ID
        /// </summary>
        public string result_rfid_id { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string start_time { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string end_time { get; set; }

        /// <summary>
        /// 记录内容
        /// </summary>
        public string rec_content { get; set; }

        /// <summary>
        /// 震动数据
        /// </summary>
        public string quake_data { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string des { get; set; }

        /// <summary>
        /// 是否异常
        /// </summary>
        public string is_alarm { get; set; }

        /// <summary>
        /// 状态（启用：1;备用：2;停用：3;待修：4;）
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 用户登录名称
        /// </summary>
        public string loginname { get; set; }

        /// <summary>
        /// 附件列表
        /// </summary>
        public List<PtrlFile> files { get; set; }
    }
    public class PtrlFile
    {
        /// <summary>
        /// 类型:1图片2视频3音频
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 文件内容，为Base64编码byte[]
        /// </summary>
        public string data { get; set; }
    }
}
