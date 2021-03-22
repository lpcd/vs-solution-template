using System;

namespace Softfluent.Template.Core.Entities
{
    public class TodoEntity : IBaseEntity, IInfoEntity
    {
        /* IBaseEntity implementation */
        public long ID { get; set; }

        /* IInfoEntity implementation */
        public DateTime CreationDateTime { get; set; }
        public DateTime ModificationDateTime { get; set; }

        /* Own properties */
        public string Label { get; set; }
    }
}