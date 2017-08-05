using System.Collections.Generic;
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
    }
}