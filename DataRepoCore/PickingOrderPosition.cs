﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepoCore {
    public record PickingOrderPosition {
        /// <summary>
        /// The id of the picking-order-position.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// The article of the picking-position.
        /// </summary>
        public required Article Article { get; init; }

        /// <summary>
        /// The amount to be picked.
        /// </summary>
        [Range(0, int.MaxValue)]
        public required int DesiredAmount { get; init; }

        /// <summary>
        /// The amount that was already picked.
        /// </summary>
        [Range(0, int.MaxValue)]
        public required int PickedAmount { get; init; }
    }
}
