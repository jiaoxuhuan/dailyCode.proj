/**************************************************************************************************
 * 作    者：郭晓东             创始时间：2013-07-18                                              *
 * 修 改 人：                   修改时间：                                                        *
 * 描    述：巡检点结果记录扩展实体，用于手持服务中的巡检点数据上传方法                                                                       *
 **************************************************************************************************/

using System.Collections.Generic;

namespace DailyConsoleApplication.entity
{
    /// <summary>
    /// 巡检点结果记录扩展实体，用于手持服务中的巡检点数据上传方法 
    /// </summary>
    /// <remarks>
    /// 模块编号：mes_om_entity_class_SetPtrlPointRecExEntity
    /// 作    者：郭晓东 
    /// 创建时间：2013-07-18
    /// 修改编号：1         
    /// 描    述：巡检点结果记录扩展实体，用于手持服务中的巡检点数据上传方法
    /// </remarks>
    public class SetPtrlPointRecExEntity
    {
        #region Model

        /// <summary>
        /// 巡检点ID
        /// </summary>
        public string ptrl_point_id { get; set; }

        /// <summary>
        /// 条件线路ID
        /// </summary>
        public string con_line_id { get; set; }

        /// <summary>
        /// 巡检点结果ID
        /// </summary>
        public string result_rfid_id { get; set; }

        /// <summary>
        /// 线路结果ID
        /// </summary>
        public string result_route_id { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string start_time { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string end_time { get; set; }

        /// <summary>
        /// 巡检内容结果集合
        /// </summary>
        public List<SetPtrlPointRecContentExEntity> ptrlPointRecContentList { get; set; }
        #endregion
    }
}
