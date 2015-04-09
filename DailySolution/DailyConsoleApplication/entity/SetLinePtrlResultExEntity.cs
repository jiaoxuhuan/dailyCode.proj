/**************************************************************************************************
 * 作    者：郭晓东             创始时间：2013-07-11                                              *
 * 修 改 人：                   修改时间：                                                        *
 * 描    述：线路巡检结果扩展实体，用于手持服务中的使用路线数据上传方法                                                                       *
 **************************************************************************************************/

using System.Collections.Generic;

namespace DailyConsoleApplication.entity
{
    /// <summary>
    /// 线路巡检结果扩展实体，用于手持服务中的使用路线数据上传方法 
    /// </summary>
    /// <remarks>
    /// 模块编号：mes_om_entity_class_SetLinePtrlResultExEntity
    /// 作    者：郭晓东 
    /// 创建时间：2013-07-17
    /// 修改编号：1         
    /// 描    述：线路巡检结果扩展实体，用于手持服务中的使用路线数据上传方法 
    /// </remarks>
    public class SetLinePtrlResultExEntity
    {
        #region Model

        /// <summary>
        /// 使用线路id
        /// </summary>
        public string use_line_id { get; set; }

        /// <summary>
        /// 条件线路ID
        /// </summary>
        public string con_line_id { get; set; }

        /// <summary>
        /// 巡检计划
        /// </summary>
        public string plan_id { get; set; }

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
        /// 用户ID
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 漏检数量
        /// </summary>
        public string lost_count { get; set; }

        /// <summary>
        /// 异常数量
        /// </summary>
        public string error_count { get; set; }

        /// <summary>
        /// 巡检内容个数
        /// </summary>
        public string content_count { get; set; }

        /// <summary>
        /// 巡检点结果集合
        /// </summary>
        public List<SetPtrlPointRecExEntity> ptrlPointRecList { get; set; }
        #endregion
    }
}
