// Copyright (c) Oleksii Nikiforov, 2021. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace NikiforovAll.ES.Template.Messaging.Contracts;

public interface MarkToDoItemComplete
{
    public Guid ProjectId { get; }

    public int ItemId { get; }
}