//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.ManageAuthorization.Contract.Domain;
using Pms.ManageAuthorization.Contract.Interfaces;
using System;

namespace Pms.ManageAuthorization.Business.Interfaces
{
  	public interface IManageAuthorizationProvider: IProvider
  	{
		#region Methods
		ApplicationFunctionViewItem[] GetAllApplicationFunctions();

		ApplicationFunctionViewItem[] SaveApplicationFunctions(ApplicationFunctionViewItem[] applicationFunctionViewItems);

		ApplicationFunctionViewItem[] DeleteApplicationFunctions(ApplicationFunctionViewItem[] applicationFunctionViewItems);

		RoleViewItem[] GetAllRoles();

		RoleViewItem[] SaveRoles(RoleViewItem[] roleViewItems);

		RoleViewItem[] DeleteRoles(RoleViewItem[] roleViewItem);

		AccountViewItem[] GetAccountsForRole(String roleId);

		AccountViewItem[] GetAllAccounts();

		#endregion

	}
}

-------------------------New File--------------------------------------------------------

