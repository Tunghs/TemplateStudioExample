﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
