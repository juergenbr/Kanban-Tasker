﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace KanbanTasker
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ViewModels.BoardViewModel>();
            builder.RegisterType<ViewModels.MainViewModel>();
        }
    }
}
