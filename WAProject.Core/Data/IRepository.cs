﻿using System;
using WAProject.Core.DomainObjects;

namespace WAProject.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}