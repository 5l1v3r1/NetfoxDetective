﻿// Copyright (c) 2017 Jan Pluskal, Martin Mares, Martin Kmet
//
//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

using Castle.Windsor;
using GalaSoft.MvvmLight.Threading;
using Netfox.Core.Interfaces.Views;
using Netfox.Detective.ViewModelsDataEntity.ConversationsCollections;

namespace Netfox.Detective.ViewModelsDataEntity.Conversations
{
    public class ConversationsDetailVm : DetectiveIvestigationDataEntityPaneViewModelBase
    {
        public ConversationsDetailVm(WindsorContainer applicationWindsorContainer, IConversationsVm model) : base(applicationWindsorContainer, model)
        {
            this.ConversationsVm = model;
            DispatcherHelper.CheckBeginInvokeOnUI(() => this.View = this.ApplicationOrInvestigationWindsorContainer.Resolve<IConversationsDetailView>());
        }

        public IConversationsVm ConversationsVm { get; }

        #region Overrides of DetectivePaneViewModelBase
        public override string HeaderText => "Conversations detail";

        public override bool IsSelected
        {
            get { return base.IsSelected; }
            set
            {
                base.IsSelected = value;
                var conversationsVm = this.ConversationsVm;
                if(conversationsVm != null) { conversationsVm.IsSelected = value; }
            }
        }
        #endregion
    }
}