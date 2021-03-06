﻿// ==========================================================================
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex UG (haftungsbeschränkt)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

namespace Squidex.Domain.Apps.Entities.Apps.Commands
{
    public sealed class UpdateClient : AppCommand
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}
