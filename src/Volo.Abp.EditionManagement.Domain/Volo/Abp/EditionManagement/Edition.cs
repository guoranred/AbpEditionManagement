using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Volo.Abp.EditionManagement
{
    public class Edition : FullAuditedAggregateRoot<Guid>
    {
        public virtual string DisplayName { get; protected set; }

        protected Edition()
        {
            ExtraProperties = new Dictionary<string, object>();
        }

        protected internal Edition(Guid id, [NotNull] string displayName)
        {
            Id = id;
            SetDisplayName(displayName);

            ExtraProperties = new Dictionary<string, object>();
            ConcurrencyStamp = Guid.NewGuid().ToString();
        }

        protected virtual internal void SetDisplayName([NotNull] string name)
        {
            DisplayName = Check.NotNullOrWhiteSpace(name, nameof(name), EditionConsts.MaxDisplayNameLength);
        }
    }
}