using Pms.Framework.Networking.Wcf;
using Pms.ManageAuthorization.Contract.Domain;
using Pms.ManageAuthorization.Contract.Interfaces;
using System;
using System.ServiceModel;

namespace Pms.ManageAuthorization.Service
{
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public partial class ManageAuthorizationService: BusinessServiceBase, IManageAuthorization
	{
		#region Methods
		[OperationBehavior(TransactionScopeRequired = true)]
		public ApplicationFunctionViewItem[] GetAllApplicationFunctions()		{
			return Pms.ManageAuthorization.Business.Factory.ManageAuthorizationProviderFactory
			                .CreateProvider(DataMode)
			                .GetAllApplicationFunctions();
		}
		public ApplicationFunctionViewItem[] SaveApplicationFunctions(ApplicationFunctionViewItem[] applicationFunctionViewItems)		{
			return Pms.ManageAuthorization.Business.Factory.ManageAuthorizationProviderFactory
			                .CreateProvider(DataMode)
			                .SaveApplicationFunctions(applicationFunctionViewItems);
		}
		public ApplicationFunctionViewItem[] DeleteApplicationFunctions(ApplicationFunctionViewItem[] applicationFunctionViewItems)		{
			return Pms.ManageAuthorization.Business.Factory.ManageAuthorizationProviderFactory
			                .CreateProvider(DataMode)
			                .DeleteApplicationFunctions(applicationFunctionViewItems);
		}
		public RoleViewItem[] GetAllRoles()		{
			return Pms.ManageAuthorization.Business.Factory.ManageAuthorizationProviderFactory
			                .CreateProvider(DataMode)
			                .GetAllRoles();
		}
		public RoleViewItem[] SaveRoles(RoleViewItem[] roleViewItems)		{
			return Pms.ManageAuthorization.Business.Factory.ManageAuthorizationProviderFactory
			                .CreateProvider(DataMode)
			                .SaveRoles(roleViewItems);
		}
		public RoleViewItem[] DeleteRoles(RoleViewItem[] roleViewItem)		{
			return Pms.ManageAuthorization.Business.Factory.ManageAuthorizationProviderFactory
			                .CreateProvider(DataMode)
			                .DeleteRoles(roleViewItem);
		}
		public AccountViewItem[] GetAccountsForRole(String roleId)		{
			return Pms.ManageAuthorization.Business.Factory.ManageAuthorizationProviderFactory
			                .CreateProvider(DataMode)
			                .GetAccountsForRole(roleId);
		}
		public AccountViewItem[] GetAllAccounts()		{
			return Pms.ManageAuthorization.Business.Factory.ManageAuthorizationProviderFactory
			                .CreateProvider(DataMode)
			                .GetAllAccounts();
		}
		protected override void RegisterRequiredDomainObjects()		{
			OnRegisterRequiredDomainObjects();
		}
		partial void OnRegisterRequiredDomainObjects();			
		#endregion		
	}
}

---------------------------New File------------------------------------------------------

