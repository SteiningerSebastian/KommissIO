﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepoCore {
    public record StockPosition {
        /// <summary>
        /// The id of the stock-position.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// The article stored at the stock-position
        /// </summary>
        public required Article Article { get; init; }

        /// <summary>
        /// The amount of the article stored at the position.
        /// </summary>
        [Range(0, int.MaxValue)]
        public required int Amount { get; init; }

        /// <summary>
        /// The shelf where the stok-position is stored.
        /// </summary>
        public required int ShelfNumber { get; init; }
    }
}
