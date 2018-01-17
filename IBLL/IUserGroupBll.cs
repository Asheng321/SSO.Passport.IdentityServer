using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using Models.Dto;
using Models.Entity;

namespace IBLL
{
    public partial interface IUserGroupBll
    {
        /// <summary>
        /// ����������Ȩ��
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        UserGroup GetGroupByName(string name);

        /// <summary>
        /// �ж�Ȩ�����Ƿ����
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool GroupNameExist(string name);

        /// <summary>
        /// ����Ȩ�������������û�
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<UserInfo> GetUserInfoList(string name);

        /// <summary>
        /// ͨ���洢���̻���Լ��Լ��Լ����е���Ԫ�ؼ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DbRawSqlQuery<UserGroupOutputDto> GetSelfAndChildrenByParentId(int id);

        /// <summary>
        /// �����޼��Ӽ��Ҷ�����������id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetParentIdById(int id);
    }
}