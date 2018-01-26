using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using Models.Dto;

namespace IBLL
{
    public partial interface IMenuBll
    {
        /// <summary>
        /// ͨ���洢���̻���Լ��Լ��Լ����е���Ԫ�ؼ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DbRawSqlQuery<MenuOutputDto> GetSelfAndChildrenByParentId(int id);

        /// <summary>
        /// �����޼��Ӽ��Ҷ�����������id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> GetParentIdById(int id);
    }
}