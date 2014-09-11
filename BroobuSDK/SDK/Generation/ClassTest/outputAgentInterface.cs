//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.ManageAuthorization.Contract.Domain;
using System;

namespace Pms.ManageAuthorization.Contract.Interfaces
{
  	public partial interface IManageAuthorizationAgent: IManageAuthorization
  	{
		#region Events
		event Action<ApplicationFunctionViewItem[]> GetAllApplicationFunctionsCompleted;

		event Action<ApplicationFunctionViewItem[]> SaveApplicationFunctionsCompleted;

		event Action<ApplicationFunctionViewItem[]> DeleteApplicationFunctionsCompleted;

		event Action<RoleViewItem[]> GetAllRolesCompleted;

		event Action<RoleViewItem[]> SaveRolesCompleted;

		event Action<RoleViewItem[]> DeleteRolesCompleted;

		event Action<AccountViewItem[]> GetAccountsForRoleCompleted;

		event Action<AccountViewItem[]> GetAllAccountsCompleted;

		#endregion
		#region Methods
		void GetAllApplicationFunctionsAsync(Action<ApplicationFunctionViewItem[]> action = null);

		void SaveApplicationFunctionsAsync(ApplicationFunctionViewItem[] applicationFunctionViewItems, Action<ApplicationFunctionViewItem[]> action = null);

		void DeleteApplicationFunctionsAsync(ApplicationFunctionViewItem[] applicationFunctionViewItems, Action<ApplicationFunctionViewItem[]> action = null);

		void GetAllRolesAsync(Action<RoleViewItem[]> action = null);

		void SaveRolesAsync(RoleViewItem[] roleViewItems, Action<RoleViewItem[]> action = null);

		void DeleteRolesAsync(RoleViewItem[] roleViewItem, Action<RoleViewItem[]> action = null);

		void GetAccountsForRoleAsync(String roleId, Action<AccountViewItem[]> action = null);

		void GetAllAccountsAsync(Action<AccountViewItem[]> action = null);

		#endregion

	}
}

-------------------------New File--------------------------------------------------------

