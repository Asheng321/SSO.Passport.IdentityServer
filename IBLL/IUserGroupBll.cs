using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
        List<int> GetParentIdById(int id);

        /// <summary>
        /// ��ȡ�û������еķ��ʿ�������
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        (IQueryable<ClientApp>, IQueryable<UserInfo>, List<UserGroup>, List<UserGroupRole>, List<Permission>, List<Control>, List<Menu>) Details(UserGroup @group);
    }
}