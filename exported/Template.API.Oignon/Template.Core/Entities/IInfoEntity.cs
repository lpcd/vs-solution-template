using System;

namespace $safeprojectname$.Entities
{
    public interface IInfoEntity
    {
        /// <summary>
        /// Get or set creation datetime
        /// </summary>
        public DateTime CreationDateTime { get; set; }

        /// <summary>
        /// Get or set modification datetime
        /// </summary>
        public DateTime ModificationDateTime { get; set; }
    }
}