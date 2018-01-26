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
        List<int> GetParentIdById(int id);

        /// <summary>
        /// ��ȡ�û������еķ��ʿ�������
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        (List<ClientApp>, List<UserInfo>, List<UserGroup>, List<Role>, List<Permission>, List<Control>, List<Menu>) Details(UserGroup g);
    }
}