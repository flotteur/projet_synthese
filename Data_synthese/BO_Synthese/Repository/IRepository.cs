using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO_Synthese.Repository
{
    public interface IRepository<DTO, BD>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtoObject"></param>
        /// <returns></returns>
        BD ToBD(DTO dtoObject);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbObject"></param>
        /// <returns></returns>
        DTO ToDto(BD dbObject);
    }
}
