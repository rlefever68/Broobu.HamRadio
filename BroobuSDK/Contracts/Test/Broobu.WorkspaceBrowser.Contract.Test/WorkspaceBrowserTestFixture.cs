using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pms.Explorer.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Agent;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Interfaces;
using EnumBaseType = Pms.Explorer.Contract.Domain.ExplorerDomainGenerator.EnumBaseType;
using Pms.Framework.Logging;
using Pms.Explorer.Contract.Constants;

namespace Pms.WorkspaceBrowser.Contract.Test
{
    [TestClass]
    public class WorkspaceBrowserTestFixture
    {
        #region " Fields "
        private readonly IWorkspaceBrowserAgent _agent;
        private readonly Guid[] _guids;
        private readonly DateTime _dateCreatedModified = DateTime.Now;
        private WorkspaceItem[] _items;
        private int _index;
        private ILog Logger;
        #endregion


        #region " Properties "
        #endregion

        #region " Constants "
        private const int CAmountItemsToRegister       = 18;
        private const int CAmountRootTotal             = 5;
        private const int CAmountFoldersUnderRoot      = 2;
        private const int CAmountNodesUnderRoot        = 3;
        private const int CAmountLanguages             = 11;
        private const int CAmountSpecificSearchStrings = 2;
        private const int CAmountProps                 = 3;
        private const int CAmountDesc                  = 2;
        private const int CStringLength                = 30;
        private const string CSearchString             = "specific";
        private const string CWorkspaceRootId          = WorkspaceRoot.Id;

        #endregion

        #region fields
        private readonly string _treeViewFolderTypeId   = String.Empty;
        private readonly string _treeViewLeafTypeId     = String.Empty;
        private readonly string _itemDescriptionTypeId  = String.Empty;
        private readonly string _languageTypeId         = String.Empty;
        private readonly string _itemPropertyTypeId     = String.Empty;
        #endregion

        #region " Delegates "
        private delegate string ProcessWorkspaceItemDelegate(WorkspaceItem item, int counter, int count);
        private delegate string ProcessWorkspaceItemsDelegate(WorkspaceItem[] items, ProcessWorkspaceItemDelegate process);

        [Ignore]
        string RegisterWorkspaceItem(WorkspaceItem item, int counter, int count)
        {
            DebugWrite(String.Format("RegisterWorkspaceItem {0} / {1}", counter, count));
            return _agent.RegisterWorkspace(item);
        }

        [Ignore]
        string ProcessWorkspaceItems(WorkspaceItem[] items, ProcessWorkspaceItemDelegate process)
        {
            string result = String.Empty;
            int i = 0;
            int count = items.Length;
            foreach (WorkspaceItem item in items)
            {
                UpdateResult(ref result, process(item, ++i, count));
            }
            return result;
        }

        [Ignore]
        string PrintWorkspaceItem(WorkspaceItem item, int counter, int count)
        {
            int indentLevelOrig = Debug.IndentLevel;
            int indentLevel = Debug.IndentLevel;
            Debug.IndentLevel = ++indentLevel;
            Debug.WriteLine(item.ToString());
            Debug.IndentLevel = ++indentLevel;
            if (item.Descriptions != null)
            {
                int i = 1;
                int length = item.Descriptions.Length;
                Debug.WriteLine(String.Format("Descriptions[{0}]", length)); Logger.InfoFormat("Descriptions[{0}]", length);
                Debug.IndentLevel = ++indentLevel;
                foreach (WorkspaceItemDescription description in item.Descriptions)
                {
                    Debug.WriteLine(String.Format("Description {0} of {1} => {2}", i, length, description));
                    Logger.InfoFormat("\tDescription {0} of {1} => {2}", i++, length, description);
                }
                Debug.IndentLevel = --indentLevel;
            }
            if (item.Children != null)
            {
                int i = 1;
                int length = item.Children.Length;
                Debug.WriteLine(String.Format("Children[{0}]", length)); Logger.InfoFormat("Children[{0}]", length);
                Debug.IndentLevel = ++indentLevel;
                foreach (WorkspaceItem child in item.Children)
                {
                    Debug.WriteLine(String.Format("Child {0} of {1} => {2}", i, length, child));
                    Logger.InfoFormat("\tChild {0} of {1} => {2}", i++, length, child);
                }
                Debug.IndentLevel = --indentLevel;
            }
            if (item.Properties != null)
            {
                int i = 1;
                int length = item.Properties.Length;
                Debug.WriteLine(String.Format("Properties[{0}]", length)); Logger.InfoFormat("Properties[{0}]", length);
                Debug.IndentLevel = ++indentLevel;
                foreach (WorkspaceItemProperty property in item.Properties)
                {
                    Debug.WriteLine(String.Format("Property {0} of {1} => {2}", i, length, property));
                    Logger.InfoFormat("\tProperty {0} of {1} => {2}", i++, length, property);
                }
                Debug.IndentLevel = --indentLevel;
            }
            Debug.IndentLevel = indentLevelOrig;
            return String.Empty;
        }
        #endregion

        #region " Constructor "
        public WorkspaceBrowserTestFixture()
        {
            Logger = LogManager.GetLogger(GetType());
            Logger.Info("WorkspaceBrowserTestFixture constructor");

            _treeViewFolderTypeId = ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.TreeViewFolder);
            _treeViewLeafTypeId = ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.TreeViewLeaf);
            _languageTypeId = ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.Languages);
            _itemDescriptionTypeId = ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.WorkspaceItemDescription);
            _itemPropertyTypeId = ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.WorkspaceItemProperty);
            _agent = WorkspaceBrowserAgentFactory.CreateAgent(WorkspaceBrowserAgentFactory.Key.Instance);
            _guids = new Guid[CAmountItemsToRegister];
            for (int i = 0; i < _guids.Length; i++)
            {
                _guids[i] = new Guid(i + 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
            _index = 0;
            Logger.InfoFormat("_treeViewFolderTypeId  = '{0}'", _treeViewFolderTypeId);
            Logger.InfoFormat("_treeViewLeafTypeId    = '{0}'", _treeViewLeafTypeId);
            Logger.InfoFormat("_languageTypeId        = '{0}'", _languageTypeId);
            Logger.InfoFormat("_itemDescriptionTypeId = '{0}'", _itemDescriptionTypeId);
        }
        #endregion

        [TestMethod]
        public void Try_Initialize()
        {
            bool result = _agent.Initialize();
            if (result)
                Logger.Info("Initialize = true");
            else
                Logger.Warn("Initialize failed");
            Assert.IsTrue(result, "Initializing of WorkspaceBrowser service failed");
        }

        [TestMethod]
        public void Try_RegisterWorkspace()
        {
            ProcessWorkspaceItemsDelegate processWorkspaceItemsDelegate = ProcessWorkspaceItems;
            _items = new WorkspaceItem[CAmountItemsToRegister];

            #region " Structure created by Try_RegisterWorkspace "
            // Structure              | Title                              | Id                                   | Parent
            // =========================================================================================================================================
            // ROOT                   | Root                               | ROOT                                 | ROOT
            //  |---1                 | Applications                       | 00000001-0000-0000-0000-000000000000 | ROOT
            //  |   |                 |                                    |                                      | 
            //  |   |---2             | Business applications              | 00000002-0000-0000-0000-000000000000 | 00000001-0000-0000-0000-000000000000
            //  |   |   |---3         | Business application 1             | 00000003-0000-0000-0000-000000000000 | 00000002-0000-0000-0000-000000000000
            //  |   |   |---4         | Business application 2             | 00000004-0000-0000-0000-000000000000 | 00000002-0000-0000-0000-000000000000
            //  |   |   |---5         | Business application 3             | 00000005-0000-0000-0000-000000000000 | 00000002-0000-0000-0000-000000000000
            //  |   |                 |                                    | 
            //  |   |---6             | My applications                    | 00000006-0000-0000-0000-000000000000 | 00000001-0000-0000-0000-000000000000
            //  |   |   |---7         | My applications type 1             | 00000007-0000-0000-0000-000000000000 | 00000006-0000-0000-0000-000000000000
            //  |   |   |   |---9     | My applications 1.1                | 00000008-0000-0000-0000-000000000000 | 00000006-0000-0000-0000-000000000000
            //  |   |   |       |---A | My applications 1 of type 1        | 00000009-0000-0000-0000-000000000000 | 00000007-0000-0000-0000-000000000000
            //  |   |   |       |---B | My applications 2 of type 1        | 0000000a-0000-0000-0000-000000000000 | 00000009-0000-0000-0000-000000000000
            //  |   |   |             |                                    | 
            //  |   |   |---8         | My applications type 2             | 0000000b-0000-0000-0000-000000000000 | 00000009-0000-0000-0000-000000000000
            //  |   |       |---C     | My application 3                   | 0000000c-0000-0000-0000-000000000000 | 00000008-0000-0000-0000-000000000000
            //  |   |       |---D     | My application 4                   | 0000000d-0000-0000-0000-000000000000 | 00000008-0000-0000-0000-000000000000
            //  |   |       |---E     | My + CSearchString + application 1 | 0000000e-0000-0000-0000-000000000000 | 00000008-0000-0000-0000-000000000000
            //  |   |       |---F     | My + CSearchString + application 2 | 0000000f-0000-0000-0000-000000000000 | 00000008-0000-0000-0000-000000000000
            //  |   |                 |                                    | 
            //  |   |---10            | App item 1                         | 00000010-0000-0000-0000-000000000000 | 00000001-0000-0000-0000-000000000000                
            //  |   |---11            | App item 2                         | 00000011-0000-0000-0000-000000000000 | 00000001-0000-0000-0000-000000000000
            //  |   |---12            | App item 3                         | 00000012-0000-0000-0000-000000000000 | 00000001-0000-0000-0000-000000000000
            #endregion

            CreateWorkspaceItemToRegister(_guids[_index].ToString(), CWorkspaceRootId, true, "Applications");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[0].Id, true, "Business applications");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[1].Id, false, "Business application 1");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[1].Id, false, "Business application 2");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[1].Id, false, "Business application 3");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[0].Id, true, "My applications");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[5].Id, true, "My applications type 1");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[5].Id, true, "My applications type 2");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[6].Id, true, "My applications type 1.1");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[8].Id, false, "My applications 1 of type 1");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[8].Id, false, "My applications 2 of type 1");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[7].Id, false, "My application 3");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[7].Id, false, "My application 4");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[7].Id, false, String.Format("My {0} application 1", CSearchString));
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[7].Id, false, String.Format("My {0} application 2", CSearchString));
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[0].Id, false, "App item 1");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[0].Id, false, "App item 2");
            CreateWorkspaceItemToRegister(_guids[_index].ToString(), _items[0].Id, false, "App item 3");

            var s = String.Format("Try_RegisterWorkspace [{0}] = {1}", _index, processWorkspaceItemsDelegate(_items, RegisterWorkspaceItem));
            Debug.WriteLine(s); Logger.Info(s);

            WorkspaceItem[] itemsRoot = Try_GetWorkspace(new Guid(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).ToString());
            var resultTotal = itemsRoot.Count();
            // amount of folders under ROOT
            var resultFolders = (from item in itemsRoot
                                 where item.TypeId == _treeViewFolderTypeId
                                 select item).Count();
            // amount of nodes under ROOT
            var resultNodes = (from item in itemsRoot
                               where item.TypeId == _treeViewLeafTypeId
                               select item).Count();
            Assert.AreEqual(CAmountRootTotal, resultTotal);
            Assert.AreEqual(CAmountFoldersUnderRoot, resultFolders);
            Assert.AreEqual(CAmountNodesUnderRoot, resultNodes);

            DebugWriteFinished("Try_RegisterWorkspace finished on {0}");
        }

        [Ignore]
        private void CreateWorkspaceItemToRegister(string id, string parentId, string typeId, string title)
        {
            _items[_index] = new WorkspaceItem { Id = id, ParentId = parentId, ItemId = id, TypeId = typeId, ItemTitle = FormatTitle(title), DateModified = DateTime.Now };
        }

        [Ignore]
        private void CreateWorkspaceItemToRegister(string id, string parentId, bool folder, string text)
        {

            string title = FormatTitle(text);
            var props    = new WorkspaceItemProperty[CAmountProps];
            var descs    = new WorkspaceItemDescription[CAmountDesc];
            int subIndex;
            string idHex;
            string idGuid;

            subIndex = (_index * 10) + 1;
            for (int i = 0; i < CAmountProps; i++)
            {
                idGuid = new Guid(subIndex, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).ToString();
                idHex = idGuid.Substring(6, 2);
                props[i] = new WorkspaceItemProperty
                {
                    Id = idGuid,
                    ItemId = id,
                    PropertyName = String.Format("Property({0}) - {1} of {2}", idHex, i + 1, CAmountProps),
                    PropertyValue = String.Format("Property value({0}) - {1} of {2}", idHex, i + 1, CAmountProps),
                    PropertyTypeId = _itemPropertyTypeId,
                    PropertyTypeDescription = String.Format("Property description({0}) - {1} of {2}", subIndex, i + 1, CAmountProps)
                };
                subIndex++;
            }
            subIndex = (_index * 10) + 1;
            for (int i = 0; i < CAmountDesc; i++)
            {
                idGuid = new Guid(subIndex, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).ToString();
                idHex = idGuid.Substring(6, 2);
                descs[i] = new WorkspaceItemDescription
                {
                    CultureId = CultureInfo.CurrentCulture.Name,
                    Id = idGuid,
                    ItemId = id,
                    Title = String.Format("Description({0}) - {1} of {2}", idHex, i + 1, CAmountDesc),
                    TypeId = _itemDescriptionTypeId
                };
                subIndex++;
            }
            _items[_index++] = new WorkspaceItem { Id = id, ParentId = parentId, ItemId = id, TypeId = (folder ? _treeViewFolderTypeId : _treeViewLeafTypeId), ItemTitle = title, Descriptions = descs, Properties = props, DateModified = DateTime.Now };
        }

        [Ignore]
        private string FormatTitle(string text)
        {
            return String.Format("{0}{1} - {2}", text, new string(' ', CStringLength - text.Length), (_index > 14 ? "" : _dateCreatedModified.ToString()));
        }

        [TestMethod]
        public void Try_GetLanguages()
        {
            WorkspaceItem[] languagesReadFromDb = _agent.GetLanguages().ToArray();
            var languagesToGenerate = ExplorerDomainGenerator.GetEnumerationItemsLanguages();
            foreach (WorkspaceItem language in languagesReadFromDb)
            {
                Logger.InfoFormat("Languge ( {0} )", language);
            }
            Assert.AreEqual(languagesReadFromDb.Count(), languagesToGenerate.Count());
            DebugWriteFinished("Try_GetLanguages finished on {0}");
        }

        [TestMethod]
        public void Try_GetWorkspaceRoot()
        {
            WorkspaceItem[] items = Try_GetWorkspace(WorkspaceRoot.Parent);
            Debug.WriteLine(items[0].ToString());
            Assert.AreEqual(1, items.Count());// veranderen
            DebugWriteFinished("Try_GetWorkspaceRoot finished on {0}");
        }

        [TestMethod]
        public void Try_GetWorkspace()
        {
            WorkspaceItem[] items = Try_GetWorkspace(_guids[0].ToString());
            Assert.AreEqual(CAmountRootTotal, items.Count());
            DebugWriteFinished("Try_GetWorkspace finished on {0}");
        }

        [Ignore]
        public WorkspaceItem[] Try_GetWorkspace(string parentId)
        {
            return Try_GetWorkspace(parentId, false);
        }

        [Ignore]
        public WorkspaceItem[] Try_GetWorkspace(string parentId, bool ignoreAssert)
        {
            WorkspaceItem[] items = _agent.GetWorkspace(parentId).ToArray();
            ProcessWorkspaceItemsDelegate processWorkspaceItemsDelegate = ProcessWorkspaceItems;
            ProcessWorkspaceItemDelegate processWorkspaceItemDelegate = PrintWorkspaceItem;
            processWorkspaceItemsDelegate(items, processWorkspaceItemDelegate);
            if (!ignoreAssert) Assert.AreNotEqual(0, items.Count());
            return items;
        }

        [TestMethod]
        public void Try_GetFullWorkspaceItem()
        {
            WorkspaceItem item  = _agent.GetFullWorkspaceItem(_guids[0].ToString());
            Assert.AreNotEqual(null, item);
            Assert.AreEqual(CAmountRootTotal, _items.Count());
            Assert.AreEqual(item.ItemTitle, WorkspaceRoot.Title);
            Assert.AreEqual(item.TypeId, _treeViewFolderTypeId);
            Assert.AreEqual(item.SortOrder, 0);
            DebugWriteFinished("Try_GetFullWorkspaceItem = " + item);//]
        }

        [TestMethod]
        public void Try_GetWorkspaceItemsBySearchString()
        {
            WorkspaceItem[] items = _agent.GetWorkspaceItemsBySearchString(CSearchString).ToArray();
            ProcessWorkspaceItemsDelegate processWorkspaceItemsDelegate = ProcessWorkspaceItems;
            ProcessWorkspaceItemDelegate processWorkspaceItemDelegate = PrintWorkspaceItem;
            processWorkspaceItemsDelegate(items, processWorkspaceItemDelegate);
            Assert.AreEqual(CAmountSpecificSearchStrings, items.Count());
            DebugWriteFinished("Try_GetWorkspaceItemsBySearchString finished on {0}");
        }

        [TestMethod]
        public void Try_GetFolderRoot()
        {
            WorkspaceItem[] items = _agent.GetFolders(WorkspaceRoot.Top).ToArray();
            Assert.AreEqual(1, items.Count());
            DebugWriteFinished("Try_GetFolderRoot finished on {0}");
        }

        [TestMethod]
        public void Try_GetFolders()
        {
            WorkspaceItem[] items1 = _agent.GetFolders(WorkspaceRoot.Parent).ToArray();
            var r1 = items1.Count();
            var r2 = (from item in items1
                      where item.TypeId == _treeViewFolderTypeId
                      select item).Count();
            Assert.AreEqual(r1, r2);

            WorkspaceItem[] items2 = _agent.GetFolders(new Guid(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).ToString()).ToArray();
            var r3 = items2.Count();
            var r4 = (from item in items2
                      where item.TypeId == _treeViewFolderTypeId
                      select item).Count();
            Assert.AreEqual(r3, r4);

            DebugWriteFinished("Try_GetFolders finished on {0}");
        }

        [TestMethod]
        public void Try_RegisterDescription()
        {
            if (_index == 0) _index = CAmountItemsToRegister;
            string id = new Guid((_index * 10) + 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).ToString();

            // create
            var workspaceItemDescription = new WorkspaceItemDescription
                                                                    {
                                                                        Id = id,
                                                                        ItemId = Guid.Empty.ToString(),
                                                                        CultureId = CultureInfo.CurrentCulture.Name,
                                                                        Title = "Created " + DateTime.Now,
                                                                        Image = new byte[] { },
                                                                        TypeId = _itemDescriptionTypeId,
                                                                    };
            string result1 = _agent.RegisterDescription(workspaceItemDescription);
            Assert.AreEqual(id, result1);

            // update
            workspaceItemDescription.Title = "Updated " + DateTime.Now;
            string result2 = _agent.RegisterDescription(workspaceItemDescription);
            Assert.AreEqual(id, result2);

            // insert
            workspaceItemDescription = new WorkspaceItemDescription
            {
                Id = string.Empty,
                ItemId = Guid.Empty.ToString(),
                CultureId = CultureInfo.CurrentCulture.Name,
                Title = "Created " + DateTime.Now,
                Image = new byte[] { },
                TypeId = _itemDescriptionTypeId
            };
            string result3 = _agent.RegisterDescription(workspaceItemDescription);
            Logger.InfoFormat("Registered description (Id = '{0}')", result3);
            Assert.AreNotEqual(string.Empty, result3);

            DebugWriteFinished("Try_RegisterDescription finished on {0}");
        }

        [TestMethod]
        public void Try_RegisterProperty()
        {

            


            _index = (_index == 0) ? CAmountItemsToRegister : _index;
            string id = new Guid((_index * 10) + 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0).ToString();

            var workspaceItemProperty = new WorkspaceItemProperty
                                                              {
                                                                  Id = id,
                                                                  ItemId = Guid.Empty.ToString(),
                                                                  PropertyName = "Created",
                                                                  PropertyValue = DateTime.Now.ToString(),
                                                                  PropertyTypeId = _itemPropertyTypeId,
                                                              };

            // create
            string result1 = _agent.RegisterProperty(workspaceItemProperty);
            Assert.AreEqual(id, result1);

            // update
            workspaceItemProperty.PropertyName = "Updated " + DateTime.Now;
            string result2 = _agent.RegisterProperty(workspaceItemProperty);
            Assert.AreEqual(id, result2);

            // only create
            workspaceItemProperty = new WorkspaceItemProperty
                                                              {
                                                                  Id = string.Empty,
                                                                  ItemId = Guid.Empty.ToString(),
                                                                  PropertyName = "Created",
                                                                  PropertyValue = DateTime.Now.ToString(),
                                                                  PropertyTypeId = _itemPropertyTypeId
                                                              };
            string result3 = _agent.RegisterProperty(workspaceItemProperty);

            Assert.AreNotEqual(string.Empty, result3);
            Logger.InfoFormat("Property registered (Id = '{0}'", result3);
            DebugWriteFinished("Try_RegisterProperty finished on {0}");
        }

        [TestMethod]
        public void Try_GetItemsForTypeId()
        {
            ProcessWorkspaceItemsDelegate processWorkspaceItemsDelegate = ProcessWorkspaceItems;
            IEnumerable<WorkspaceItem> items =  _agent.GetItemsForTypeId(_languageTypeId);
            Assert.AreNotEqual(CAmountLanguages, items.Count());
            processWorkspaceItemsDelegate(items.ToArray(), PrintWorkspaceItem);
            DebugWriteFinished("Try_GetItemsOfTypeId finished on {0}");
        }

        [TestMethod]
        public void Try_GetPropertiesForTypeId()
        {
            var items = _agent.GetPropertiesForTypeId(_itemPropertyTypeId);
            Debug.WriteLine(String.Format("Count = {0}", items.Count()));
            Assert.IsTrue((CAmountItemsToRegister * CAmountProps) < items.Count());
            DebugWriteFinished("Try_GetItemsOfTypeId finished on {0}");
        }

        [Ignore]
        private void UpdateResult(ref string result1, string result2)
        {
            result1 += (result1.Length > 0) ? "," + result2 : result2;
        }

        [Ignore]
        private void DebugWrite(string functionName)
        {
            functionName += " " + DateTime.Now;
            Debug.WriteLine('\n' + functionName);
            Logger.Info(functionName);
            Debug.WriteLine(new string('=', functionName.Length));
            Logger.Info(new string('=', functionName.Length));
        }

        [Ignore]
        private void DebugWriteFinished(string message)
        {
            Debug.WriteLine(String.Format(message, DateTime.Now));
            Logger.Info(String.Format(message, DateTime.Now));
        }
    }
}
