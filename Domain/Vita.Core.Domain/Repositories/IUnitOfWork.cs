﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Vita.Core.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}
