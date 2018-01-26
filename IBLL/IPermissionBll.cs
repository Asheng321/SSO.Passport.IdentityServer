using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using Models.Dto;
using Models.Entity;

namespace IBLL
{
    public partial interface IPermissionBll
    {
        /// <summary>
        /// ����������Ȩ��
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Permission GetPermissionByName(string name);

        /// <summary>
        /// �ж�Ȩ�����Ƿ����
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool PermissionNameExist(string name);

        /// <summary>
        /// ����Ȩ�������������û�
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<UserInfo> GetUserInfoList(string name);

        /// <summary>
        /// ����Ȩ�����������Ľ�ɫ�б�
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<Role> GetRoleList(string name);
        /// <summary>
        /// ͨ���洢���̻���Լ��Լ��Լ����е���Ԫ�ؼ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DbRawSqlQuery<PermissionOutputDto> GetSelfAndChildrenByParentId(int id);

        /// <summary>
        /// �����޼��Ӽ��Ҷ�����������id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<int> GetParentIdById(int id);

        /// <summary>
        /// ��ȡȨ�����еķ��ʿ������飬���������̳�
        /// </summary>
        /// <returns></returns>
        (List<ClientApp>, List<UserPermission>, List<Role>, List<Permission>, List<Control>, List<Menu>) Details(Permission permission);
    }
}