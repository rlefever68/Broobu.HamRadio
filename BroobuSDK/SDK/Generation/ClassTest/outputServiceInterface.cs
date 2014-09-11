//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.ManageAuthorization.Contract.Domain;
using System;
using System.ServiceModel;

namespace Pms.ManageAuthorization.Contract.Interfaces
{
	[ServiceContract(Namespace = Pms.Framework.Domain.ServiceConst.Namespace)]
  	public interface IManageAuthorization
  	{
		#region Methods
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		ApplicationFunctionViewItem[] GetAllApplicationFunctions();

		[OperationContract]
		ApplicationFunctionViewItem[] SaveApplicationFunctions(ApplicationFunctionViewItem[] applicationFunctionViewItems);

		[OperationContract]
		ApplicationFunctionViewItem[] DeleteApplicationFunctions(ApplicationFunctionViewItem[] applicationFunctionViewItems);

		[OperationContract]
		RoleViewItem[] GetAllRoles();

		[OperationContract]
		RoleViewItem[] SaveRoles(RoleViewItem[] roleViewItems);

		[OperationContract]
		RoleViewItem[] DeleteRoles(RoleViewItem[] roleViewItem);

		[OperationContract]
		AccountViewItem[] GetAccountsForRole(String roleId);

		[OperationContract]
		AccountViewItem[] GetAllAccounts();

		#endregion

	}
}

-----------------------New File----------------------------------------------------------

